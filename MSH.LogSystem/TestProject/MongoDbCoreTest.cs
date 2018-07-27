using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Core;

namespace TestProject
{
    [TestClass]
    public class MongoDbCoreTest
    {
        [TestMethod]
        public void 测试文档()
        {
            var platform = new Entity.Platform()
            {
                Name="收银客户端",
                Config=new
                {
                    AppId=94687,
                    Secrect="42454754656",
                },
            };
            DbProvider.Insert(platform);

            //var infoLog = new Entity.Business()
            //{
            //    BusinessLink = new List<string>() { "订单新建", "页面查看" },
            //    PlatformId=new ObjectId(),
            //};
        }
    }
}
