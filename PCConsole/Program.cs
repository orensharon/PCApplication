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
            // Host and Start the data streaming service
            ServiceHost Streamer = new ServiceHost(typeof(DataStreaming.StreamService));

            Streamer.Open();
            Console.WriteLine("Service up and running at:");
            foreach (var ea in Streamer.Description.Endpoints)
            {
                Console.WriteLine(ea.Address);
            }
            Console.ReadLine();

            Streamer.Close();
        }
    }
}
