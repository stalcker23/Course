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
            return Json(Collection.massive_vertex);
        }
        public IHttpActionResult Get(int id)
        {
            // Newtonsoft.Json
            var note = Collection.massive_vertex.allVertices.FirstOrDefault(n => n.Key == id);
            if (note.Key == 0)
            {
                return NotFound();
            }
            return Json(note);
        }
        //public IHttpActionResult Post(AllVertices note)
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
            var note = Collection.massive_vertex.allVertices.FirstOrDefault(n => n.Key == id);
            if (note.Key == 0)
            {
                return NotFound();
            }
            Collection.massive_vertex.allVertices.Remove(id);
            return Ok();
        }
        public IHttpActionResult Put(int id, [FromBody]AllVertices note)
        {
            if (!Collection.massive_vertex.allVertices.ContainsKey(id))
            {
                return NotFound();
            }

            var stored = Collection.massive_vertex.allVertices[id];
            
            return Ok(stored);
        }
    }
}
