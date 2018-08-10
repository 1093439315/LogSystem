using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin.Cors;
using MapperConfiguration;

[assembly: OwinStartup(typeof(WebApiService.Core.Startup))]
namespace WebApiService.Core
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //跨域配置
            app.UseCors(CorsOptions.AllowAll);

            WebApiConfig.Register(config);
            AutofacConfig.Register(config);
            SwaggerConfig.Register(config);

            app.UseWebApi(config);
            app.MapSignalR();

            MapperConfig.Initial();
        }
    }
}
