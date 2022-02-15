﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    
    [ApiController]
    public class GetBoard : ControllerBase
    {
        // GET: api/<GetBoard>
        [Route("api/[controller]")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var game = new Game() { MatchId="123123123" };
            return new string[] { "value1", "value2" };
        }
    }
}
