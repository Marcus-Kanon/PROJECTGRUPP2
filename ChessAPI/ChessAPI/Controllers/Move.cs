using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedCsharpModels.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController]
    public class Move : ControllerBase
    {
        readonly IGamesService _gamesService;

        public Move(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        // GET: api/<Move>
        [Route("api/[controller]/{gameId}/{playerId}/{oldX}/{oldY}/{newX}/{newY}")]
        [HttpGet]
        public string Get(string gameId, string playerId, int newX, int newY, int oldX, int oldY)
        {
            GameState game = _gamesService.Games.Find(q => q.GameId == gameId) ?? new GameState();

            if (game == null)
                return "No game found";

            if (playerId == game.Player1.Id && !game.Player1.IsPlayerTurn)
                return $"Not your turn {game.Player1.Id}";

            if (playerId == game.Player2.Id && !game.Player2.IsPlayerTurn)
                return $"Not your turn {game.Player2.Id}";

            if (game.Board == null || game.Board[oldX, oldY] == null)
                return "Position is null";

            string json = JsonConvert.SerializeObject(game.Board[oldX, oldY].Move((oldX, oldY), (newX, newY)));

            return json;
        }
    }
}
