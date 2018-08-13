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
using MongoDB.Driver.Linq;

namespace MongoDbAccess
{
    public class InfoLogAccess
    {
        private BusinessAccess _BusinessAccess = new BusinessAccess();

        public void AddInfoLog(LogRequest logRequest)
        {
            if (logRequest == null || logRequest.Content == null)
                throw new ArgumentException(nameof(logRequest), "日志内容不能为空！");

            //取业务Id 如果没有则新建业务
            var business = _BusinessAccess.IfNotInAddReturnEntity(logRequest.AppId, logRequest.BusinessPosition);
            var entity = new InfoLog()
            {
                Content = logRequest.Content.ToJson(),
                BusinessId = business.Id,
                BusinessPosition = business.BusinessLink,
                PlatformId = business.PlatformId,
                TraceInfo = logRequest.TraceInfo,
                CreationTime = logRequest.CreatTime,
                RequestId = logRequest.RequestId
            };
            DbProvider.Insert(entity);
        }

        public List<LogInfo> QueryLogRequest(LogQuery query)
        {
            if (query == null) return new List<LogInfo>();

            var queryAble = CreatQueryAble(query).OrderByDescending(a => a.CreationTime);
            query.Pagination.DataCount = queryAble.Count();

            if (!query.Pagination.IsPaging)
            {
                var allResult = queryAble.ToList();
                return allResult.RobotMap<Entity.InfoLog, LogInfo>();
            }

            var entities = queryAble
                .Skip(query.Pagination.Skip)
                .Take(query.Pagination.Take)
                .ToList();
            return entities.RobotMap<Entity.InfoLog, LogInfo>();
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

        private IMongoQueryable<Entity.InfoLog> CreatQueryAble(LogQuery query)
        {
            var collection = DbProvider.Collection<Entity.InfoLog>();
            var queryAble = collection.AsQueryable().Where(a => 1 == 1);
            if (!string.IsNullOrEmpty(query.Content))
                queryAble = queryAble.Where(a => a.Content.Contains(query.Content));
            if (query.CreatTimeFrom.HasValue)
                queryAble = queryAble.Where(a => a.CreationTime >= query.CreatTimeFrom);
            if (query.CreatTmeTo.HasValue)
                queryAble = queryAble.Where(a => a.CreationTime <= query.CreatTmeTo);
            if (!string.IsNullOrEmpty(query.PlatformId))
                queryAble = queryAble.Where(a => a.PlatformId == new ObjectId(query.PlatformId));
            if (!string.IsNullOrEmpty(query.BusinessPosition))
                queryAble = queryAble.Where(a => a.BusinessPosition.Contains(query.BusinessPosition));
            if (!string.IsNullOrEmpty(query.TraceInfo))
                queryAble = queryAble.Where(a => a.TraceInfo.Contains(query.TraceInfo));
            return queryAble;
        }
    }
}
