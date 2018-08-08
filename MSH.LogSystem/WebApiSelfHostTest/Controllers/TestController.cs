using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiSelfHostTest.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public string TestGet()
        {
            return "hello";
        }
    }
}
