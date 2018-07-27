using System;
using System.Collections.Generic;
using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Core;

namespace TestProject
{
    [TestClass]
    public class MongoDbCoreTest
    {
        [TestMethod]
        public void 测试添加平台()
        {
            var platform = new Entity.Platform()
            {
                Name="收银客户端",
                Config=new PlatformConfig()
                {
                    AppId= "94687",
                    AppSecrect="42454754656",
                },
            };
            DbProvider.Insert(platform);
        }

        [TestMethod]
        public void 测试删除平台()
        {
        }

        [TestMethod]
        public void 测试根据AppId查询平台()
        {

        }
    }
}
