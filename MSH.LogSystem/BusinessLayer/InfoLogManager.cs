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
    public class InfoLogManager : IInfoLogManager
    {
        public void AddInfoLog(LogRequest logRequest)
        {
            throw new NotImplementedException();
        }

        public void DeleteLog(long id)
        {
            throw new NotImplementedException();
        }

        public List<LogInfo> QueryLogInfo(LogQuery logQuery)
        {
            var dao = new InfoLogAccess();
            return dao.QueryLogRequest(logQuery);
        }
    }
}
