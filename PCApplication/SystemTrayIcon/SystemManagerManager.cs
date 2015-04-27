using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;


namespace SystemTrayIcon.PCApplication
{

    class SystemManagerManager
    {

        private readonly NotifyIcon notifyIcon;

        public SystemManagerManager(NotifyIcon notifyIcon)
        {
            this.notifyIcon = notifyIcon;
        }

        public void BuildContextMenu(ContextMenuStrip contextMenuStrip)
        {
            contextMenuStrip.Items.Clear();
            //contextMenuStrip.Items.AddRange(
            //    new ToolStripItem[] {
            //        ToolStripMenuItemWithHandler("&Settings", openHostsFileItem_Click),
            //        ToolStripMenuItemWithHandler("&Gallery", openHostsFolderItem_Click)
             //   });
        }


        private ToolStripMenuItem ToolStripMenuItemWithHandler(
           string displayText, int enabledCount, int disabledCount, EventHandler eventHandler)
        {
            var item = new ToolStripMenuItem(displayText);
            if (eventHandler != null) { item.Click += eventHandler; }

            item.Image = null;
            item.ToolTipText = (enabledCount > 0 && disabledCount > 0) ?
                                                 string.Format("{0} enabled, {1} disabled", enabledCount, disabledCount)
                         : (enabledCount > 0) ? string.Format("{0} enabled", enabledCount)
                         : (disabledCount > 0) ? string.Format("{0} disabled", disabledCount)
                         : "";
            return item;
        }

        public ToolStripMenuItem ToolStripMenuItemWithHandler(string displayText, EventHandler eventHandler)
        {
            return ToolStripMenuItemWithHandler(displayText, 0, 0, eventHandler);
        }




       
    }
}