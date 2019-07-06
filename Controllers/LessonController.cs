using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace cloudrest.Controllers
{
    public class LessonController : ApiController
    {
        // GET: api/Lesson
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Lesson/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Lesson
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Lesson/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Lesson/5
        public void Delete(int id)
        {
        }
    }
}
