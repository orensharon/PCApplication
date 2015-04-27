using HttpMultipartParser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public string Upload(Stream stream)
        {
            string hashedFileContent = "";
            string localPath;



            // First we need to get the boundary from the header, this is sent
            // with the HTTP request. We can do that in WCF using the WebOperationConext:
            var type = WebOperationContext.Current.IncomingRequest.Headers["Content-Type"];

            // Now we want to strip the boundary out of the Content-Type, currently the string
            // looks like: "multipart/form-data; boundary=---------------------124123qase124"
            var boundary = type.Substring(type.IndexOf('=') + 1);

            // Now that we've got the boundary we can parse our multipart and use it as normal
            var parser = new MultipartFormDataParser(stream, boundary, Encoding.UTF8);

            // Get the parameters from the request body
            string token = parser.Parameters["Token"].Data;
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
                using (System.IO.FileStream output = new System.IO.FileStream(localPath + file.FileName, FileMode.Create))
                {
                    file.Data.CopyTo(output);

                    // File integrity verification using MD5
                    hashedFileContent = utils.MD5Checksum.GetMD5Hash(localPath + file.FileName);
                    Console.WriteLine(hashedFileContent);
                }

            }

            

            return hashedFileContent;

        }

        public string UploadContact(ContactRequest request)
        {


            if (request != null && request.Token != null)
            {
                // Decode the user id from the token
                var payLoad = JWTManager.DecodeToken(request.Token) as IDictionary<string, object>;

                // Authenticate the request
                if (payLoad == null)
                {
                    // Authentication error
                    SetResponseHttpStatus(HttpStatusCode.Forbidden);
                    return null;
                }

                // TODO: MD5 hash check


                //string hashedFileContent = utils.MD5Checksum.StringMD5Hash(request.ToString());
                //Console.WriteLine(OperationContext.Current.RequestContext.RequestMessage.ToString() + ", " + hashedFileContent);

                HandleSaveContact(request);
                return "ok";
            }

            SetResponseHttpStatus(HttpStatusCode.InternalServerError);
            return null;
        }




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
            var query = from c in contacts.Descendants("Contact")
                        where ((c.Attribute("ID").Value.Trim().Equals(request.ID)))
                        select c;

            if (query.Count() == 0)
            {
                // Means contact dosent exist

                // Append new content to xml
                contacts.Descendants("Contacts").FirstOrDefault().Add(request.toXml());
                contacts.Save(localPath + "contacts.xml");
            }
            else
            {
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
