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
        private readonly IDictionary<int, Player> _playersById;
        private readonly IDictionary<string, Player> _playersByEmail;
        private readonly IDictionary<string, Player> _playersByNick;

        public PlayersController()
        {
            var player = new Player(
                42,
                "Doe",
                "John",
                new Address("Infinite Loop", "1/1/2", "1234", "Los Angeles", "Californication"),
                "john.doe@example.com",
                "jodo");

            _playersById = new Dictionary<int, Player> { { player.Id, player } };
            _playersByEmail = new Dictionary<string, Player> { { player.Email, player } };
            _playersByNick = new Dictionary<string, Player> { { player.NickName, player } };

        }
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
            if (_playersById.ContainsKey(id))
            {
                return _playersById[id];
            }

            throw new ArgumentOutOfRangeException(nameof(id), "No player found with that id.");
        }

        // GET api/values/byemail/someone@example.com
        // GET api/values/naughtiusmaximus
        [HttpGet("{emailornick}")]
        public async Task<Player> GetByEmailOrNick(string emailornick, CancellationToken cancellationToken)
        {
            if (_playersByEmail.ContainsKey(emailornick))
            {
                return _playersByEmail[emailornick];
            }

            if (_playersByNick.ContainsKey(emailornick))
            {
                return _playersByNick[emailornick];
            }

            throw new ArgumentOutOfRangeException(nameof(emailornick), "No player found with that email or nick.");
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
