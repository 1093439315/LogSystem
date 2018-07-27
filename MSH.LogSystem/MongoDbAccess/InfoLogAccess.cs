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
using System.Linq.Expressions;
using RobotMapper;

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
                BusinessPosition = business.BusinessLink,
                PlatformId = business.PlatformId,
                TraceInfo = logRequest.TraceInfo,
                CreationTime = logRequest.CreatTime,
            };
            DbProvider.Insert(entity);
        }

        public List<LogInfo> QueryLogRequest(LogQuery logQuery)
        {
            var collection = DbProvider.Collection<InfoLog>();
            var condition = CreatCondition(logQuery);

            if (!logQuery.Pagination.IsPaging)
            {
                var allResult = collection.AsQueryable().Where(condition).ToList();
                return allResult.RobotMap<InfoLog, LogInfo>();
            }

            var result = collection.AsQueryable()
                .OrderByDescending(a => a.CreationTime)
                .Where(condition)
                .Skip(logQuery.Pagination.Skip)
                .Take(logQuery.Pagination.Take)
                .ToList();

            return result.RobotMap<InfoLog, LogInfo>();
        }

        public Expression<Func<InfoLog, bool>> CreatCondition(LogQuery logQuery)
        {
            var condition = LinqExtension.True<InfoLog>();
            if (!string.IsNullOrEmpty(logQuery.Content))
                condition.And(a => a.Content.Contains(logQuery.Content));
            if (logQuery.CreatTimeFrom.HasValue)
                condition.And(a => a.CreationTime >= logQuery.CreatTimeFrom);
            if (logQuery.CreatTmeTo.HasValue)
                condition.And(a => a.CreationTime >= logQuery.CreatTmeTo);
            if (!string.IsNullOrEmpty(logQuery.PlatformId))
                condition.And(a => a.PlatformId == new ObjectId(logQuery.PlatformId));
            if (!string.IsNullOrEmpty(logQuery.BusinessPosition))
                condition.And(a => $".{a.BusinessPosition}.".Contains($".{logQuery.BusinessPosition}."));
            if (!string.IsNullOrEmpty(logQuery.TraceInfo))
                condition.And(a => a.TraceInfo.Contains(logQuery.TraceInfo));
            return condition;
        }
    }
}
