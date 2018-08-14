using BusinessLayer.Interface;
using DTO;
using MongoDbAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ErrorLogManager : IErrorLogManager
    {
        public void DeleteLog(long id)
        {
            throw new NotImplementedException();
        }

        public List<LogInfo> QueryLogInfo(LogQuery logQuery)
        {
            var dao = new ErrorLogAccess();
            return dao.QueryLogRequest(logQuery);
        }
    }
}
