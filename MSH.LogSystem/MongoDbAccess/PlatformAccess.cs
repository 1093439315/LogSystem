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

namespace MongoDbAccess
{
    public class PlatformAccess
    {
        public DTO.Platform GetPlatformByAppId(string appId)
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
    }
}
