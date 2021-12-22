﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerSide
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var host = new ServiceHost(typeof(WCFLibrary.WCFService)))
            {
                host.Open();
                Console.WriteLine("Хост успешно запущен");
                Console.ReadLine();
            }
        }
    }
}
