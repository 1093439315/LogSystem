using BusinessLayer.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LogServiceManager : ILogServiceManager
    {
        public void SendErrorLog(LogRequest request)
        {
            throw new NotImplementedException();
        }

        public void SendInfoLog(LogRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
