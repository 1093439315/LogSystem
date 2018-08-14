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
            MSHLogger.DefaultInfo("测试2！");
            MSHLogger.Request(Guid.NewGuid().ToString()).Error("哈哈哈");
            HH();
            Console.ReadKey();
        }

        static void HH()
        {
            MSHLogger.DefaultError("Happy！");
        }
    }
}
