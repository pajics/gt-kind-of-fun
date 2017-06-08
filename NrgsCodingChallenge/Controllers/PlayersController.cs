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
        [HttpGet("{id:int}")]
        public string GetById(int id)
        {
            return "Id: " + id;
        }

        [HttpGet("{email:regex(^([[0-9a-zA-Z]]([[-\\.\\w]]*[[0-9a-zA-Z]])*@([[0-9a-zA-Z]][[-\\w]]*[[0-9a-zA-Z]]\\.)+[[a-zA-Z]]{{2,9}})$)}")]
        public string GetByEmail(string email)
        {
            return "Email: " + email;
        }

        [HttpGet("{nick}")]
        public string GetByNick(string nick)
        {
            return "Nick: " + nick;
        }
    }
}
