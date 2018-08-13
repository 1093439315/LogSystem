using MSH.LogClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Log4netClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MSHLogger.DefaultInfo("测试！");
            MSHLogger.Instance("123", "123213");
            HH();
            Console.ReadKey();

            //MSHLogger.DefaultInfo("嘿嘿");
            //Console.ReadKey();
            //MSHLogger.DefaultInfo("嘿嘿");
            //Console.ReadKey();
            //MSHLogger.DefaultInfo("嘿嘿");
            //Console.ReadKey();
            //MSHLogger.DefaultInfo("嘿嘿");
            //Console.ReadKey();
        }

        static void HH()
        {
            MSHLogger.DefaultInfo("测试！");
        }
    }
}
