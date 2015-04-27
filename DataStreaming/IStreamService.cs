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
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Upload")]
        string Upload(Stream stream);


        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare,
            UriTemplate = "/Upload/Contact")]
        string UploadContact(ContactRequest request);


    }


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

    public class InstantMenssenger
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    [DataContract]
    public class ContactRequest
    {
        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public List<Phone> Phones { get; set; }

        [DataMember]
        public List<Email> Emails { get; set; }

        [DataMember]
        public string PhotoURI { get; set; }

        [DataMember]
        public List<LivingAddress> Addresses { get; set; }

        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public Organization Organization { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public string TypeOfContent { get; set; }

        [DataMember]
        public List<InstantMenssenger> InstantMessengers { get; set; }

        public XElement toXml()
        {


            XElement doc;

           
            // Phones
            XElement phones = new XElement("Phones");
            foreach (Phone phone in Phones)
            {
                phones.Add(
                    new XElement("Phone", 
                    new XAttribute("Number", phone.Number),
                    new XAttribute("Type", phone.Type))
                );
            }

            // Emails
            XElement emails = new XElement("Emails");
            foreach (Email email in Emails)
            {
                emails.Add(
                    new XElement("Email",
                    new XAttribute("Address", email.Address),
                    new XAttribute("Type", email.Type))
                );
            }

            // Addresses
            XElement addresses = new XElement("Addresses");
            foreach (LivingAddress address in Addresses)
            {
                addresses.Add(
                    new XElement("Address",
                    new XAttribute("Address", address.Address),
                    new XAttribute("Type", address.Type))
                );
            }
            
            // Instant Messengers
            XElement instantMessengers = new XElement("InstantMessengers");
            foreach (InstantMenssenger im in InstantMessengers)
            {
                instantMessengers.Add(
                    new XElement("InstantMessenger",
                    new XAttribute("Name", im.Name),
                    new XAttribute("Type", im.Type))
                );
            }

            // Creating XML Entry for the new contact
            doc = new XElement(new XElement("Contact", new XAttribute("ID", ID),
                                new XElement("DisplayName",DisplayName),
                                phones, emails, addresses, InstantMessengers,
                                new XElement("PhotoURI",PhotoURI),
                                new XElement("Organization", new XElement("Company",Organization.Company), new XElement("Title", Organization.Title)),
                                new XElement("Notes",Notes)));
           

            Console.WriteLine(doc.ToString());
            return doc;
        }
    }

    


}
