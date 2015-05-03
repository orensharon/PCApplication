using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using PCApplication.Sessions;

namespace PCApplication
{
    public class ProgramBL
    {
        private const string PIPE_NAME = "Server-PC.IPSenderPipe";
        private const string SERVICE_NAME = "IPSender";


        public static async Task LoginAttemptASync(Action<string> callback)
        {
            string message = null;
            UserLoginServiceReference.UserLoginClient loginClient;
            UserLoginServiceReference.LoginResponse response;
            UserLoginServiceReference.LoginRequest request;

           
            SystemSession systemSession = new SystemSession();

            //int userID = 0;

            request = new UserLoginServiceReference.LoginRequest();
            request.Username = systemSession.getUserName();
            request.Password = systemSession.getPassword();

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
            if (response != null && response.Token != null)
            {
                // Save settings for logged-in user
                systemSession.Login();
                systemSession.setUserToken(response.Token);


                // Start the IP syncing service
                StartIPSyncService(systemSession.getUserToken());

                // Start the hosting server service
                //StartServer();

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
            SystemSession systemSession = new SystemSession();

            // Update status log
            SystemStatusLog.WriteToSystemStatusLog(Constants.STATUS_KEY_LOGGED_OUT);

            StopIPSyncService();
            StopServer();
            systemSession.Logout();
            systemSession.setUserToken(null);
            systemSession.setServerState(false);

            Program._SettingDialogInstance.UpdateUI();
        }


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

                // Start the host server
                ProgramBL.StartServer();
            }
            catch (Exception e)
            {
                // Means problem start windows service
                LogoutAttempt();
                
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


        public static void StartServer()
        {
            // Start server and return the pointer to the service
            // The caller will keep this pointer and will send it to the StopServer(streamer) method

            ServiceHost streamer = new ServiceHost(typeof(DataStreaming.StreamService));

            SystemSession systemSession = new SystemSession();

            systemSession.setServerState(true);

            streamer.Open();
            Console.WriteLine("Service up and running at:");
            foreach (var ea in streamer.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }

            Program._StreamerHost = streamer;
        }
        public static void StopServer()
        {
            SystemSession systemSession = new SystemSession();

            systemSession.setServerState(false);

            if (Program._StreamerHost != null)
            {
                Program._StreamerHost.Close();
                Program._StreamerHost = null;
                Console.WriteLine("Stream closed");
            }
            
        }

    }
}
