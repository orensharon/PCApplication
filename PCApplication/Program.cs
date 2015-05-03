using PCApplication.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemTrayIcon.PCApplication;

namespace PCApplication
{
    static class Program
    {

        // Delegate field member. using to pass the IP back from the server to the pc application
       // public delegate void NewMessageDelegate(string NewMessage);

        private const string PIPE_NAME = "Server-PC.IPSenderPipe";
        private const string SERVICE_NAME = "IPSender";

        public static SettingsForm _SettingDialogInstance;
        public static ServiceHost _StreamerHost;

        [STAThread]
        static void Main()
        {
            if (!SingleInstance.Start()) { return; }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            try
            {
                // Adding program exit handler to stop IPSync windows service
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

                // Create a named pipe server to send requests to the windows service (as client)
                PipeServer server = new PipeServer();

                // Creating event for income messages and starts listening to the pipe
                server.PipeMessage += new DelegateMessage(PipesMessageHandler);
                server.Listen(PIPE_NAME);

                

                // Clear previous log file
                SystemStatusLog.ClearSystemStatusLog();

                SystemSession systemSession = new SystemSession();
                
                // Running the application
                var applicationContext = new CustomApplicationContext();

                
                // Start sync service if user is logged in
                if (systemSession.getLoginState() == true)
                {

                    // Set the status icon to coneecting
                    _SettingDialogInstance.UpdateConnectionStatusIcon(2);

                    // Start the IP Syncing service
                    ProgramBL.StartIPSyncService(systemSession.getUserToken());

                }
                
                Application.Run(applicationContext);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Program Terminated Unexpectedly",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SingleInstance.Stop();

        }

        static void OnProcessExit(object sender, EventArgs e)
        {
            SystemSession systemSession = new SystemSession();

            if (systemSession.getLoginState() == true)
            {
                ProgramBL.StopIPSyncService();
                ProgramBL.StopServer();
            }

        }

        private static void PipesMessageHandler(string message)
        {
            // Inconimg message from named pipe handler

            SystemSession systemSession = new SystemSession();
            string trimmedMessage;

            trimmedMessage = message.TrimEnd(new char[] { '\0' });
            try
            {

                // Means the ip sync request faild
                if (trimmedMessage.Equals(String.Empty))
                {
                    ProgramBL.LogoutAttempt();

                }
                else
                {

                    // IP is ok
                    systemSession.setIPAddress(trimmedMessage);
                    Console.WriteLine(trimmedMessage);
                    _SettingDialogInstance.UpdateUI();
                }
                
            }
            catch (Exception ex)
            {
                // Means Windows service in not avaliable 

                ProgramBL.LogoutAttempt();
                Console.WriteLine(ex.Message);
            }

        }
    }
}
