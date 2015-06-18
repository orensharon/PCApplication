using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCApplication
{
    public class SystemStatusLog
    {

        public static void ClearSystemStatusLog()
        {
            System.IO.File.WriteAllText(Application.StartupPath + "\\log.txt",String.Empty);
        }

        public static void WriteToSystemStatusLog(int s)
        {
            //_SystemLogTextbox.Text = Constants.SYSTEM_STATUS[s];
            System.IO.File.AppendAllText(Application.StartupPath + "\\log.txt", "\r\n" + Constants.SYSTEM_STATUS[s]);
        }

        public static void WriteToSystemStatusLog(String s)
        {
            System.IO.File.AppendAllText(Application.StartupPath + "\\log.txt", "\r\n" + s);
        }

        public static string GetSystemStatusLog()
        {
            string[] lines;
            string log = "";
            lines = System.IO.File.ReadAllLines(Application.StartupPath + "\\log.txt");

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                log += lines[i] + "\r\n";
            }

            return log;
        }
    }
}
