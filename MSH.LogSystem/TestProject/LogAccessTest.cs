﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDbAccess;

namespace TestProject
{
    [TestClass]
    public class LogAccessTest
    {
        [TestMethod]
        public void AddInfoLog()
        {
            var dao = new LogAccess();
            dao.AddInfoLog("94687", new DTO.LogRequest()
            {
                BusinessPosition = "订单.新建",
                Content = "这是一个测试的信息日志",
                TraceInfo = "这是一个测试的堆栈信息",
                CreatTime = DateTime.Now,
            });
        }
    }
}
