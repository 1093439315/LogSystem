using Common;
using Configuration;
using SuperSocket.Facility.Protocol;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketService.Core
{
    public class LogReceiveFilter : BeginEndMarkReceiveFilter<StringRequestInfo>
    {
        public LogReceiveFilter()
            : base(Config.BeginMark, Config.EndMark)
        {
        }

        protected override StringRequestInfo ProcessMatchedRequest(byte[] readBuffer, int offset, int length)
        {
            try
            {
                var str = Encoding.UTF8.GetString(readBuffer, offset, length);
                if (!str.StartsWith(Config.BeginMarkStr) || !str.EndsWith(Config.EndMarkStr))
                    return new StringRequestInfo(Constants.UnKnow, null, null);
                str = str.Remove(0, Config.BeginMarkStr.Length);
                str = str.Remove(str.Length - Config.EndMarkStr.Length, Config.EndMarkStr.Length);
                var result = str.ToObject<StringRequestInfo>();
                if (result == null)
                    return new StringRequestInfo(Constants.UnKnow, null, null);
                return result;
            }
            catch (Exception ex)
            {
                Logger.Error($"解析请求出错：{ex}");
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
