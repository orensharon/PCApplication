
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


        private static readonly DateTime Jan1st1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static long CurrentTimeMillis()
        {
            return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
        }


        public string InserPhoto(Stream stream)
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
            string ex_Id = parser.Parameters["Id"].Data;
            //string token = parser.Parameters["Token"].Data;
            string typeOfContent = parser.Parameters["TypeOfContent"].Data;

            int photoId;

            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(token) as IDictionary<string, object>;

            // Authenticate the request
            if (payLoad == null)
            {
                // Authentication error
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }


            if (!Int32.TryParse(ex_Id, out photoId))
            {
                // Error getting the id of the content
                SetResponseHttpStatus(HttpStatusCode.BadRequest);
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
                }

                using (ContentContext db = new ContentContext())
                {

                    // Make sure contact doesnt exist
                    if (db.Photos.FirstOrDefault(c => c.Id == photoId) == null)
                    {
                        Photo photo = new Photo();
                        photo.Id = photoId;
                        photo.FileName = file.FileName;
                        photo.DataCreated = CurrentTimeMillis();
                        photo.LastModified = photo.DataCreated;
                        db.Photos.Add(photo);
                        db.SaveChanges();
                    }
                }
               

            }

            return hashedFileContent;

        }

        public List<PhotoResponse> GetListOfPhotos()
        {

            var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(authToken) as IDictionary<string, object>;

            // Authenticate the request
            if (payLoad == null)
            {
                // Authentication error
                //SetResponseHttpStatus(HttpStatusCode.Forbidden);
                //return null;
            }


            List<PhotoResponse> result = new List<PhotoResponse>();

            // Get all ids of photos from data base
            using (ContentContext db = new ContentContext())
            {
                var photos = (from p
                                 in db.Photos
                                select p);
                if (photos != null)
                {
                    result = photos.Select(response => new PhotoResponse()
                    {
                        Id = response.Id.ToString(),
                        DateCreated = response.DataCreated,
                        LastModified = response.LastModified
                    }).ToList();
                }
            }

            return result;
        }

        public Stream GetPhoto(string id)
        {
            string filename;
            string downloadFilePath = "";
            int photoId;

            downloadFilePath = STORAGE_MAIM_PATH + @"Photo";

             var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(authToken) as IDictionary<string, object>;

            // Authenticate the request
            if (payLoad == null)
            {
                // Authentication error
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }

            if (!Int32.TryParse(id, out photoId))
            {
                // Error getting the id of the content
                //SetResponseHttpStatus(HttpStatusCode.BadRequest);
                //return null;
            }

            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpg";

            // Get all ids of photos from data base
            using (ContentContext db = new ContentContext())
            {
                Photo photo = db.Photos.FirstOrDefault(p => p.Id == photoId);
                if (photo != null)
                {
                    filename = photo.FileName;
                }
                else
                {
                    // Cant fint image
                    SetResponseHttpStatus(HttpStatusCode.BadRequest);
                    return null;
                }

            }

            Console.WriteLine("get photo: " + id);


            FileStream f = new FileStream(downloadFilePath + "\\small_" + filename, FileMode.Open);
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




        public string InsertContact(ContactRequest request)
        {
            var realContentHash = WebOperationContext.Current.IncomingRequest.Headers["Content-MD5"];
            var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            int contactId;

            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(authToken) as IDictionary<string, object>;

            // Authenticate the request
            if (payLoad == null)
            {
                // Authentication error
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }

            if (!Int32.TryParse(request.Id, out contactId))
            {
                // Error getting the id of the content
                SetResponseHttpStatus(HttpStatusCode.BadRequest);
                return null;
            }

            if (request != null)
            {

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

                // Add contact to database
                using (ContentContext db = new ContentContext())
                {

                    // Make sure contact doesnt exist
                    if (db.Contacts.FirstOrDefault(c => c.Id == contactId) == null)
                    {
                        Contact contact = new Contact();
                        contact.Id = contactId;
                        contact.DisplayName = request.DisplayName;
                        contact.Notes = request.Notes;
                        contact.DateCreated = CurrentTimeMillis();
                        contact.LastModified = contact.DateCreated;

                        DatabaseLinker.Organization org = new DatabaseLinker.Organization();
                        org.Company = request.Organization.Company;
                        org.Title = request.Organization.Title;
                        contact.Organization = org;

                        request.Addresses.ForEach(n => contact.AddAddress(n.Address, n.Type));
                        request.Phones.ForEach(n => contact.AddPhone(n.Number, n.Type));
                        request.Emails.ForEach(n => contact.AddEmail(n.Address, n.Type));
                        request.InstantMessengers.ForEach(n => contact.AddInstantMessenger(n.Name, n.Type));


                        db.Contacts.Add(contact);
                        db.SaveChanges();

                        SetResponseHttpStatus(HttpStatusCode.Accepted);
                    }
                }
                return realContentHash;
            }

            SetResponseHttpStatus(HttpStatusCode.BadRequest);
            return null;
        }

        public string UpdateContact(ContactRequest request)
        {
            var realContentHash = WebOperationContext.Current.IncomingRequest.Headers["Content-MD5"];
            var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            int contactId;

            if (request != null && Int32.TryParse(request.Id, out contactId))
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

                // Add contact to database
                using (ContentContext db = new ContentContext())
                {

                    // Make sure contact exist
                    Contact contact = db.Contacts.FirstOrDefault(c => c.Id == contactId);
                    if (contact != null)
                    {
                        // Update the contact
                        contact.DisplayName = request.DisplayName;
                        contact.Notes = request.Notes;
                        contact.LastModified = CurrentTimeMillis();

                        DatabaseLinker.Organization organization = contact.Organization;
                        if (organization == null)
                        {
                            // No previuos info about organization exist
                            organization = new DatabaseLinker.Organization();
                            organization.Company = request.Organization.Company;
                            organization.Title = request.Organization.Title;
                            contact.Organization = organization;
                        }
                        else
                        {
                            if (request.Organization.Title == null && request.Organization.Company == null)
                            {
                                // The user delete the organization info
                                db.Organizations.Remove(contact.Organization);

                            }
                            else
                            {
                                // Simple edit the exist organization
                                organization.Company = request.Organization.Company;
                                organization.Title = request.Organization.Title;   
                            }
                        }

                        db.Phones.RemoveRange(contact.Phones);
                        db.Emails.RemoveRange(contact.Emails);
                        db.Addresses.RemoveRange(contact.Addresses);
                        db.InstantMenssengers.RemoveRange(contact.InstantMenssengers);

                        request.Addresses.ForEach(n => contact.AddAddress(n.Address, n.Type));
                        request.Phones.ForEach(n => contact.AddPhone(n.Number, n.Type));
                        request.Emails.ForEach(n => contact.AddEmail(n.Address, n.Type));
                        request.InstantMessengers.ForEach(n => contact.AddInstantMessenger(n.Name, n.Type));

                        db.SaveChanges();

                        SetResponseHttpStatus(HttpStatusCode.Accepted);

                        
                    }
                }

                return realContentHash;
            }

            SetResponseHttpStatus(HttpStatusCode.InternalServerError);
            return null;
        }

        public List<ContactRequest> GetContacts() 
        {
            List<ContactRequest> result;


            var authToken = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];
            // Decode the user id from the token
            var payLoad = JWTManager.DecodeToken(authToken) as IDictionary<string, object>;

            // Authenticate the request
            if (payLoad == null)
            {
                // Authentication error
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }

            // Get all ids of contatcs from data base
            result = new List<ContactRequest>();
            using (ContentContext db = new ContentContext())
            {
                var contacts = (from c
                                 in db.Contacts
                                select c).ToList();
                foreach (Contact contact in contacts)
                {
                    // Create request contact from entity contact

                    ContactRequest item = new ContactRequest();
                    item.Id = contact.Id.ToString();
                    item.DisplayName = contact.DisplayName;
                    item.Notes = contact.Notes;
                    item.PhotoURI = "todo";
                    item.TypeOfContent = "Contact";
                    item.Phones = contact.Phones.Select(p => new Phone()
                    {
                            Number = p.Number ,
                            Type = p.Type.ToString() }).ToList();

                    item.Emails = contact.Emails.Select(e => new Email()
                    {
                        Address = e.Address,
                        Type = e.Type.ToString()
                    }).ToList();

                    item.Addresses = contact.Addresses.Select(a => new LivingAddress()
                    {
                        Address = a.LivingAddress,
                        Type = a.Type.ToString()
                    }).ToList();

                    item.InstantMessengers = contact.InstantMenssengers.Select(im => new InstantMenssenger()
                    {
                        Name = im.Name,
                        Type = im.Type.ToString()
                    }).ToList();

                    if (item.Organization != null)
                    {
                        item.Organization.Company = contact.Organization.Company;
                        item.Organization.Title = contact.Organization.Title;
                    }

                    result.Add(item);
                }

            }
            return result;
        }




        // Private functions

        private void SetResponseHttpStatus(HttpStatusCode statusCode)
        {
            var context = WebOperationContext.Current;
            context.OutgoingResponse.StatusCode = statusCode;
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

            CreateThumbnail(400, localPath, file.FileName, img);
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
                if (width == 400)
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


    }
}
