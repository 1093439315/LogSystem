﻿using MSH.LogSocketClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocketClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerClient.Connect();
        }
    }
}