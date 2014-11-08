using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NETWORKLIST;

namespace NetworkListSample
{
    class AppNetworkListUser : INetworkListManagerEvents
    {
        private int m_cookie = 0;
        private IConnectionPoint m_icp;
        private INetworkListManager m_nlm;

        AppNetworkListUser()
        {
            m_nlm = new NetworkListManager();
        }
        public INetworkListManager NLM
        {
            get
            {
                return m_nlm;
            }
        }

        public void ConnectivityChanged(NLM_CONNECTIVITY newConnectivity)
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("NetworkList just informed the connectivity change. The new connectivity is:");
            if (newConnectivity == NLM_CONNECTIVITY.NLM_CONNECTIVITY_DISCONNECTED)
            {
                Console.WriteLine("The machine is disconnected from Network");
            }
            if (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) != 0)
            {
                Console.WriteLine("The machine is connected to internet with IPv4 capability ");
            }
            if (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV6_INTERNET) != 0)
            {
                Console.WriteLine("The machine is connected to internet with IPv6 capability ");
            }
            if ((((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) == 0)
                && (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV6_INTERNET) == 0))
            {
                Console.WriteLine("The machine is not connected to internet yet ");
            }
        }

        public void AdviseforNetworklistManager()
        {
            Console.WriteLine("Subscribing the INetworkListManagerEvents");
            IConnectionPointContainer icpc = (IConnectionPointContainer)m_nlm;
            //similar event subscription can be used for INetworkEvents and INetworkConnectionEvents
            Guid tempGuid = typeof(INetworkListManagerEvents).GUID;
            icpc.FindConnectionPoint(ref tempGuid, out m_icp);
            m_icp.Advise(this, out m_cookie);
        }

        public void UnAdviseforNetworklistManager()
        {
            Console.WriteLine("Unsubscribing the INetworkListManagerEvents");
            m_icp.Unadvise(m_cookie);
        }
        static void Main(string[] args)
        {

            AppNetworkListUser nlmUser = new AppNetworkListUser();
            Console.WriteLine("Is the machine connected to internet? " + nlmUser.NLM.IsConnectedToInternet.ToString());
            //List the connected networks. There are many other APIs can be called to get network information.
            IEnumNetworks Networks = nlmUser.NLM.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_CONNECTED);
            foreach (INetwork item in Networks)
            {
                Console.WriteLine("Connected Network:" + item.GetName());
            }
            nlmUser.AdviseforNetworklistManager();

            Console.WriteLine("Press any key and enter to finish the program");
            String temp;
            temp = Console.ReadLine();
            nlmUser.UnAdviseforNetworklistManager();
        }
    }
}
