using SharedCsharpModels.Models;

namespace ChessAPI.Controllers.GetBord
{
    public class GetGameState : IGetGameState
    {
        public GameState GetGame(string gameId, string playerId)
        {
            var _gamesService = new GamesService();
            return _gamesService.Games
                .Find(q => q.GameId == gameId && (q.Player1.Id == playerId || q.Player2.Id == playerId));

        }
    }
}
