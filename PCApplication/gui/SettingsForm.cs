using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using PCApplication.Sessions;

namespace PCApplication
{
    public partial class SettingsForm : Form
    {
       


        public TextBox UpdatedIP { get; set; }



        // Sessions
        private SystemSession _SystemSession;
        private SettingsSession _SettingsSession;

        // Controls

        // General tab
        private TextBox _UsernameTextBox, _PasswordTextBox;
        private Button _LoginButton;

        // Connection tab
        private TextBox _IPTextBox;
        public Label _SystemStatusLogLabel;

        public SettingsForm()
        {
            InitializeComponent();

            // Session init
            _SystemSession = new SystemSession();
            _SettingsSession = new SettingsSession();


            // Try to make login on first start
         /*   if (_IsFirstRun == true)
            {
                // Start sync service if user is logged in
                if (_SystemSession.getLoginState() == true)
                {
                    LoginAttemptASync();
                }
                _IsFirstRun = false;
            }*/

            

            // Controls pointers init


            // General tab
            _UsernameTextBox = GeneralTabContainer_AccountGroupBox_UsernameTextBox;
            _PasswordTextBox = GeneralTabContainer_AccountGroupBox_PasswordTextBox;

            _LoginButton = GeneralTabContainer_AccountGroupBox_LoginButton;

            // Connection tab
            _IPTextBox = GeneralTabContainer_ConnectionGroupBox_IPTextBox;
            _SystemStatusLogLabel = ConnectionTabContainer_StatusGroupBox_lblStatusValue;
            
            //_Streamer = new ServiceHost(typeof(DataStreaming.StreamService));
            
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            // TODO: apply settings to hide window
        }

        private void LogoutAttempt()
        {
            //_IsConnecting = false;
            UpdateConnectionStatusIcon(1);
            ProgramBL.LogoutAttempt();
            //UpdateUI();
            
        }

        private async void LoginAttemptASync()
        {
           // _IsConnecting = true;
            UpdateConnectionStatusIcon(2);
            await ProgramBL.LoginAttemptASync(LoginAttemptComplete);
           
        }
        private void LoginAttemptComplete(string message)
        {
            if (message != null)
            {
                // Show error message
                MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateUI();
        }


   
        
        
        private void GeneralTabContainer_AccountGroupBox_LoginButton_Click(object sender, EventArgs e)
        {
            _LoginButton.Enabled = false;
            _UsernameTextBox.Enabled = false;
            _PasswordTextBox.Enabled = false;

            if (_SystemSession.getLoginState() == false)
            {

                // User attempt to login
               
                // Save user login data into settings
                _SystemSession.setUserName(_UsernameTextBox.Text.Trim());
                _SystemSession.setPassword(_PasswordTextBox.Text.Trim());

                LoginAttemptASync();


            }
            else
            {
                // User attempt to logout
                LogoutAttempt();  
            }
        }


        private void MainDialog_Load(object sender, EventArgs e)
        {
            UpdateUI();
        }


        public void UpdateConnectionStatusIcon(int connectionStatus)
        {
            object ConnectionStatusResource;
            string connectionStatusText;

            // offline by default
            ConnectionStatusResource = PCApplication.Properties.Resources.icon_offline;

            // Set diconnected text by default
            connectionStatusText = "OFFLINE";

                switch (connectionStatus)
                {
                    case 0:

                    // Set connected icon
                    ConnectionStatusResource = PCApplication.Properties.Resources.icon_online;
                    connectionStatusText = "ONLINE";
                    break;

                    case 1:

                    // Set not connected icon
                    ConnectionStatusResource = PCApplication.Properties.Resources.icon_offline;
                    connectionStatusText = "OFFLINE";
                    break;

                    case 2:

                    // Set connecting icon
                    ConnectionStatusResource = PCApplication.Properties.Resources.icon_connecting;
                    connectionStatusText = "CONNECTING";
                    
                    // Make sure - if connecting disable the logout button
                    _LoginButton.Enabled = false;
                    break;

                }


            // Set connected text
            GeneralTabContainer_ConnectionGroupBox_ConnectionStatusValueLabel.Text = connectionStatusText;
            GeneralTabContainer_ConnectionGroupBox_ConnectionStatusIcon.Image = (Image)ConnectionStatusResource;
        }


        public void UpdateUI()
        {

            
            int connectionStatus;

            this.Invoke((MethodInvoker)delegate
            {
                
            
                if (_SystemSession.getLoginState() == true)
                {
                    // User is logged in

                    // Disable login commands
                    _UsernameTextBox.Enabled = false;
                    _PasswordTextBox.Enabled = false;

                    
                    _LoginButton.Enabled = true;
                    _LoginButton.Text = "Stop";

                    // Update save ip address
                    _IPTextBox.Text = _SystemSession.getIPAddress();

                    // Connection status - connected
                    connectionStatus = 0;
                }
                else
                {
                    // User is logged out
                    _UsernameTextBox.Enabled = true;
                    _PasswordTextBox.Enabled = true;

                    _LoginButton.Enabled = true;
                    

                    _LoginButton.Text = "Start";

                    _IPTextBox.Text = String.Empty;

                    // Connection status - offline
                    connectionStatus = 1;
                }

              //  if (_IsConnecting != true)
              //  {
                    // Update connection status icon
                    UpdateConnectionStatusIcon(connectionStatus);
             //   }

                if (!_SystemSession.getUserName().Equals(""))
                {

                    _UsernameTextBox.Text = _SystemSession.getUserName();
                }

                if (!_SystemSession.getPassword().Equals(""))
                {
                    _PasswordTextBox.Text = _SystemSession.getPassword();
                }

                
                _SystemStatusLogLabel.Text = SystemStatusLog.GetSystemStatusLog();
            });
        }



    }
}
