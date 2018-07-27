using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDbAccess;

namespace TestProject
{
    [TestClass]
    public class MongoDbAccessTest
    {
        [TestMethod]
        public void GetPlatformByAppId()
        {
            var dao = new PlatformAccess();
            var dto = dao.GetPlatformByAppId("94687");
        }
    }
}
