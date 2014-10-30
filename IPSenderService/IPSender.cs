using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IPSenderService
{
    partial class IPSender : ServiceBase
    {
        public IPSender()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // By starting the IPSender windows service - creating a new instance of IPSyncClient
            // And send it to backgrounder worker thread in type of SyncWorker

            
            SyncWorker s = new SyncWorker(1);

            // Start the background thread
            s.Start();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
