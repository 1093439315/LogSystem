using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace MSH.Log.WindowsService
{
    public partial class MSHLogService : ServiceBase
    {
        private HttpSelfHostServer _server;
        private HttpSelfHostConfiguration _config;
        public const string ServiceAddress = "http://localhost:1345";

        public MSHLogService()
        {
            InitializeComponent();

            _config = new HttpSelfHostConfiguration(ServiceAddress);
            _config.Routes.MapHttpRoute("DefaultApi",
                "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });
        }

        protected override void OnStart(string[] args)
        {
            _server = new HttpSelfHostServer(_config);
            _server.OpenAsync();
        }

        protected override void OnStop()
        {
            _server.CloseAsync().Wait();
            _server.Dispose();
        }
    }
}
