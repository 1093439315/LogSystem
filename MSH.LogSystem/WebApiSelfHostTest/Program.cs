using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiSelfHostTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8866";
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("服务启动！");
                //HttpClient client = new HttpClient();
                //var response = client.GetAsync(baseAddress + "api/values").Result;
                //Console.WriteLine(response);
                //Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadKey();
            }
        }
    }
}
