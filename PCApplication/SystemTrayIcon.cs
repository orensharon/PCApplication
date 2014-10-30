using PCApplication.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCApplication
{
    class SystemTrayIcon : IDisposable
    {
        NotifyIcon ni;

        public SystemTrayIcon()
        {
            ni = new NotifyIcon();

        }

        public void Display()
        {
            // Put the icon in the system tray and allow it react to mouse clicks.			
            ni.MouseClick += new MouseEventHandler(ni_MouseClick);
            ni.Icon = Resources.system_tray_icon;
            ni.Text = "MyStuff status is:";
            ni.Visible = true;

            // Adding context menu string to the icon
            ni.ContextMenuStrip = new SystemTrayIconContextMenu().Create();
        }

        public void Dispose()
        {
            ni.Dispose();
        }

        void ni_MouseClick(object sender, MouseEventArgs e)
        {
            // Handle mouse button clicks.
            if (e.Button == MouseButtons.Left)
            {
                // Show thw main dialog
                new MainDialog().ShowDialog();
                
            }
        }
    }
}
