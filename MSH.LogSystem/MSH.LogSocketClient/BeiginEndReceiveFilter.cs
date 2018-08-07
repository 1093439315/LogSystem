using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSH.LogSocketClient
{
    public class BeiginEndReceiveFilter : BeginEndMarkReceiveFilter<StringPackageInfo>
    {
        public BeiginEndReceiveFilter()
            : base(new byte[] { (byte)'!' }, new byte[] { (byte)'$' })
        {
        }

        public override StringPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            return new StringPackageInfo("qe", "qwe", null);
        }
    }
}
