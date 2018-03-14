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
            WebApp.Start<Startup>("http://127.0.0.1:7878");
        }
    }
}
