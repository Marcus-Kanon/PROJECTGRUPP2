using SharedCsharpModels.Models;

namespace ChessAPI.Controllers.GetBord
{
    public interface IGetGameState
    {
        GameState GetGame(string gameId, string playerId);
    }
}