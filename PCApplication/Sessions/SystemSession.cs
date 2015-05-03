using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCApplication.Sessions
{
    public class SystemSession
    {

        public void Login()
        {
            // Set the system to a logged on state

            PCApplication.Properties.Settings.Default.IsLogged = true;
            PCApplication.Properties.Settings.Default.Save();
        }

        public void Logout()
        {

            // Set the system to a logged out state
            PCApplication.Properties.Settings.Default.IsLogged = false;
            PCApplication.Properties.Settings.Default.Save();
            // Clear other saved data
        }

        public bool getLoginState()
        {

            bool b;

            b = Convert.ToBoolean(PCApplication.Properties.Settings.Default.IsLogged);
            
            return b;
        }


        public void setIPAddress(string ipAddress)
        {

            // From a given remote ip address - store it in the system
            // It may be empty - this means there is no ip available

            PCApplication.Properties.Settings.Default.SafeIP = ipAddress;
            PCApplication.Properties.Settings.Default.Save();
        }

        public string getIPAddress()
        {

            return Convert.ToString(PCApplication.Properties.Settings.Default.SafeIP);
        }


        public void setUserToken(string token)
        {

            PCApplication.Properties.Settings.Default.Token = token;
            PCApplication.Properties.Settings.Default.Save();
        }

        public string getUserToken()
        {

            return PCApplication.Properties.Settings.Default.Token;
        }




        #region general tab
        /*
         * Username setter and getter
         */
        public void setUserName(string username)
        {
            PCApplication.Properties.Settings.Default.Username = username;
            PCApplication.Properties.Settings.Default.Save();
        }

        public string getUserName()
        {
            return Convert.ToString(PCApplication.Properties.Settings.Default.Username);
        }



        /*
         * Password setter and getter
         */
        public void setPassword(string password)
        {
            PCApplication.Properties.Settings.Default.Password = password;
            PCApplication.Properties.Settings.Default.Save();
        }

        public string getPassword()
        {
            return Convert.ToString(PCApplication.Properties.Settings.Default.Password);
        }

        public void setServerState(bool state)
        {
            PCApplication.Properties.Settings.Default.IsServerRunning = state;
            PCApplication.Properties.Settings.Default.Save();
        }

        public bool getServerState()
        {
            return Convert.ToBoolean(PCApplication.Properties.Settings.Default.IsServerRunning);
        }

        #endregion general tab

    }
}
