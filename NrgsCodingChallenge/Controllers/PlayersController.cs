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
        [HttpGet("{email:regex(^([[0-9a-zA-Z]]([[-\\.\\w]]*[[0-9a-zA-Z]])*@([[0-9a-zA-Z]][[-\\w]]*[[0-9a-zA-Z]]\\.)+[[a-zA-Z]]{{2,9}})$)}")]
        public async Task<Player> GetByEmail(string email, CancellationToken cancellationToken)
        {
            if (_playersByEmail.ContainsKey(email))
            {
                return _playersByEmail[email];
            }

            throw new ArgumentOutOfRangeException(nameof(email), "No player found with that email or nick.");
        }

        [HttpGet("{nick}")]
        public async Task<Player> GetByNick(string nick, CancellationToken cancellationToken)
        {
            if (_playersByNick.ContainsKey(nick))
            {
                return _playersByNick[nick];
            }

            throw new ArgumentOutOfRangeException(nameof(nick), "No player found with that email or nick.");
        }
    }
}
