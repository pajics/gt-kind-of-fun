using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NrgsCodingChallenge.Models;
using NrgsCodingChallenge.Repositories;

namespace NrgsCodingChallenge.Controllers
{
    [Route("api/[controller]")]
    public class PlayersController : Controller
    {
        private readonly IDataProvider _dataProvider;


        public PlayersController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            Player player = _dataProvider.GetById(id);

            if (player != null)
            {
                return new ObjectResult(player);
            }

            return new NotFoundResult();
        }

        // GET api/values/byemail/someone@example.com
        // GET api/values/naughtiusmaximus        
        [HttpGet("{email:regex(^([[0-9a-zA-Z]]([[-\\.\\w]]*[[0-9a-zA-Z]])*@([[0-9a-zA-Z]][[-\\w]]*[[0-9a-zA-Z]]\\.)+[[a-zA-Z]]{{2,9}})$)}")]
        public async Task<Player> GetByEmail(string email, CancellationToken cancellationToken)
        {
            Player player = _dataProvider.GetByEmail(email);

            if (player != null)
            {
                return player;
            }

            throw new ArgumentOutOfRangeException(nameof(email), "No player found with that email or nick.");
        }

        [HttpGet("{nick}")]
        public async Task<Player> GetByNick(string nick, CancellationToken cancellationToken)
        {
            Player player = _dataProvider.GetByNick(nick);

            if (player != null)
            {
                return player;
            }

            throw new ArgumentOutOfRangeException(nameof(nick), "No player found with that email or nick.");
        }
    }
}
