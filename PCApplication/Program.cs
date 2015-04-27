using PCApplication.AccountSession;
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

                    // Start the host server
                    ProgramBL.StartServer();

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

        /*
        public static void StartIPSyncService(string token)
        {
            // Starting the IPSync service
            ServiceController service = new ServiceController(SERVICE_NAME);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(1000);

                string[] args = new string[1];
                args[0] = token;

                service.Start(args);
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch
            {
                // TODO:
                // Add exception to log
            }
        }

        public static void StopIPSyncService()
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
        }

        


        public static async Task LoginAttemptASync(Action<string> callback)
        {
            string message = null;
            UserLoginServiceReference.UserLoginClient loginClient;
            UserLoginServiceReference.LoginResponse response;
            UserLoginServiceReference.LoginRequest request;

            SettingsSession settingsSession = new SettingsSession();
            SystemSession systemSession = new SystemSession();

            //int userID = 0;

            request = new UserLoginServiceReference.LoginRequest();
            request.Username = settingsSession.getUserName();
            request.Password = settingsSession.getPassword();

            response = null;

            // Connect to server to log in
            loginClient = new UserLoginServiceReference.UserLoginClient();
            try
            {
                var task = loginClient.LoginAttemptAsync(request);
                response = await task;
                loginClient.Close();
                loginClient = null;
            }
            catch (System.ServiceProcess.TimeoutException exception)
            {
                // Client timeout exception handling
                loginClient.Abort();
                message = exception.Message;
            }

            catch (CommunicationException exception)
            {
                // Client communication exception handling
                loginClient.Abort();
                
                if (exception.InnerException is WebException)
                {
                    string statusCode;

                    WebException webException = exception.InnerException as WebException;

                    if (webException.Status == WebExceptionStatus.ConnectFailure)
                    {
                        // Means host not found
                        statusCode = webException.Status.ToString();
                    }
                    else if (webException.Status == WebExceptionStatus.NameResolutionFailure)
                    {
                        // Means could not be resolved
                        statusCode = webException.Status.ToString();
                    }
                    else
                    {
                        // Other request errors

                        HttpWebResponse errorResponse = webException.Response as HttpWebResponse;
                        statusCode = errorResponse.StatusCode.ToString();
                    }
                    switch (statusCode)
                    {
                        case "BadRequest":
                            message = "Username or password are incorrect.\nPlease try again.";
                            break;
                        case "ConnectFailure":
                            message = "Unable to reach server\nPlease try again later.";
                            break;
                        case "NameResolutionFailure":
                            message = "Request could not be resolved";
                            break;
                        default:
                            message = statusCode;
                            break;
                    }
                }

            }
            catch (Exception exception)
            {
                // unspecific exception handling
                loginClient.Abort();
                message = exception.Message;
            }

            // Check if login was success
            if (response!= null && response.Token != null)
            {
                // Save settings for logged-in user
                systemSession.Login();
                systemSession.setUserToken(response.Token);
               
                
                // Start the IP syncing service
                Program.StartIPSyncService(systemSession.getUserToken());


                // Update status log
                SystemStatusLog.WriteToSystemStatusLog(Constants.STATUS_KEY_LOGGED);
            }
            else
            {
              //  message = "some error";
                
                systemSession.Logout();


            }
            callback(message);
        }


        public static void LogoutAttempt()
        {
            SettingsSession settingsSession = new SettingsSession();
            SystemSession systemSession = new SystemSession();

            // Update status log
            SystemStatusLog.WriteToSystemStatusLog(Constants.STATUS_KEY_LOGGED_OUT);
            
            StopIPSyncService();
            systemSession.Logout();
            systemSession.setUserToken(null);
            settingsSession.setServerState(false);

        }
 */

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
                    //_SettingDialogInstance.UpdateConnectionStatusIcon(0);
                    systemSession.setIPAddress(trimmedMessage);
                    Console.WriteLine(trimmedMessage);
                }
               // _SettingDialogInstance._IsConnecting = false;
                _SettingDialogInstance.UpdateUI();
            }
            catch (Exception ex)
            {
                // TODO: Add exception to log
                Console.WriteLine(ex.Message);
            }

        }
    }
}
