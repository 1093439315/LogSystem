using Common;
using Configuration;
using DTO;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService
{
    public class InfoCommand : CommandBase<LogSession, StringRequestInfo>
    {
        public override string Name => LogLevel.Info.ToString();

        public override void ExecuteCommand(LogSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("Info日志操作！");
            var body = requestInfo.Body;
            if (string.IsNullOrEmpty(body)) return;
            var logRequest = body.ToObject<LogRequest>();
            Console.WriteLine(logRequest.ToJson());
            //将日志内容插入队列
        }
    }
}
