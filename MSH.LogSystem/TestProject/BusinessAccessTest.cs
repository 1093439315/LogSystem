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
            var id = dao.IfNotInAdd("94687", "订单.新建");
        }
    }
}
