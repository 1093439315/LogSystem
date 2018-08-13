using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogClient
{
    public static class MSHLoggerExtension
    {
        /// <summary>
        /// 实例模式(带RequestId)
        /// </summary>
        /// <param name="mSHLogger">实例</param>
        /// <param name="requestId">requestId</param>
        /// <returns></returns>
        public static MSHLogger SetRequestId(this MSHLogger mSHLogger, string requestId)
        {
            mSHLogger.RequestId = requestId;
            return mSHLogger;
        }
    }
}
