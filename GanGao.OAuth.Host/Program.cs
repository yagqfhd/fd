using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GanGao.OAuth.Host
{
    class Program
    {
        private const string HOST_ADDRESS = "http://+:8088";
        static void Main(string[] args)
        {
            Console.WriteLine("SelfHost Start....");
            WebApp.Start<GanGao.OAuth.Startups>(HOST_ADDRESS);
            Console.WriteLine("Web API started!IP:{0}", HOST_ADDRESS);
            Console.ReadLine();
        }
    }
}
