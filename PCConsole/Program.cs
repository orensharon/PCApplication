using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PCConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost IPSyncHost = new ServiceHost(typeof(IPSender.IPSendService));
            IPSyncHost.Open();

            Console.WriteLine("Service up and running at:");
            foreach (var ea in IPSyncHost.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }

            Console.WriteLine("Hit enter to kill servier");
            Console.ReadLine();

            IPSyncHost.Close();
        }
    }
}
