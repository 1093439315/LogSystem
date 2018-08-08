using Common;
using SuperSocket.SocketBase;
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
            Console.WriteLine("注册Session");
            return base.RegisterSession(sessionID, appSession);
        }

        protected override void OnNewSessionConnected(LogSession session)
        {
            Console.WriteLine("新客户端连接！");
            base.OnNewSessionConnected(session);
        }

        protected override void OnSessionClosed(LogSession session, CloseReason reason)
        {
            Console.WriteLine($"客户端关闭，关闭原因：{reason}");
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
