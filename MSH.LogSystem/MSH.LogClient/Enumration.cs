using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    /// <summary>
    /// 日志级别
    /// </summary>
    [Flags]
    public enum LogLevel : int
    {
        Info = 1,
        Debug = Info * 2,
        Warn = Debug * 2,
        Error = Warn * 2,
    }
}
