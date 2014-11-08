using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCConsole
{
    class Program
    {
        AppNetworkListUser()
        {
            m_nlm = new NetworkListManager();
        }

        static void Main(string[] args)
        {
            AppNetworkListUser nlmUser = new AppNetworkListUser();
            Console.WriteLine("Is the machine connected to internet? " + 
                              nlmUser.NLM.IsConnectedToInternet.ToString());
            //List the connected networks. There are many other APIs 
            //can be called to get network information.
            IEnumNetworks Networks = 
              nlmUser.NLM.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED);
            foreach (INetwork item in Networks)
            {
                Console.WriteLine("Connected Network:" + item.GetName() );
            }
            nlmUser.AdviseforNetworklistManager();
            Console.WriteLine("Press any key and enter to finish the program");
            String temp; 
            temp = Console.ReadLine();
            nlmUser.UnAdviseforNetworklistManager();
                }
    }
}
