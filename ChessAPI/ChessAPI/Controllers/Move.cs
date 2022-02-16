﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChessAPI.Controllers
{
    [ApiController]
    public class Move : ControllerBase
    {
        IGamesService _gamesService;

        public Move(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }


        // GET: api/<Move>
        [Route("api/[controller]/{gameId}/{playerId}/{newX}/{newY}/{oldX}/{oldY}")]
        [HttpGet]
        public string Get(string gameId, string playerId, int newX, int newY, int oldX, int oldY)
        {
            var game = _gamesService.Games.FirstOrDefault(q => q.GameId == gameId);

            if (game == null)
                return "No game found";

            if (playerId != game.PlayerTurnId)
                return "Not your turn";

            if (game.Board[oldX, oldY] == null)
                return "Position is null";

            return game.Board[oldX, oldY].Move((oldX, oldY), (newX, newY));
        }
    }
}
