using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoApi
{
    class Program
    {
        static void Main(string[] args)
        {
            StartOptions options = new StartOptions();
            options.Urls.Add("http://localhost:4004");
            options.Urls.Add("http://127.0.0.1:4004");
            options.Urls.Add(string.Format("http://{0}:4004", Environment.MachineName));
            options.Urls.Add("http://+:4004");
            options.Urls.Add("http://localhost:80");
            options.Urls.Add("http://127.0.0.1:80");
            options.Urls.Add(string.Format("http://{0}:80", Environment.MachineName));
            options.Urls.Add("http://+:80");
            WebApp.Start<Startup>(options);

            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}
