using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.Hosting.Self;

namespace NancyFxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "http://127.0.0.1:9000";
            var hostConfiguration = new Nancy.Hosting.Self.HostConfiguration();
            var urlReservations = new UrlReservations();
            urlReservations.CreateAutomatically = true;
            hostConfiguration.UrlReservations = urlReservations;

            using (var host = new NancyHost(hostConfiguration, new Uri(url)))
            {
                host.Start();
                Console.WriteLine("Nancy server listening");
                Console.ReadLine();
            }

        }
    }
}
