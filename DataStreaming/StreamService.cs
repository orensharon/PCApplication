
using DatabaseLinker;
using DataStreaming.db;
using DataStreaming.utils;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DataStreaming
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StreamService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class StreamService : IStreamService
    {

        static string STORAGE_MAIM_PATH = Application.StartupPath + @"\AppData\Contents\";

        static int m_Counter = 0;



        public string InserPhoto(Stream stream)
        {
            string hashedFileContent = "";
     


            // First we need to get the boundary from the header, this is sent
            // with the HTTP request. We can do that in WCF using the WebOperationConext:
            var type = WebOperationContext.Current.IncomingRequest.Headers["Content-Type"];
            var realContentHash = WebOperationContext.Current.IncomingRequest.Headers["Content-MD5"];
            var token = WebOperationContext.Current.IncomingRequest.Headers["Authorization"];

            // Now we want to strip the boundary out of the Content-Type, currently the string
            // looks like: "multipart/form-data; boundary=---------------------124123qase124"
            var boundary = type.Substring(type.IndexOf('=') + 1);

            // Now that we've got the boundary we can parse our multipart and use it as normal

            try
            {
                var parser = new MultipartFormDataParser(stream, boundary, Encoding.UTF8);

                // Get the parameters from the request body
                string ex_Id = parser.Parameters["Id"].Data;
                //string token = parser.Parameters["Token"].Data;
                string typeOfContent = parser.Parameters["TypeOfContent"].Data;

                string physicalAddress = parser.Parameters["PhysicalAddress"].Data;
                string createdTimeStamp = parser.Parameters["CreatedTimeStamp"].Data;
                string modifiedTimeStamp = parser.Parameters["ModifiedTimeStamp"].Data;
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


                // Get the files from the request body
                foreach (FilePart file in parser.Files)
                {
                    // File integrity verification using MD5
                    hashedFileContent = utils.MD5Checksum.GetMD5HashFromFile(file.Data);
                    Console.WriteLine(hashedFileContent);


                    // Check if file is damaged with the equation of the md-5 hash
                    if (!hashedFileContent.Equals(realContentHash))
                    {
                        SetResponseHttpStatus(HttpStatusCode.BadRequest);
                        return null;
                    }

                    
                    using (ContentContext db = new ContentContext())
                    {

                        // Make sure contact doesnt exist
                        if (db.Photos.FirstOrDefault(c => c.RemotePhotoId == photoId) == null)
                        {
                            Photo photo = new Photo();
                            photo.RemotePhotoId = photoId;
                            photo.FileName = file.FileName;
                            photo.DataCreated = createdTimeStamp;
                            photo.LastModified = modifiedTimeStamp;

                            // Check if owner exist
                            Owner owner = db.Owners.FirstOrDefault(o => o.PhysicalAddress.Equals(physicalAddress));

                            if (owner != null)
                            {
                                // Ownser exist
                                photo.Owner = owner;
                            }
                            else
                            {
                                owner = new Owner();
                                owner.PhysicalAddress = physicalAddress;
                                photo.Owner = owner;
                            }
                            
                            // Save the Image to DB and read coordinations from it
                            double? latitude, longitude;

                            using (Image img = Image.FromStream(file.Data))
                            {
                                latitude = GetLatitude(img);
                                longitude = GetLongitude(img);

                                photo.Latitude = latitude;
                                photo.Longitude = longitude;


                                using (Image flippedImage = FlipRotatePhoto(Image.FromStream(file.Data)))
                                {

                                 
                                    photo.PhotoData = new PhotoData();
                                    photo.PhotoData.Object = ConvertImageToByteArray(flippedImage, System.Drawing.Imaging.ImageFormat.Jpeg);

                                    //resize the image to the specified height and width
                                    using (var resized = ImageUtilities.ResizeImage(flippedImage, flippedImage.Width / 4, flippedImage.Height / 4))
                                    {
                                        //save the resized image as a jpeg with a quality of 90
                                        photo.PhotoData.Thumbnail = ConvertImageToByteArray(resized, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    }
                                }
                            }


                            if (latitude != null && longitude != null)
                            {
                                // Can read location
                                string location;
                                LocationResolver.ReverseGeoLoc(longitude, latitude , out location);
                                photo.GeoLocation = location;
                            }

                            db.Photos.Add(photo);

                            try
                            {
                                db.SaveChanges();
                                SetResponseHttpStatus(HttpStatusCode.Accepted);
                            }
                            catch (Exception e)
                            {
                                db.Dispose();
                                SetResponseHttpStatus(HttpStatusCode.Conflict);
                                return null;
                            }

                            // Save location coords and get location string from Google API
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Error handling with request - internal server error
                SetResponseHttpStatus(HttpStatusCode.InternalServerError);
                return null;
            }
            m_Counter++;
            
            Console.WriteLine("\n\n\n\n Counter: " + m_Counter + " Thread:" +  Thread.CurrentThread.ManagedThreadId.ToString() + "...\n\n");
            return hashedFileContent;

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
                    SetResponseHttpStatus(HttpStatusCode.BadRequest);
                    return null;
                }

                // Add contact to database
                using (ContentContext db = new ContentContext())
                {

                    // Make sure contact doesnt exist
                    if (db.Contacts.FirstOrDefault(c => c.Id == contactId) == null)
                    {
                        Contact contact = new Contact();
                        contact.RemoteContactId = contactId;
                        contact.DisplayName = request.DisplayName;

                        int photoId;
                        if (!Int32.TryParse(request.PhotoId, out photoId))
                        {
                            photoId = 0;
                        }

                        // contact.PhotoId = photoId;
                        contact.Notes = request.Notes;
                        contact.DateCreated = request.CreatedTimeStamp;
                        contact.LastModified = request.ModifiedTimeStamp;

                        // Add organiztion
                        if (request.Organization.Company != null || request.Organization.Title != null)
                        {
                            DatabaseLinker.Organization org = new DatabaseLinker.Organization();
                            org.Company = request.Organization.Company;
                            org.Title = request.Organization.Title;
                            contact.Organization = org;
                        }

                        // Check if owner exist
                        Owner owner;
                        owner = db.Owners.FirstOrDefault(o => o.PhysicalAddress.Equals(request.PhysicalAddress));

                        if (owner != null)
                        {
                            // Ownser exist
                            contact.Owner = owner;
                        }
                        else
                        {
                            // Owner dosent exist - add it
                            owner = new Owner();
                            owner.PhysicalAddress = request.PhysicalAddress;
                            contact.Owner = owner;
                        }

                        // Add phones, emails and addresses
                        request.Addresses.ForEach(n => contact.AddAddress(n.Address, n.Type));
                        request.Phones.ForEach(n => contact.AddPhone(n.Number, n.Type));
                        request.Emails.ForEach(n => contact.AddEmail(n.Address, n.Type));

                        // Saving the contact
                        db.Contacts.Add(contact);
                        try
                        {
                            db.SaveChanges();
                            SetResponseHttpStatus(HttpStatusCode.Accepted);
                        }
                        catch (Exception e)
                        {
                            // Error saving
                            db.Dispose();
                            SetResponseHttpStatus(HttpStatusCode.Conflict);
                            return null;
                        }
                    }
                }
                return realContentHash;
            }
            else
            {
                // Somehow request is null
                SetResponseHttpStatus(HttpStatusCode.BadRequest);
                return null;
            }
        }
        public string UpdateContact(ContactRequest request)
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
                    SetResponseHttpStatus(HttpStatusCode.BadRequest);
                    return null;
                }

                // Add contact to database
                using (ContentContext db = new ContentContext())
                {
                    String physicalAddress = request.PhysicalAddress;
                    
                    // Make sure contact exist
                    Contact contact = db.Contacts.FirstOrDefault
                        (c => c.RemoteContactId == contactId && c.Owner.PhysicalAddress.Equals(physicalAddress)
                    );

                    if (contact != null)
                    {
                        // Update the contact
                        contact.DisplayName = request.DisplayName;
                        contact.Notes = request.Notes;
                        contact.LastModified = request.ModifiedTimeStamp;

                        // Handling with organization
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
                            // Previuos info about organization exist
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
                        
                        // Remove saved phones, emails and addresses
                        db.Phones.RemoveRange(contact.Phones);
                        db.Emails.RemoveRange(contact.Emails);
                        db.Addresses.RemoveRange(contact.Addresses);

                        // Add new phones, emails and addresses
                        request.Addresses.ForEach(n => contact.AddAddress(n.Address, n.Type));
                        request.Phones.ForEach(n => contact.AddPhone(n.Number, n.Type));
                        request.Emails.ForEach(n => contact.AddEmail(n.Address, n.Type));

                        try
                        {
                            db.SaveChanges();
                            SetResponseHttpStatus(HttpStatusCode.Accepted);
                        }
                        catch (Exception e)
                        {
                            db.Dispose();
                            SetResponseHttpStatus(HttpStatusCode.Conflict);
                            return null;
                        }                        
                    }
                }

                return realContentHash;
            }
            else
            {
                // Somehow request is null
                SetResponseHttpStatus(HttpStatusCode.BadRequest);
                return null;
            }
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
                SetResponseHttpStatus(HttpStatusCode.Forbidden);
                return null;
            }


            List<PhotoResponse> result = new List<PhotoResponse>();

            // Get all ids of photos from data base
            using (ContentContext db = new ContentContext())
            {
                var photos = (from p
                                 in db.Photos
                              orderby p.LastModified descending
                              select p);
                if (photos != null)
                {
                    result = photos.Select(response => new PhotoResponse()
                    {
                        Id = response.Id.ToString(),
                        DateCreated = response.DataCreated,
                        LastModified = response.LastModified,
                        GeoLocation = response.GeoLocation,
                        //OnwerPhysicalAddress = response.Owner.PhysicalAddress

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
                SetResponseHttpStatus(HttpStatusCode.BadRequest);
                return null;
            }



            int length = 0;
            MemoryStream stream;

            // Get all ids of photos from data base
            using (ContentContext db = new ContentContext())
            {
                Photo photo = db.Photos.FirstOrDefault(p => p.Id == photoId);
                if (photo != null)
                {
                    filename = photo.FileName;

                    Console.WriteLine("get photo: " + id);

                    try
                    {
                        stream = new MemoryStream(photo.PhotoData.Thumbnail);
                        length = photo.PhotoData.Thumbnail.Length;
                        
                    }
                    catch
                    {
                        stream = null;
                        // Error with stream
                        SetResponseHttpStatus(HttpStatusCode.InternalServerError);
                    }

                }
                else
                {
                    // Cant find image
                    stream = null;
                    SetResponseHttpStatus(HttpStatusCode.InternalServerError);

                }

            }

            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpg";
            WebOperationContext.Current.OutgoingResponse.ContentLength = length;
            return stream;
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
                                orderby c.DisplayName ascending
                                select c).ToList();
                foreach (Contact contact in contacts)
                {
                    // Create request contact from entity contact

                    ContactRequest item = new ContactRequest();
                    item.Id = contact.Id.ToString();
                    item.DisplayName = contact.DisplayName;
                    item.Notes = contact.Notes;
                    item.PhotoId = "todo";
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


                    if (contact.Organization != null)
                    {
                        item.Organization = new Organization();
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
        private Image FlipRotatePhoto(Image img)
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

            return img;
            /*ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID 
            // for the Quality parameter category.
            System.Drawing.Imaging.Encoder myEncoder =
                System.Drawing.Imaging.Encoder.Quality;

            EncoderParameters myEncoderParameters = new EncoderParameters(1);

            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 75L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            img.Save(localPath + file.FileName, jpgEncoder, myEncoderParameters);

            CreateThumbnail(600, localPath, file.FileName, img);*/
        }
        private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,
                                       System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }

       


        // Read geo coordinations from Exif
        private static double? GetLatitude(Image targetImg)
        {
            try
            {
                //Property Item 0x0001 - PropertyTagGpsLatitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(1);
                //Property Item 0x0002 - PropertyTagGpsLatitude
                PropertyItem propItemLat = targetImg.GetPropertyItem(2);
                return ExifGpsToDouble(propItemRef, propItemLat);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        private static double? GetLongitude(Image targetImg)
        {
            try
            {
                ///Property Item 0x0003 - PropertyTagGpsLongitudeRef
                PropertyItem propItemRef = targetImg.GetPropertyItem(3);
                //Property Item 0x0004 - PropertyTagGpsLongitude
                PropertyItem propItemLong = targetImg.GetPropertyItem(4);
                return ExifGpsToDouble(propItemRef, propItemLong);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }
        private static double ExifGpsToDouble(PropertyItem propItemRef, PropertyItem propItem)
        {
            double degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            double degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            double degrees = degreesNumerator / (double)degreesDenominator;

            double minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            double minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            double minutes = minutesNumerator / (double)minutesDenominator;

            double secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            double secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            double seconds = secondsNumerator / (double)secondsDenominator;


            double coorditate = degrees + (minutes / 60d) + (seconds / 3600d);
            string gpsRef = System.Text.Encoding.ASCII.GetString(new byte[1] { propItemRef.Value[0] }); //N, S, E, or W
            if (gpsRef == "S" || gpsRef == "W")
                coorditate = coorditate * -1;
            return coorditate;
        }


    }
}
