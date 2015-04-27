using PCApplication.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCApplication.AccountSession
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

            PCApplication.Properties.Settings.Default.PCIP = ipAddress;
            PCApplication.Properties.Settings.Default.Save();
        }

        public string getIPAddress()
        {

            return Convert.ToString(PCApplication.Properties.Settings.Default.PCIP);
        }


        /*public void setUserID(int user_id)
        {

            // From a given user id - store it in the system

            PCApplication.Properties.Settings.Default.UserID = user_id;
            PCApplication.Properties.Settings.Default.Save();
        }

        public int getUserID()
        {

            return Convert.ToInt32(PCApplication.Properties.Settings.Default.UserID);
        }*/


        public void setUserToken(string token)
        {

            PCApplication.Properties.Settings.Default.Token = token;
            PCApplication.Properties.Settings.Default.Save();
        }

        public string getUserToken()
        {

            return PCApplication.Properties.Settings.Default.Token;
        }

    }
}
