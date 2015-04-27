using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCApplication.Sessions
{
    class SettingsSession
    {
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

    }
}
