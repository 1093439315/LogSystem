using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    public class LogSession : AppSession<LogSession>
    {
        protected override void OnInit()
        {
            base.OnInit();
        }

        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
        }

        public override void Close()
        {
            base.Close();
        }

        public override void Close(CloseReason reason)
        {
            base.Close(reason);
        }

        public override void Send(string message)
        {
            base.Send(message);
        }

        public override bool TrySend(string message)
        {
            return base.TrySend(message);
        }

        protected override int GetMaxRequestLength()
        {
            return base.GetMaxRequestLength();
        }

        protected override string ProcessSendingMessage(string rawMessage)
        {
            return base.ProcessSendingMessage(rawMessage);
        }

        protected override void HandleException(Exception e)
        {
            base.HandleException(e);
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            base.HandleUnknownRequest(requestInfo);
        }
    }
}
