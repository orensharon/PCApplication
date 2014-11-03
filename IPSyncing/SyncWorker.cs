using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ServiceModel;

namespace IPSyncing
{
    
    class SyncWorker
    {
        private int _delta;
        private IPSyncServiceReference.IPSyncClient _client;
        private BackgroundWorker _worker;
        private EventLog _eventlog;

        private const string PIPE_NAME = "Server-PC.IPSenderPipe";
        
        private const string EVENTLOG_SOURCE_NAME = "IPSenderSource";
        private const string EVENTLOG_NAME = "IPSenderLog";

        public SyncWorker(int delta)
        {
            // The constructor gets an int of delta - the time to wait between each messaging to server

            _delta = delta;


            // Creating a new instance of client
            _client = new IPSyncServiceReference.IPSyncClient();

            // Create new custom log if dosent exist
            if (!EventLog.SourceExists(EVENTLOG_SOURCE_NAME))
                EventLog.CreateEventSource(EVENTLOG_SOURCE_NAME, EVENTLOG_NAME);

            // Specify the log source
            _eventlog = new EventLog();
            _eventlog.Source = EVENTLOG_SOURCE_NAME;
        }
        public void Start()
        {
            // Create a new instance of the background worker thread
            _worker = new BackgroundWorker();

            // Setting an event handler to the thread
            _worker.DoWork += new DoWorkEventHandler(Syncing);

            // Setting done event handler to the thread
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoneSyncing);
            _worker.ProgressChanged += new ProgressChangedEventHandler(InProgress);
            _worker.WorkerSupportsCancellation = true;


            // Start the background worker
            if (_worker.IsBusy == false)
                _worker.RunWorkerAsync();

        }
        private void Syncing(object sender, DoWorkEventArgs e)
        {
            // Syncing the server
            BackgroundWorker worker = sender as BackgroundWorker;
            string retrivedIP = null;

            while (true)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }

                try
                {
                    // Create a new instance of a pipe client - to communicate between windows server and application
                    PipeClient pipclient = new PipeClient();

                    retrivedIP = _client.HelloWorld();
                    pipclient.Send(retrivedIP, PIPE_NAME);


                    //_eventLog.WriteEntry("Recived IP: " + retrivedIP);

                    // Wait delta seconds
                    System.Threading.Thread.Sleep(_delta * 1000);
                }
                catch (Exception ex)
                {
                    // Writing error to the event log
                    _eventlog.WriteEntry(ex.Message);
                    
                    this.Stop();
                }
            }
        }

        public void Stop()
        {
            if (_worker.WorkerSupportsCancellation == true)
            {
                _worker.CancelAsync();
            }

            _eventlog.Close();


        }

        private void DoneSyncing(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void InProgress(object sender, ProgressChangedEventArgs e)
        {
            
        }
    }
}
