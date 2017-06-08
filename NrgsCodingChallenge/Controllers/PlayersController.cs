using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NrgsCodingChallenge.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        // GET api/players
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public string GetById(int id)
        {
            return id.ToString();
        }

        // GET api/values/byemail/someone@example.com
        // GET api/values/naughtiusmaximus
        [HttpGet("{emailornick}")]
        public string GetByEmailOrNick(string emailornick)
        {
            return emailornick;
        }

        //[HttpGet("/bynickname/{nickname}")]
        //public string GetByNickname(string nickname)
        //{
        //    return nickname;
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
