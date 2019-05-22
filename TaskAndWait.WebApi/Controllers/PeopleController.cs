using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskAndAwait.Shared;

namespace TaskAndWait.WebApi.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = People.GetPeople();
        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.SingleOrDefault(p => p.Id == id);
        }

        // POST: api/People
        public void Post([FromBody]Person value)
        {
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]Person value)
        {
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
