using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    public class InfoLogCommand : CommandBase<LogSession, StringRequestInfo>
    {
        public override string Name => "InfoLog";

        public override void ExecuteCommand(LogSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("信息日志操作！");
        }
    }
}
