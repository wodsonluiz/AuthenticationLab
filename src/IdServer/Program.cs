using Microsoft.Owin.Hosting;
using System;

namespace IdServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>("https://localhost:44333"))
            {
                Console.ReadLine();
            }
        }
    }
}
