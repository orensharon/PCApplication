using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCApplication
{
    public class Constants
    {


        // System session constants
        public static string IS_LOGGED = "IsLogged";
        public static string PC_IP = "PC_IP";

        // System Status Log Keys
        public static int STATUS_KEY_LOGGING_IN = 0;
        public static int STATUS_KEY_LOGGED = 1;
        public static int STATUS_KEY_LOGGED_OUT = 2;
        public static int STATUS_KEY_SERVER_RUNNING = 3;
        public static int STATUS_KEY_SYNCING_IP = 4;

        // System Status Log String constants
        public static string[] SYSTEM_STATUS = { "Logging-in...", "Logged-in to system", "Logged-out", "Server is running", "Syncing IP..." };


        // Login Error message keys
        public static int LOGIN_ERROR_KEY_TIMEOUT = 0;

        //Login error String constants
        public static string[] LOGIN_ERROR_MESSAGE = { "Logging timeout.\nPlease try again later" };

    }
}
