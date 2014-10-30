using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.ServiceProcess;

namespace PCApplication
{

    class SystemTrayIconContextMenu
    {
        
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;
            ToolStripSeparator sep;

            // Panel.
            item = new ToolStripMenuItem();
            item.Text = "Panel";
            item.Click += new EventHandler(Panel_Click);
            //item.Image = Resources.About;
            menu.Items.Add(item);

            // About.
            item = new ToolStripMenuItem();
            item.Text = "About";
            item.Click += new EventHandler(About_Click);
            //item.Image = Resources.About;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            //item.Image = Resources.Exit;
            menu.Items.Add(item);

            return menu;
        }

        


        void About_Click(object sender, EventArgs e)
        {
            //if (!isAboutLoaded)
            //{
                //isAboutLoaded = true;
                //new AboutBox().ShowDialog();
                //isAboutLoaded = false;
            //}
        }

        void Panel_Click(object sender, EventArgs e)
        {

        }


        void Exit_Click(object sender, EventArgs e)
        {
            ServiceController service = new ServiceController("IPSync");
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

            // Quit without further ado.
            Application.Exit();
        }
    }
}