using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorld.Controllers
{
    public class HelloController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Get(null);
        }
        public IHttpActionResult Get(string name)
        {
            return Json( new
            {
                
                Text = $"Hello {name ??"world" }",
                Date = DateTime.Now
            });
        }
    }
}
