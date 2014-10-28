using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace IPSenderService
{
    [RunInstaller(true)]
    public partial class IPSenderServiceInstaller : System.Configuration.Install.Installer
    {
        public IPSenderServiceInstaller()
        {
            InitializeComponent();
        }
    }
}
