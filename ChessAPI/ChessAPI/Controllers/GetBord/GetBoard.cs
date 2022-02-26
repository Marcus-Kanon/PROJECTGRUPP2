using ChessAPI.Controllers.GetBord;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SharedCsharpModels.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController]
    public class GetBoard : ControllerBase
    {
        private GetGameState _getGameState;

        public GetBoard(GetGameState getGameState)
        {
            _getGameState = getGameState;
        }

        // GET: api/<GetBoard>
        [Route("api/[controller]/{gameId}/{playerId}")]
        [HttpGet]
        public string Get(string gameId, string playerId)
        {
            GameState game = _getGameState.GetGame(gameId, playerId);
            var json = JsonConvert.SerializeObject(game);

            return json;
        }
    }
}
