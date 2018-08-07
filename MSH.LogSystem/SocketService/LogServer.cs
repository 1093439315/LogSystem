﻿using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    public class LogServer : AppServer<LogSession>
    {
        public LogServer()
            : base(new DefaultReceiveFilterFactory<LogReceiveFilter, StringRequestInfo>())
        {
        }

        protected override void OnStarted()
        {
            Console.WriteLine("服务已启动");
            base.OnStarted();
        }

        protected override void OnStopped()
        {
            Console.WriteLine("服务已停止");
            base.OnStopped();
        }

        protected override bool RegisterSession(string sessionID, LogSession appSession)
        {
            return base.RegisterSession(sessionID, appSession);
        }

        protected override void OnNewSessionConnected(LogSession session)
        {
            base.OnNewSessionConnected(session);
        }

        protected override void OnSessionClosed(LogSession session, CloseReason reason)
        {
            base.OnSessionClosed(session, reason);
        }

        protected override void OnSystemMessageReceived(string messageType, object messageData)
        {
            base.OnSystemMessageReceived(messageType, messageData);
        }

        protected override void ExecuteCommand(LogSession session, StringRequestInfo requestInfo)
        {
            base.ExecuteCommand(session, requestInfo);
        }
    }
}
