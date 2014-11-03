using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IPSender
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IPSendService" in both code and config file together.
    public class IPSendService : IIPSendService
    {
        public string DoWork()
        {
            IPSyncServiceReference.IPSyncClient client = new IPSyncServiceReference.IPSyncClient();
            string ret = client.HelloWorld();

            client.Close();
            return ret;
        }
    }
}
