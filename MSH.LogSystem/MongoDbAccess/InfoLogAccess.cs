using Common;
using Configuration;
using DTO;
using Entity;
using MongoDB.Bson;
using MongoDB.Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbAccess
{
    public class InfoLogAccess
    {
        private BusinessAccess _BusinessAccess = new BusinessAccess();

        public void AddInfoLog(string appId, LogRequest logRequest)
        {
            if (logRequest == null || logRequest.Content == null)
                throw new ArgumentException(nameof(logRequest), "日志内容不能为空！");

            //取业务Id 如果没有则新建业务
            var business = _BusinessAccess.IfNotInAddReturnEntity(appId, logRequest.BusinessPosition);
            var entity = new InfoLog()
            {
                Content = logRequest.Content.ToJson(),
                BusinessId = business.Id,
                BusinessPosition=business.BusinessLink,
                PlatformId = business.PlatformId,
                TraceInfo = logRequest.TraceInfo,
                CreationTime = logRequest.CreatTime,
            };
            DbProvider.Insert(entity);
        }

        public List<LogRequest> QueryLogRequest(LogQuery logQuery)
        {
            var collection = DbProvider.Collection<InfoLog>();
            //var filter = Builders<T>.Filter.Eq("Id", new ObjectId(""));
            return null;
        }
    }
}
