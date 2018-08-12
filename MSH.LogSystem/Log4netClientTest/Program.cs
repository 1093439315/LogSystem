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
            MSHLogger.DefaultInfo("测试！");
            //MSHLogger.Instance("订单", "新建").Info("业务测试1");
            //MSHLogger.Instance("订单", "新建").Info("业务测试2");

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
    }
}
