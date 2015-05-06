using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStreaming.db
{
    class StoredContentBL
    {

        public void StoreContact(ContactRequest request)
        {
            StoredContentDAL storedContentDAL = new StoredContentDAL();
            storedContentDAL.StoreContact(request);
        }

        public void StorePhoto(string id, string filename)
        {
            StoredContentDAL storedContentDAL = new StoredContentDAL();
            storedContentDAL.StorePhoto(id, filename);
        }

        public ContactRequest GetContact(string id)
        {
            ContactRequest result;

            StoredContentDAL storedContentDAL = new StoredContentDAL();
            result = storedContentDAL.GetContact(id);

            return result;
        }

        public void GetPhoto(int id)
        {

        }
    }
}
