using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    
    [ApiController]
    public class GetBoard : ControllerBase
    {
        IGamesService _gamesService;

        public GetBoard(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        // GET: api/<GetBoard>
        [Route("api/[controller]/{gameId}/{playerId}")]
        [HttpGet]
        public string Get(string gameId, string playerId)
        {
            var game = _gamesService.Games
                .FirstOrDefault(q => q.GameId == gameId && (q.Player1Id == playerId || q.Player2Id == playerId));

            var json = JsonConvert.SerializeObject(game);

            return json;
        }
    }
}
