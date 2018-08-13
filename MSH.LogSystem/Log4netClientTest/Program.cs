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
            MSHLogger.Instance("123", "12321322");
            MSHLogger.Instance("业务1.业务22").SetRequestId(Guid.NewGuid().ToString()).Info("嘿嘿22！");
            HH();
            Console.ReadKey();
        }

        static void HH()
        {
            MSHLogger.DefaultInfo("测试！");
        }
    }
}
