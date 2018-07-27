using Configuration;
using MongoDB.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbAccess
{
    public class BusinessAccess
    {
        private PlatformAccess _PlatformAccess = new PlatformAccess();

        public string IfNotInAddReturnId(string appId, string businessPosition)
        {
            if (string.IsNullOrEmpty(appId))
                throw new ArgumentException(nameof(appId), $"{nameof(appId)}不允许为空！");

            string businessLink = Constants.DefaultBusiness;
            if (!string.IsNullOrEmpty(businessPosition))
                businessLink = businessPosition;

            //先根据AppId获取业务平台Id
            var platform = _PlatformAccess.GetPlatformByAppId(appId);
            if (platform == null)
                throw new Exception("该AppId已失效！");

            var collection = DbProvider.Collection<Entity.Business>();
            var entity = collection.AsQueryable()
                .SingleOrDefault(a => a.BusinessLink == businessLink && a.PlatformId == new ObjectId(platform.Id));
            if (entity != null)
                return entity.Id.ToString();

            //不存在则插入
            var newEntity = new Entity.Business()
            {
                PlatformId = new ObjectId(platform.Id),
                BusinessLink = businessLink
            };
            DbProvider.Collection<Entity.Business>().InsertOne(newEntity);
            return newEntity.Id.ToString();
        }

        public Entity.Business IfNotInAddReturnEntity(string appId, string businessPosition)
        {
            if (string.IsNullOrEmpty(appId))
                throw new ArgumentException(nameof(appId), $"{nameof(appId)}不允许为空！");

            string businessLink = Constants.DefaultBusiness;
            if (!string.IsNullOrEmpty(businessPosition))
                businessLink = businessPosition;

            //先根据AppId获取业务平台Id
            var platform = _PlatformAccess.GetPlatformByAppId(appId);
            if (platform == null)
                throw new Exception("该AppId已失效！");

            var collection = DbProvider.Collection<Entity.Business>();
            var entity = collection.AsQueryable()
                .SingleOrDefault(a => a.BusinessLink == businessLink && a.PlatformId == new ObjectId(platform.Id));
            if (entity != null)
                return entity;

            //不存在则插入
            var newEntity = new Entity.Business()
            {
                PlatformId = new ObjectId(platform.Id),
                BusinessLink = businessLink
            };
            DbProvider.Collection<Entity.Business>().InsertOne(newEntity);
            return newEntity;
        }
    }
}
