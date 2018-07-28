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
    public class PlatformManager : IPlatformManager
    {
        private PlatformAccess _PlatformAccess = new PlatformAccess();

        public List<Platform> QueryPlatform(PlatformQuery query)
        {
            return _PlatformAccess.QueryPlatform(query);
        }

        public void AddPlatform(Platform platform)
        {
            _PlatformAccess.AddPlatform(platform);
        }

        public void DeletePlatform(List<string> ids)
        {
            _PlatformAccess.DeletePlatform(ids);
        }
    }
}
