using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace IPSenderService
{
    
    class SyncWorker
    {
        private int _delta;
        private IPSyncServiceReference.IPSyncClient _client;
        private BackgroundWorker _worker;

        public SyncWorker(int delta)
        {
            // The constructor gets an int of delta - the time to wait between each messaging to server

            _delta = delta;

            // Creating a new instance of client
            _client = new IPSyncServiceReference.IPSyncClient();
        }
        public void Start()
        {
            // Create a new instance of the background worker thread
            _worker = new BackgroundWorker();

            // Setting an event handler to the thread
            _worker.DoWork += new DoWorkEventHandler(Syncing);

            // Setting done event handler to the thread
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoneSyncing);
            _worker.WorkerSupportsCancellation = true;


            // Start the background worker
            if (_worker.IsBusy == false)
                _worker.RunWorkerAsync();

        }
        private void Syncing(object sender, DoWorkEventArgs e)
        {
            // Syncing the server
            BackgroundWorker worker = sender as BackgroundWorker;
                        
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
                    pipclient.Send(_client.HelloWorld(), "Server-PC.IPSyncPipe");
                    

                    // Wait delta seconds
                    System.Threading.Thread.Sleep(_delta * 1000);
                }
                catch
                {

                    // For time-out error
                }
            }
        }

        public void Stop()
        {
            if (_worker.WorkerSupportsCancellation == true)
            {
                _worker.CancelAsync();
            }
        }

        private void DoneSyncing(object sender, RunWorkerCompletedEventArgs e)
        {
            // TODO

        }
    }
}
