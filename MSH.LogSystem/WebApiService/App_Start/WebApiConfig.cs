using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using WebApiService.Core.Filters;

namespace WebApiService.Core
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // Web API 路由
            config.MapHttpAttributeRoutes();
            
            config.Filters.AddRange(new List<IFilter>()
            {
                new HandleCustomExceptionAttribute(),
                new DeflateCompressionAttribute()
            });

            //移除xml格式
            var formatters = config.Formatters.Where(formatter =>
                formatter.SupportedMediaTypes.Where(media =>
                media.MediaType.ToString() == "application/xml" || media.MediaType.ToString() == "text/html").Count() > 0) //找到请求头信息中的介质类型
                .ToList();

            foreach (var match in formatters)
                config.Formatters.Remove(match);
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
