using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Controllers
{
    public class NotesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Json(Collection.graph);
        }

    }
}
