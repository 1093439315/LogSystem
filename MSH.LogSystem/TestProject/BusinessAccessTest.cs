using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDbAccess;

namespace TestProject
{
    [TestClass]
    public class BusinessAccessTest
    {
        [TestMethod]
        public void IfNotInAdd()
        {
            var dao = new BusinessAccess();
            var id = dao.IfNotInAddReturnId("94687", "订单.新建");
        }

        [TestMethod]
        public void TT()
        {
            var str = "/*qweqwe*/";
            Assert.IsTrue(str.StartsWith("/*"));
        }
    }
}
