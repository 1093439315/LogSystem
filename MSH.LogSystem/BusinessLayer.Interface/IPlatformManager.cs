using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    /// <summary>
    /// 平台管理
    /// </summary>
    public interface IPlatformManager : IDependency
    {
        /// <summary>
        /// 查询平台(不分页)
        /// </summary>
        /// <returns></returns>
        List<Platform> QueryPlatform(PlatformQuery query);

        /// <summary>
        /// 添加平台
        /// </summary>
        /// <param name="platform"></param>
        void AddPlatform(Platform platform);

        /// <summary>
        /// 删除平台
        /// </summary>
        /// <param name="id"></param>
        void DeletePlatform(List<string> ids);
    }
}
