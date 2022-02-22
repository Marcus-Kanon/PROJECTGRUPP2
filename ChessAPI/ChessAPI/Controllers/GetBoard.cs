using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedCsharpModels.Models;

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
            GameState game = _gamesService.Games
                .FirstOrDefault(q => q.GameId == gameId && (q.Player1.Id == playerId || q.Player2.Id == playerId));

            var json = JsonConvert.SerializeObject(game);

            return json;
        }
    }
}
