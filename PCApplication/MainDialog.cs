using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCApplication
{
    public partial class MainDialog : Form
    {
        public MainDialog()
        {
            InitializeComponent();
        }





        private void ForceUpdateButton_Click(object sender, EventArgs e)
        {

        }

        private void HandleMainTabSelection(object sender, EventArgs e)
        {
            // Get the tab string
            TabControl tab = ((TabControl)sender);
            string tabString = tab.SelectedTab.Text;

            if (tabString.Equals("Connection"))
            {
                // Thread
                //ConnectionTabContainer_RoutingGroupBox_CurrentIPTextBox.Text = getExternalIp();
            }

        }






    }
}
