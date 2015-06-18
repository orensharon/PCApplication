using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DataStreaming
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IStreamService" in both code and config file together.
    [ServiceContract]
    public interface IStreamService
    {

        #region upload content

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Photo/Insert")]
        string InserPhoto(Stream stream);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/Photo/Get")]
        List<PhotoResponse> GetListOfPhotos();

        [OperationContract]
        [WebGet(
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Photo/Get/{id}")]
        Stream GetPhoto(string id);





        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Contact/Insert")]
        string InsertContact(ContactRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Contact/Update")]
        string UpdateContact(ContactRequest request);

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped,
            UriTemplate = "/Contact/Get")]
        List<ContactRequest> GetContacts();

        #endregion upload content
       
       
    }


    #region photo

    [DataContract]
    public class PhotoResponse
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string DateCreated { get; set; }

        [DataMember]
        public string LastModified { get; set; }

        [DataMember]
        public string OnwerPhysicalAddress { get; set; }

        [DataMember]
        public string GeoLocation { get; set; }

    }


    #endregion photo

    #region contact
    public class Phone
    {
        public string Number { get; set; }
        public string Type { get; set; }
    }


    public class Email
    {
        public string Type { get; set; }
        public string Address { get; set; }

    }


    public class LivingAddress
    {
        public string Type { get; set; }
        public string Address { get; set; }

    }

    public class Organization
    {
        public string Company { get; set; }
        public string Title { get; set; }

    }


    [DataContract]
    public class ContactRequest
    {
        [DataMember]
        public string Notes { get; set;  }

        [DataMember]
        public List<Phone> Phones { get; set; }

        [DataMember]
        public List<Email> Emails { get; set; }

        [DataMember]
        public string PhotoId { get; set; }

        [DataMember]
        public List<LivingAddress> Addresses { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public Organization Organization { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string TypeOfContent { get; set; }

        [DataMember]
        public string PhysicalAddress { get; set; }

        [DataMember]
        public string CreatedTimeStamp { get; set; }

        [DataMember]
        public string ModifiedTimeStamp { get; set; }

    }

#endregion contact


}
