using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NrgsCodingChallenge.Models;

namespace NrgsCodingChallenge.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        // GET api/players
        [HttpGet]
        public async Task<IEnumerable<string>> Get(CancellationToken cancellationToken)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public async Task<Player> GetById(int id, CancellationToken cancellationToken)
        {
            return new Player(id, "Doe", "John", 
                new Address("Infinite Loop", "1/1/2", "1234", "Los Angeles", "Californication"));
        }

        // GET api/values/byemail/someone@example.com
        // GET api/values/naughtiusmaximus
        [HttpGet("{emailornick}")]
        public async Task<string> GetByEmailOrNick(string emailornick, CancellationToken cancellationToken)
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
        public async Task Post([FromBody]string value, CancellationToken cancellationToken)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]string value, CancellationToken cancellationToken)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
        }
    }
}
