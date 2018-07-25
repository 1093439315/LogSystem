using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration
{
    /// <summary>
    /// 日志级别
    /// </summary>
    [Flags]
    public enum LogLevel
    {
        [Note("信息")]
        Info = 1,
        [Note("调试")]
        Debug = Info * 2,
        [Note("警告")]
        Warn = Debug * 2,
        [Note("错误")]
        Error = Warn * 2,
    }
}
