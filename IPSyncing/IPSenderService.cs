﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace IPSyncing
{
    public partial class IPSenderService : ServiceBase
    {
         private SyncWorker _syncer;

        private const string EVENTLOG_SOURCE_NAME = "IPSenderSource";
        private const string EVENTLOG_NAME = "IPSenderLog";

        public IPSenderService()
        {
          
            InitializeComponent();
           
            // Create new custom log if dosent exist
            if (!EventLog.SourceExists(EVENTLOG_SOURCE_NAME))
                EventLog.CreateEventSource(EVENTLOG_SOURCE_NAME, EVENTLOG_NAME);

            // Specify the log source
            eventLog.Source = EVENTLOG_SOURCE_NAME;

        }

        protected override void OnStart(string[] args)
        {
            // By starting the IPSender windows service - creating a new instance of IPSyncClient
            // And send it to backgrounder worker thread in type of SyncWorker
            string token;
            
            string logString = "Service started";

            // Read user id from args
            token = args[0];
            
            _syncer = new SyncWorker(120, token);

            // Start the background thread
            _syncer.Start();

            // Write to eventlog
            eventLog.WriteEntry(logString);
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            
            string logString = "Service stopped";
            try
            {
                _syncer.Stop();
            }
            catch (Exception ex)
            {
                logString = ex.Message;
            }

            // Write to eventlog
            eventLog.WriteEntry(logString);

            // Close the eventlog
            eventLog.Close();
        }

        public void test(string message)
        {
            eventLog.WriteEntry(message);
        }

        private void eventLog_EntryWritten(object sender, EntryWrittenEventArgs e)
        {

        }
    }
}
