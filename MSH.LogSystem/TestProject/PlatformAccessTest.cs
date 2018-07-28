using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDbAccess;

namespace TestProject
{
    [TestClass]
    public class PlatformAccessTest
    {
        [TestMethod]
        public void GetPlatformByAppId()
        {
            var dao = new PlatformAccess();
            var dto = dao.GetPlatformByAppId("94687");
        }

        [TestMethod]
        public void QueryPlatform()
        {
            var dao = new PlatformAccess();
            var dtos = dao.QueryPlatform(new DTO.PlatformQuery()
            {
            });
        }
    }
}
