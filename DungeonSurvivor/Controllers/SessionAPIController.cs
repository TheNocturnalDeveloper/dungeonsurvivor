using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Logic;

namespace DungeonSurvivor.Controllers
{


    [Route("api/Session")]
    [ApiController]
    public class SessionAPIController : ControllerBase
    {
        // GET: api/Session
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Session/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Session
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }


    }
}
