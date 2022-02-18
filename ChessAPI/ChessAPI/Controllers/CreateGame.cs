using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController]
    public class CreateGame : ControllerBase
    {
        IGamesService _gamesService;

        public CreateGame(IGamesService myclass)
        {
            _gamesService = myclass;
        }

        // GET: api/<CreateGame>
        [Route("api/[controller]")]
        [HttpGet]
        public string Get()
        { 
            string json = JsonConvert.SerializeObject(_gamesService.CreateNewGame(), Formatting.Indented);

            return json;
        }
    }
}
