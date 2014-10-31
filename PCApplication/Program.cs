using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCApplication
{
    static class Program
    {

        // Delegate field member. using to pass the IP back from the server to the pc application
        public delegate void NewMessageDelegate(string NewMessage);

        private const string PIPE_NAME = "Server-PC.IPSenderPipe";
        private const string SERVICE_NAME = "IPSender";

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Adding program exit handler to stop IPSync windows service
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            // Start the IPSync Windows serivce
            StartIPSyncService();

            // Create a named pipe server to send requests to the windows service (as client)
            PipeServer server = new PipeServer();

            // Creating event for income messages and starts listening to the pipe
            server.PipeMessage += new DelegateMessage(PipesMessageHandler);
            server.Listen(PIPE_NAME);

            // Show the system tray icon.
            using (SystemTrayIcon  pi = new SystemTrayIcon())
            {
                pi.Display();
                
                // Make sure the application runs!
                Application.Run();
            }
        }

        private static void StartIPSyncService()
        {
            // Starting the IPSync service
            ServiceController service = new ServiceController(SERVICE_NAME);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(1000);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                // TODO:
                // Add exception to log
            }
        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            // Stoping the IPSync service
            ServiceController service = new ServiceController(SERVICE_NAME);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(1000);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                
            }
            catch
            {
                // TODO:
                // Add exception to log
            }

            // Final disposing of the system tray icon
            using (SystemTrayIcon pi = new SystemTrayIcon())
            {
                pi.Dispose();
            }
        }

        private static void PipesMessageHandler(string message)
        {
            // Inconimg message from named pipe handler

            try
            {
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                // TODO: Add exception to log
                Console.WriteLine(ex.Message);
            }

        }
    }
}
