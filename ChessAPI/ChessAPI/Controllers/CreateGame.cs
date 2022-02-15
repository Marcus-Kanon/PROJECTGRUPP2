using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController]
    public class CreateGame : ControllerBase
    {
        // GET: api/<CreateGame>
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var game = new Game();

            MyStaticClass.

            return new string[] { game.MatchId, game.Player1Id, game.Player2Id };
        }
    }
}
