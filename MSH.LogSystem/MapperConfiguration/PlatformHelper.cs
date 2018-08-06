using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;

namespace MapperConfiguration
{
    internal static class PlatformHelper
    {
        public static PlatformConfig GetPlatformConfig(DTO.Platform platform)
        {
            return new PlatformConfig()
            {
                AppId = platform.AppId,
                AppSecrect = platform.AppSecrect,
            };
        }
    }
}
