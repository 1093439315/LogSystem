using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MSH.Log.WindowsService.ApiControllers
{
    public class LogServiceController
    {
        [HttpGet]
        public string Get()
        {
            return "Hello from windows service!";
        }
    }
}
