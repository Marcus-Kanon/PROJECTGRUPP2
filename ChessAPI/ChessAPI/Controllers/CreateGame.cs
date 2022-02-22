using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class CreateGame : ControllerBase
    {
        IGamesService _gamesService;

        public CreateGame(IGamesService gameService)
        {
            _gamesService = gameService;
        }

        // CREATE: api/creategame/create
        [HttpGet("create")]
        public string Create()
        {
            string json = JsonConvert.SerializeObject(_gamesService.CreateNewGame(), Formatting.Indented);

            return json;
        }

        // LIST: api/creategame/list
        [HttpGet("list")]
        public string List()
        {
            string json = JsonConvert.SerializeObject(_gamesService.Games, Formatting.Indented);

            return json;
        }
    }
}
