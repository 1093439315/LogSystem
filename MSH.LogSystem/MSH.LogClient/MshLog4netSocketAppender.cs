﻿using log4net.Appender;
using log4net.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    /// <summary>
    /// log4net自定义日志Appender
    /// </summary>
    public class MshLog4netSocketAppender : AppenderSkeleton
    {
        /// <summary>
        /// 日志服务器地址
        /// </summary>
        public string ServerHost { get; set; }
        /// <summary>
        /// 日志服务器端口
        /// </summary>
        public string ServerPort { get; set; }
        /// <summary>
        /// 上传模式
        /// </summary>
        public string Mode { get; set; } = "tcp";
        /// <summary>
        /// 默认业务位置
        /// </summary>
        public string DefaultBusinessPosition { get; set; }

        public string AppId { get; set; }
        public string Secrect { get; set; }

        /// <summary>
        /// Socket协议起止符
        /// </summary>
        public string BeginMark { get; set; }
        /// <summary>
        /// Socket协议结束符
        /// </summary>
        public string EndMark { get; set; }

        protected override void Append(LoggingEvent loggingEvent)
        {
            StartService();
            SetLogProperty(loggingEvent);
            MSHLogger.LoggingEvents.Add(loggingEvent);
            var obj = loggingEvent;
        }

        protected override void Append(LoggingEvent[] loggingEvents)
        {
            StartService();
            loggingEvents.ToList().ForEach(a =>
            {
                SetLogProperty(a);
                MSHLogger.LoggingEvents.Add(a);
            });
            base.Append(loggingEvents);
        }

        protected void SetLogProperty(LoggingEvent loggingEvent)
        {
            loggingEvent.Properties[nameof(ServerHost)] = ServerHost;
            loggingEvent.Properties[nameof(ServerPort)] = ServerPort;
            loggingEvent.Properties[nameof(Mode)] = Mode;
            loggingEvent.Properties[nameof(AppId)] = AppId;
            loggingEvent.Properties[nameof(Secrect)] = Secrect;
            loggingEvent.Properties[nameof(DefaultBusinessPosition)] = DefaultBusinessPosition;
            loggingEvent.Properties[nameof(BeginMark)] = BeginMark;
            loggingEvent.Properties[nameof(EndMark)] = EndMark;
        }

        protected void StartService()
        {
            //tcp连接需要启动连接
            if (this.Mode.ToLower().Equals("tcp"))
                SocketClientManage.StartTcp(this.ServerHost, int.Parse(this.ServerPort));
            else
                SocketClientManage.CreatReadTask(false);
        }
    }
}
