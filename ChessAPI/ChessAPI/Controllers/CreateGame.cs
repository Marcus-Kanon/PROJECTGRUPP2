using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController]
    public class CreateGame : ControllerBase
    {
        IGamesService _myclass;

        public CreateGame(IGamesService myclass)
        {
            _myclass = myclass;
        }

        // GET: api/<CreateGame>
        [Route("api/[controller]")]
        [HttpGet]
        public string Get()
        {
            Random rnd = new();
            string player1Id = rnd.Next(0, 10000000).ToString();

            Game game = new()
            {
                GameId = rnd.Next(0, 10000000).ToString(),
                Player1Id = player1Id,
                Player2Id = rnd.Next(0, 10000000).ToString(),
                PlayerTurnId = player1Id
            };

            _myclass.Games.Add(game);

            string json = JsonConvert.SerializeObject(game, Formatting.Indented);

            return json;
        }
    }
}
