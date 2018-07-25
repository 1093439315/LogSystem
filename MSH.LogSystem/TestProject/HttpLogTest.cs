using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flurl.Http;
using DTO;

namespace TestProject
{
    [TestClass]
    public class HttpLogTest
    {
        [TestMethod]
        public void 测试发送Info日志()
        {
            var url = "http://localhost:1762/api/LogService/Info";
            url.PostJsonAsync(new LogRequest()
            {
                BusinessPosition="1",
                Content="qweqwe",
                CreatTime=DateTime.Now,
                TraceInfo="qweqwe",
            });
        }
    }
}
