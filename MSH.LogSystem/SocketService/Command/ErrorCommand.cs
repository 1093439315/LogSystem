﻿using Configuration;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    public class ErrorCommand : CommandBase<LogSession, StringRequestInfo>
    {
        public override string Name => LogLevel.Error.ToString();

        public override void ExecuteCommand(LogSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("Error日志操作！");
        }
    }
}
