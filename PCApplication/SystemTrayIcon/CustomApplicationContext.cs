using PCApplication.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Reflection;
using PCApplication;
using PCApplication.gui;
using System.IO;

/*
 * ==============================================================
 * @ID       $Id: MainForm.cs 971 2010-09-30 16:09:30Z ww $
 * @created  2008-07-31
 * ==============================================================
 *
 * The official license for this file is shown next.
 * Unofficially, consider this e-postcardware as well:
 * if you find this module useful, let us know via e-mail, along with
 * where in the world you are and (if applicable) your website address.
 */

/* ***** BEGIN LICENSE BLOCK *****
 * Version: MIT License
 *
 * Copyright (c) 2010 Michael Sorens http://www.simple-talk.com/author/michael-sorens/
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 *
 * ***** END LICENSE BLOCK *****
 */

namespace SystemTrayIcon.PCApplication
{

    public class CustomApplicationContext : ApplicationContext
    {

        static string STORAGE_MAIM_PATH = Application.StartupPath + @"\AppData\Contents\";
        private static readonly string DefaultTooltip = "KeepItSafe | Connection status: Offline";
        private readonly SystemManagerManager _SystemTrayIconManager;

        //private readonly HostManager hostManager;

		public CustomApplicationContext() 
		{
			InitializeContext();
            _SystemTrayIconManager = new SystemManagerManager(notifyIcon);
            ShowSettingsForm();
            //ShowGalleryForm();
		}

        private void ContextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = false;
            _SystemTrayIconManager.BuildContextMenu(notifyIcon.ContextMenuStrip);

            notifyIcon.ContextMenuStrip.Items.Add(_SystemTrayIconManager.ToolStripMenuItemWithHandler("&Settings", showSettingsItem_Click));
            notifyIcon.ContextMenuStrip.Items.Add(_SystemTrayIconManager.ToolStripMenuItemWithHandler("&Gallery", showGalleryItem_Click));
            notifyIcon.ContextMenuStrip.Items.Add(new ToolStripSeparator());
            notifyIcon.ContextMenuStrip.Items.Add(_SystemTrayIconManager.ToolStripMenuItemWithHandler("&Exit", exitItem_Click));
        }

        # region the child forms

        private SettingsForm settingsForm;
        private GalleryForm galleryForm;

        private void ShowGalleryForm()
        {
            if (galleryForm == null)
            {
                galleryForm = new GalleryForm();
                galleryForm.Closed += galleryForm_Closed; // avoid reshowing a disposed form
                //ElementHost.EnableModelessKeyboardInterop(galleryForm);
                galleryForm.Show();
            }
            else { galleryForm.Activate(); }
        }

        private void ShowSettingsForm()
        {
            if (settingsForm == null)
            {
                settingsForm = new SettingsForm { /*HostManager = hostManager*/ };
                settingsForm.Closed += settingsForm_Closed; // avoid reshowing a disposed form
                settingsForm.Show();

                // This is to change ui from Program class
                Program._SettingDialogInstance = settingsForm;
            }
            else { settingsForm.Activate(); }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e) { ShowGalleryForm(); }

        private void notifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(notifyIcon, null);
            }
        }


        // attach to context menu items
        private void showGalleryItem_Click(object sender, EventArgs e)     { 
            ShowGalleryForm();    

            // When the form loads, open this web page.
            try
            {
                // Open the gallery html
                //System.Diagnostics.Process.Start(STORAGE_MAIM_PATH + "lib\\PhotoGallery\\index.html");
            }
            catch
            {
                //MessageBox.Show("Oops...:(\nSomething went wrong...", "File loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        private bool needToUpdateHtml()
        {
            return true;
        }
        private void showSettingsItem_Click(object sender, EventArgs e)  { ShowSettingsForm();  }

        // null out the forms so we know to create a new one.
        private void settingsForm_Closed(object sender, EventArgs e) { 
            settingsForm = null; 
            Program._SettingDialogInstance = null; 
        }
        private void galleryForm_Closed(object sender, EventArgs e) { galleryForm = null; }

        # endregion the child forms

        # region generic code framework

        private System.ComponentModel.IContainer components;	// a list of components to dispose when the context is disposed
        private NotifyIcon notifyIcon;				            // the icon that sits in the system tray

        private void InitializeContext()
        {
            components = new System.ComponentModel.Container();
            notifyIcon = new NotifyIcon(components)
                             {
                                 ContextMenuStrip = new ContextMenuStrip(),
                                 Icon = Resources.system_tray_icon,
                                 Text = DefaultTooltip,
                                 Visible = true
                             };
            notifyIcon.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            notifyIcon.MouseUp += notifyIcon_MouseUp;
        }

        /// <summary>
		/// When the application context is disposed, dispose things like the notify icon.
		/// </summary>
		/// <param name="disposing"></param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && components != null) { components.Dispose(); }
		}

		/// <summary>
		/// When the exit menu item is clicked, make a call to terminate the ApplicationContext.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void exitItem_Click(object sender, EventArgs e) 
		{
			ExitThread();
		}

        /// <summary>
        /// If we are presently showing a form, clean it up.
        /// </summary>
        protected override void ExitThreadCore()
        {
            // before we exit, let forms clean themselves up.
            if (settingsForm != null) { settingsForm.Close(); }
         
           
            notifyIcon.Visible = false; // should remove lingering tray icon
            base.ExitThreadCore();
        }

        # endregion generic code framework

    }
}
