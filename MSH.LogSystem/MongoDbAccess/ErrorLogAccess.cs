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
    public class ErrorLogAccess
    {
        private BusinessAccess _BusinessAccess = new BusinessAccess();

        public void AddLog(LogRequest logRequest)
        {
            if (logRequest == null || logRequest.Content == null)
                throw new ArgumentException(nameof(logRequest), "日志内容不能为空！");

            //取业务Id 如果没有则新建业务
            var business = _BusinessAccess.IfNotInAddReturnEntity(logRequest.AppId, logRequest.BusinessPosition);
            var entity = new ErrorLog()
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
                return allResult.RobotMap<Entity.ErrorLog, LogInfo>();
            }

            var entities = queryAble
                .Skip(query.Pagination.Skip)
                .Take(query.Pagination.Take)
                .ToList();
            return entities.RobotMap<Entity.ErrorLog, LogInfo>();
        }
        
        private IMongoQueryable<Entity.ErrorLog> CreatQueryAble(LogQuery query)
        {
            var collection = DbProvider.Collection<Entity.ErrorLog>();
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
