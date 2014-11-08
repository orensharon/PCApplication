using NETWORKLIST;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace IPSyncing
{
    class NetworkNotifier : INetworkListManagerEvents
    {
        private int m_cookie = 0;
        private IConnectionPoint m_icp;
        private INetworkListManager m_nlm;
        private EventLog _eventlog;

        private const string EVENTLOG_SOURCE_NAME = "IPSenderSource";
        private const string EVENTLOG_NAME = "IPSenderLog";
        private const string PIPE_NAME = "Server-PC.IPSenderPipe";

        public NetworkNotifier()
        {
            m_nlm = new NetworkListManager();

            // Create new custom log if dosent exist
            if (!EventLog.SourceExists(EVENTLOG_SOURCE_NAME))
                EventLog.CreateEventSource(EVENTLOG_SOURCE_NAME, EVENTLOG_NAME);

            // Specify the log source
            _eventlog = new EventLog();
            _eventlog.Source = EVENTLOG_SOURCE_NAME;
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
            //_eventlog.WriteEntry("NetworkList just informed the connectivity change. The new connectivity is:");

            if (newConnectivity == NLM_CONNECTIVITY.NLM_CONNECTIVITY_DISCONNECTED)
            {
                //_eventlog.WriteEntry("The machine is disconnected from Network");
            }
            if (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) != 0)
            {
                
                //System.Threading.Thread.Sleep(30000);
                _eventlog.WriteEntry("The machine is connected to internet with IPv4 capability ");
                IPSyncServiceReference.IPSyncClient client = new IPSyncServiceReference.IPSyncClient();
                string retrivedIP = null;

                // Create a new instance of a pipe client - to communicate between windows server and application
                PipeClient pipclient = new PipeClient();

                retrivedIP = client.HelloWorld();
                client.Close();
                client = null;

                pipclient.Send(retrivedIP, PIPE_NAME);
            }
            if (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV6_INTERNET) != 0)
            {
                //_eventlog.WriteEntry("The machine is connected to internet with IPv6 capability ");
            }
            if ((((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_INTERNET) == 0)
                && (((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV6_INTERNET) == 0))
            {
                _eventlog.WriteEntry("The machine is not connected to internet yet ");
            }
        }

        public void AdviseforNetworklistManager()
        {
            //_eventlog.WriteEntry("Subscribing the INetworkListManagerEvents");
            IConnectionPointContainer icpc = (IConnectionPointContainer)m_nlm;
            //similar event subscription can be used for INetworkEvents and INetworkConnectionEvents
            Guid tempGuid = typeof(INetworkListManagerEvents).GUID;
            icpc.FindConnectionPoint(ref tempGuid, out m_icp);
            m_icp.Advise(this, out m_cookie);
        }

        public void UnAdviseforNetworklistManager()
        {
            //_eventlog.WriteEntry("Unsubscribing the INetworkListManagerEvents");
            m_icp.Unadvise(m_cookie);
        }




        public void StartUp()
        {
            IPSyncServiceReference.IPSyncClient client = new IPSyncServiceReference.IPSyncClient();
            PipeClient pipclient = new PipeClient();

            try
            {
                string retrivedIP = client.HelloWorld();
                client.Close();
                client = null;

                pipclient.Send(retrivedIP, PIPE_NAME);
            }
            catch (Exception ex)
            {
                _eventlog.WriteEntry(ex.Message);
            }
        }
    }
}
