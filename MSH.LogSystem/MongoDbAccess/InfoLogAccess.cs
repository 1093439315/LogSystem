using Common;
using Configuration;
using DTO;
using Entity;
using MongoDB.Bson;
using MongoDB.Core;
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
            var businessId = _BusinessAccess.IfNotInAdd(appId, logRequest.BusinessPosition);
            var entity = new InfoLog()
            {
                Content = logRequest.Content.ToJson(),
                BusinessId = new ObjectId(businessId),
                TraceInfo = logRequest.TraceInfo,
                CreationTime=logRequest.CreatTime,
            };
            DbProvider.Insert(entity);
        }
    }
}
