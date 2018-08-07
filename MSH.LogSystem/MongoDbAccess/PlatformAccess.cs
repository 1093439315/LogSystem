using MongoDB.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using RobotMapper;
using DTO;
using System.Linq.Expressions;
using Common;

namespace MongoDbAccess
{
    public class PlatformAccess
    {
        public Platform GetPlatformByAppId(string appId)
        {
            var collection = DbProvider.Collection<Entity.Platform>();
            var entity = collection.AsQueryable()
                .FirstOrDefault(a => a.Config.AppId == appId);

            if (entity == null)
                return null;
            return entity.RobotMap<Entity.Platform, DTO.Platform>(cf =>
            {
                cf.Bind(x => x.Id.ToString(), y => y.Id);
            });
        }

        public List<Platform> QueryPlatform(PlatformQuery query)
        {
            if (query == null) return new List<Platform>();

            var queryAble = CreatQueryAble(query).OrderByDescending(a => a.CreatTime);
            query.Pagination.DataCount = queryAble.Count();

            if (!query.Pagination.IsPaging)
            {
                var allResult = queryAble.ToList();
                return allResult.RobotMap<Entity.Platform, Platform>();
            }

            var entities = queryAble
                .Skip(query.Pagination.Skip)
                .Take(query.Pagination.Take)
                .ToList();
            return entities.RobotMap<Entity.Platform, Platform>();
        }

        public void AddPlatform(Platform platform)
        {
            if (platform == null) return;
            var collection = DbProvider.Collection<Entity.Platform>();
            if (collection.AsQueryable().Any(a => a.Name == platform.Name))
                throw new BaseCustomException($"名称为{platform.Name}的平台已存在!");
            if (collection.AsQueryable().Any(a => a.Config.AppId == platform.AppId))
                throw new BaseCustomException($"AppId为{platform.AppId}的平台已存在!");
            var entity = platform.RobotMap<Platform, Entity.Platform>();
            DbProvider.Insert(entity);
        }

        public void DeletePlatform(List<string> ids)
        {
            var collection = DbProvider.Collection<Entity.Platform>();
            DbProvider.DeleteByIds<Entity.Platform>(ids);
        }

        private Expression<Func<Entity.Platform, bool>> CreatCondition(PlatformQuery query)
        {
            var condition = LinqExtension.True<Entity.Platform>();
            if (!string.IsNullOrEmpty(query.AppId))
                condition.And(a => a.Config.AppId == query.AppId);
            if (!string.IsNullOrEmpty(query.Name))
                condition.And(a => a.Name.Contains(query.Name));
            return condition;
        }

        private IMongoQueryable<Entity.Platform> CreatQueryAble(PlatformQuery query)
        {
            var collection = DbProvider.Collection<Entity.Platform>();
            var queryAble = collection.AsQueryable().Where(a => 1 == 1);
            if (!string.IsNullOrEmpty(query.Name))
                queryAble = queryAble.Where(a => a.Name.Contains(query.Name));
            if (!string.IsNullOrEmpty(query.AppId))
                queryAble = queryAble.Where(a => a.Config.AppId == query.AppId);
            return queryAble;
        }
    }
}
