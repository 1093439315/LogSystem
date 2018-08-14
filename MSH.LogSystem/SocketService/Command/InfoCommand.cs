using BusinessLayer;
using BusinessLayer.Interface;
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

namespace SocketService.Core
{
    public class InfoCommand : CommandBase<LogSession, StringRequestInfo>
    {
        ILogMQServiceManager LogServiceManager => new LogMQServiceManager();
        public override string Name => LogLevel.Info.ToString();

        public override void ExecuteCommand(LogSession session, StringRequestInfo requestInfo)
        {
            Console.WriteLine("Info日志操作！");
            var body = requestInfo.Body;
            if (string.IsNullOrEmpty(body)) return;
            Logger.Info($"服务端接收到Info消息:{body}");
            var logRequest = body.ToObject<LogRequest>();
            //将日志内容插入队列
            LogServiceManager.SendInfoLog(logRequest);
        }
    }
}
