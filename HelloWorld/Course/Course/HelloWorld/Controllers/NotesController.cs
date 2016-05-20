using HelloApp.Entities;
using HelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HelloWorld.Controllers
{
    public class NotesController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Json(Collection.vertex.arrayWeighted);
        }
        public IHttpActionResult Get(int id)
        {
            // Newtonsoft.Json
            var note = Collection.vertex.arrayWeighted.FirstOrDefault(n => n.Key == id);
            if (note.Key == 0)
            {
                return NotFound();
            }
            return Json(note);
        }
        //public IHttpActionResult Post(Vertex note)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Collection.Add(note);
        //        return Created($"/api/Notes/{note.Id}", note);
        //    }

        //    return BadRequest();
        //}
        public IHttpActionResult Delete(int id)
        {
            var note = Collection.vertex.arrayWeighted.FirstOrDefault(n => n.Key == id);
            if (note.Key == 0)
            {
                return NotFound();
            }
            Collection.vertex.arrayWeighted.Remove(id);
            return Ok();
        }
        public IHttpActionResult Put(int id, [FromBody]Vertex note)
        {
            if (!Collection.vertex.arrayWeighted.ContainsKey(id))
            {
                return NotFound();
            }

            var stored = Collection.vertex.arrayWeighted[id];
            
            return Ok(stored);
        }
    }
}
