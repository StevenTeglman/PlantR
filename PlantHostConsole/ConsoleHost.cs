using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PlantHostConsole
{
    class ConsoleHost
    {
        static void Main(string[] args)
        {
            ServiceHost hostPlantRServ = new ServiceHost(typeof(PlantRServ.Service1));
            hostPlantRServ.Open();

            Console.WriteLine("Service started, press a [Enter] to close it.");
            Console.ReadLine();

            hostPlantRServ.Close();
        }
    }
}
