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
    
        private BackgroundWorker _worker;
        private EventLog _eventlog;

        private const string PIPE_NAME = "Server-PC.IPSenderPipe";
        
        private const string EVENTLOG_SOURCE_NAME = "IPSenderSource";
        private const string EVENTLOG_NAME = "IPSenderLog";

        public SyncWorker(int delta)
        {
            // The constructor gets an int of delta - the time to wait between each messaging to server

            _delta = delta;

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
            IPSyncServiceReference.IPSyncClient client;
            PipeClient pipclient;

            while (true)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }

                // Create a new instance of a pipe client - to communicate between windows server and application
                client = new IPSyncServiceReference.IPSyncClient();

                // Create a new pipe to communicate with the application ui
                pipclient = new PipeClient();

                try
                {
                    // Send the IP address
                    retrivedIP = client.HelloWorld();
                    client.Close();
                    client = null;
                } 
                catch (TimeoutException exception)
                {
                    // Client timeout exception handling
                    _eventlog.WriteEntry(exception.GetType().ToString() + " " + exception.Message);
                    client.Abort();
                    this.Stop();
                }

                catch (CommunicationException exception)
                {
                    // Client communication exception handling
                    _eventlog.WriteEntry(exception.GetType().ToString() + " " + exception.Message);
                    client.Abort();
                    this.Stop();
                }

                try
                {
                    // Send IP address to the PC application using pipes
                    pipclient.Send(retrivedIP, PIPE_NAME);
                }
                catch (Exception ex)
                {
                    // Piping exception handling
                    _eventlog.WriteEntry(ex.Message);
                    client.Abort();
                    this.Stop();
                }

                // Wait delta seconds
                System.Threading.Thread.Sleep(_delta * 1000);
                 
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
