
using DatabaseLinker;
using DataStreaming.db;
using HttpMultipartParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DataStreaming
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StreamService" in both code and config file together.
    public class StreamService : IStreamService
    {

        static string STORAGE_MAIM_PATH = Application.StartupPath + @"\AppData\Contents\";

        // TODO: constant (names from android)


        #region upload content



        public string UploadPhoto(Stream stream)
        {
            string hashedFileContent = "";
            string localPath;



            // First we need to get the boundary from the header, this is sent
            // with the HTTP request. We can do that in WCF using the WebOperationConext:
            var type = WebOperationContext.Current.IncomingRequest.Headers["Content-Type"];
            var realContentHash = WebOperationContext.Current.IncomingRequest.Headers["Content-MD5"];
            var token = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

            // Now we want to strip the boundary out of the Content-Type, currently the string
            // looks like: "multipart/form-data; boundary=---------------------124123qase124"
            var boundary = type.Substring(type.IndexOf('=') + 1);

            // Now that we've got the boundary we can parse our multipart and use it as normal
            var parser = new MultipartFormDataParser(stream, boundary, Encoding.UTF8);

            // Get the parameters from the request body
            string id = parser.Parameters["Id"].Data;
            //string token = parser.Parameters["Token"].Data;
            string typeOfContent = parser.Parameters["TypeOfContent"].Data;


            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(token) as IDictionary<string, object>;

            // Authenticate the request
            if (payLoad == null)
            {
                // Authentication error
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }


            localPath = CreateContentDirectory(typeOfContent);
            
            // Get the files from the request body
            foreach (FilePart file in parser.Files)
            {
                // File integrity verification using MD5
                hashedFileContent = utils.MD5Checksum.GetMD5HashFromFile(file.Data);
                Console.WriteLine(hashedFileContent);


                // Check if file is damaged with the equation of the md-5 hash
                if (!hashedFileContent.Equals(realContentHash))
                {
                    // TODO: fix to other error
                    SetResponseHttpStatus(HttpStatusCode.Conflict);
                    return null;
                }

                using (Image img = Image.FromStream(file.Data))
                {
                    SavePhoto(localPath, file, img);
                    UpdateHtml();
                }

                StoredContentBL bl = new StoredContentBL();
               // bl.StorePhoto(id, file.Name);
            }

            return hashedFileContent;

        }

        private void UpdateHtml()
        {
            // Update the html file
            // TODO: Check if need  to update according the date, check what the last time new content arrived and the last time updated

            if (needToUpdateHtml())
            {
                string html = "";
                using (StreamReader sr = new StreamReader(STORAGE_MAIM_PATH + "lib/PhotoGallery/core/gallery.html"))
                {
                    html = sr.ReadToEnd();
                }

                // Getting all images in the photos folder
                DirectoryInfo dir = new DirectoryInfo(STORAGE_MAIM_PATH + "Photo");
                FileInfo[] images = dir.GetFiles("*.jpg");
                string body = "";

                var rimages = images.Reverse();

                // For each image in folder create jquery row
                foreach (FileInfo image in rimages)
                {
                    if (!image.Name.StartsWith("small_") && !image.Name.StartsWith("medium_"))
                    {
                        body += "{image : '../../Photo/" + image.Name + "', title : 'Image Credit: Maria Kazvan', thumb : '../../Photo/" + image.Name + "', url : ''},\n";
                    }

                }
                body = body.Substring(0, body.Length - 2);
                html = html.Replace("<!--###CONTENT###-->", body);
                using (System.IO.StreamWriter htmlFile = new System.IO.StreamWriter(STORAGE_MAIM_PATH + "lib\\PhotoGallery\\index.html"))
                {
                    htmlFile.Write(html);
                }
            }
        }
        private bool needToUpdateHtml()
        {
            return true;
        }


        private void SavePhoto(string localPath, FilePart file, Image img)
        {
            // Rotate photo according the orientation
            if (Array.IndexOf(img.PropertyIdList, 274) > -1)
            {
                var orientation = (int)img.GetPropertyItem(274).Value[0];
                switch (orientation)
                {
                    case 1:
                        img.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        break;
                    case 2:
                        img.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        break;
                    case 3:
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 4:
                        img.RotateFlip(RotateFlipType.Rotate180FlipX);
                        break;
                    case 5:
                        img.RotateFlip(RotateFlipType.Rotate90FlipX);
                        break;
                    case 6:
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 7:
                        img.RotateFlip(RotateFlipType.Rotate270FlipX);
                        break;
                    case 8:
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }
                // This EXIF data is now invalid and should be removed.
                img.RemovePropertyItem(274);
            }


            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID 
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            EncoderParameters myEncoderParameters = new EncoderParameters(1);
  
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            img.Save(localPath + file.FileName, jpgEncoder, myEncoderParameters);

            CreateThumbnail(200, localPath, file.FileName, img);
        }
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        private static void CreateThumbnail(int width, string localPath, string fileName, Image image)
        {
            // Making thumbmail images
            
            float imgWidth = image.PhysicalDimension.Width;
            float imgHeight = image.PhysicalDimension.Height;
            float imgSize = imgHeight > imgWidth ? imgHeight : imgWidth;
            float imgResize = imgSize <= width ? (float)1.0 : width / imgSize;
            imgWidth *= imgResize; imgHeight *= imgResize;

            using (System.Drawing.Image thumb = image.GetThumbnailImage((int)imgWidth, (int)imgHeight, delegate() { return false; }, (IntPtr)0))
            {
                string prefix;
                if (width == 200)
                {
                    prefix = "small";
                }
                else
                {
                    prefix = "medium";
                }
                thumb.Save(localPath + prefix + "_" + fileName);
            }


            
        }
        private bool ThumbnailCallback()
        {
            throw new NotImplementedException();
        }


        public string UploadContact(ContactRequest request)
        {
            var realContentHash = WebOperationContext.Current.IncomingRequest.Headers["Content-MD5"];
            var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            if (request != null)
            {
                

                // Decode the user id from the token
                var payLoad = JWTManager.DecodeToken(authToken) as IDictionary<string, object>;

                // Authenticate the request
                if (payLoad == null)
                {
                    // Authentication error
                    SetResponseHttpStatus(HttpStatusCode.Forbidden);
                    return null;
                }

                // TODO: MD5 hash check

                // Creating hash from request body
                string contentHash = realContentHash; //utils.MD5Checksum.StringMD5Hash(tempMD5);

                // Checking if the hashes are equal
                if (!contentHash.Equals(realContentHash))
                {
                    // Means there is a problem
                    SetResponseHttpStatus(HttpStatusCode.Conflict);
                    return null;
                }

                StoredContentBL bl = new StoredContentBL();
                //bl.StoreContact(request);

                HandleSaveContact(request);
                /*
                Contact contact = new Contact();
                contact.Id = Int32.Parse(request.Id);
                contact.DisplayName = request.DisplayName;
                contact.PhotoURI = request.PhotoURI;

                
                ContentContext db = new ContentContext();
                db.Contacts.Add(contact);
                db.SaveChanges();
                */
                return realContentHash;
            }

            SetResponseHttpStatus(HttpStatusCode.InternalServerError);
            return null;
        }
        


        #endregion upload content



        /*
        #region download content



        public Stream Download(string context, string fileName)
        {
            string downloadFilePath = "";

            if (context.Equals("internal"))
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/png";
                downloadFilePath = STORAGE_MAIM_PATH + @"lib/img";

            } else if (context.Equals("external")) {
                downloadFilePath = STORAGE_MAIM_PATH + @"Photo";
                
                WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpg";
            }

           
            FileStream f = new FileStream(downloadFilePath + "\\" + fileName, FileMode.Open);
            int length = (int)f.Length;
            WebOperationContext.Current.OutgoingResponse.ContentLength = length;
            byte[] buffer = new byte[length];
            int sum = 0;
            int count;
            while ((count = f.Read(buffer, sum, length - sum)) > 0)
            {
                sum += count;
            }
            f.Close();
            return new MemoryStream(buffer); 
        }

        public Stream getGallery()
        {


            string html = File.ReadAllText(STORAGE_MAIM_PATH + "lib/gallery.html");
            
           
            
            // Getting all images in the photos folder
            DirectoryInfo dir = new DirectoryInfo(STORAGE_MAIM_PATH + "Photo");
            FileInfo[] images = dir.GetFiles("*.jpg");
            string body = "";

            var rimages = images.Reverse();

            // For each image in folder create jquery row
            foreach (FileInfo image in rimages)
            {
                if (!image.Name.StartsWith("small_")) {
                    body += @"{image : '../Download/external/" + image.Name + 
                            @"', title : 'Image Credit: Maria Kazvan', thumb : '../Download/external/" + image.Name + 
                            @"', url : '../Download/" + image.Name + @"'},";
                }
                
            }
            // pushing the image rows
            body = body.Substring(0, body.Length - 1);
            html = html.Replace("###CONTENT###", body);
           
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/html";
            int length = (int)html.Length;
            WebOperationContext.Current.OutgoingResponse.ContentLength = length;
            
            byte[] byteArray = Encoding.ASCII.GetBytes(html);
      

            return new MemoryStream(byteArray); 
        }

        
        
        #endregion download content

        */


        // Private functions

        private void SetResponseHttpStatus(HttpStatusCode statusCode)
        {
            var context = WebOperationContext.Current;
            context.OutgoingResponse.StatusCode = statusCode;
        }

        private void HandleSaveContact(ContactRequest request)
        {

            XDocument contacts;
            string localPath;

            localPath = CreateContentDirectory(request.TypeOfContent);

            // Open existing xml file (if exist)
            try
            {
                contacts = XDocument.Load(localPath + "contacts.xml");
            }
            catch
            {
                contacts = new XDocument();
                contacts.Add(new XElement("Contacts"));
            }


            // Search for existing contact before appending
            var query = from c in contacts.Descendants("DBContact")
                        where ((c.Attribute("Id").Value.Trim().Equals(request.Id)))
                        select c;

            if (query.Count() == 0)
            {
                // Means contact dosent exist

                // Append new content to xml
                //contacts.Descendants("Contacts").FirstOrDefault().Add(request.toXml());
                contacts.Save(localPath + "contacts.xml");
            }
            else
            {
                // Means contact should be exists
                XElement itemElement = query.FirstOrDefault();

               // itemElement.ReplaceWith(request.toXml());
                   
                /*contacts.Element("Contacts")
                      .Elements("DBContact")
                      .Where(x => (string)x.Attribute("ID") == (string)itemElement.Attribute("ID"))
                      .Remove();*/

                contacts.Save(localPath + "contacts.xml");
                    
                    //itemElement.ReplaceWith(request.toXml());

                    
                

                contacts.Save(localPath + "contacts.xml");
                

            }
           
        }

        private string CreateContentDirectory(string typeOfContent)
        {
            string localPath;
            // Set the path where so save the specific content from the given typeOfContent
            localPath = STORAGE_MAIM_PATH + typeOfContent + "\\";
            // Determine whether the directory exists according to the typeOfContent args
            if (!Directory.Exists(localPath + typeOfContent))
            {

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(localPath);

            }
            return localPath;
        }

    }
}
