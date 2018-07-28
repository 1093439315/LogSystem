using MongoDB.Core;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;
using RobotMapper;
using DTO;
using System.Linq.Expressions;
using Common;
using MongoDB.Bson;

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
            return entity.RobotMap<Entity.Platform, DTO.Platform>(cf=> 
            {
                cf.Bind(x => x.Id.ToString(), y => y.Id);
            });
        }

        public List<Platform> QueryPlatform(PlatformQuery query)
        {
            if (query == null) return new List<Platform>();
            var collection = DbProvider.Collection<Entity.Platform>();
            var condition = CreatCondition(query);
            var entities = collection.AsQueryable().Where(condition).ToList();
            return entities.RobotMap<Entity.Platform, Platform>();
        }

        public void AddPlatform(Platform platform)
        {
            if (platform == null) return;
            var collection = DbProvider.Collection<Entity.Platform>();
            if (collection.AsQueryable().Any(a => a.Name == platform.Name))
                throw new BaseCustomException($"名称为{platform.Name}的平台已存在!");
            var entity = platform.RobotMap<Platform, Entity.Platform>();
            DbProvider.Insert(entity);
        }

        public void DeletePlatform(string id)
        {
            var collection = DbProvider.Collection<Entity.Platform>();
            if (collection.AsQueryable().Any(a => a.Id == new ObjectId(id)))
                throw new BaseCustomException("该记录已不存在！");
            DbProvider.DeleteById<Entity.Platform>(id);
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
    }
}
