using RobotMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Configuration;

namespace MapperConfiguration
{
    public class MapperConfig
    {
        public static void Initial()
        {
            Mapper.Initialize(ct =>
            {
                ct.CreatMap<Entity.Platform, Platform>(cf =>
                {
                    cf.Bind(x => x.Id.ToString(), y => y.Id);
                    cf.Bind(x => x.Config?.AppId, y => y.AppId);
                    cf.Bind(x => x.Config?.AppSecrect, y => y.AppSecrect);
                });
                ct.CreatMap<Platform, Entity.Platform>(cf =>
                {
                    cf.Bind(x => PlatformHelper.GetPlatformConfig(x), y => y.Config);
                });
            });
        }
    }
}
