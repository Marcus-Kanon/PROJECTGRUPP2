using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        IGamesService _gamesService;

        public GameController(IGamesService gameService)
        {
            _gamesService = gameService;
        }

        // GET: api/game/create
        [HttpGet("create")]
        public string Create()
        { 
            string json = JsonConvert.SerializeObject(_gamesService.CreateNewGame(), Formatting.Indented);

            return json;
        }

        [HttpGet("list")]
        public string List()
        {
            string json = JsonConvert.SerializeObject(_gamesService.Games, Formatting.Indented);

            return json;
        }
    }
}
