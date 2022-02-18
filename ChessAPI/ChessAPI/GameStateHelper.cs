using SharedCsharpModels.Models;

namespace ChessAPI
{
    public class GameStateHelper : GameState
    {
        public void ChangePlayerTurn()
        {
            if (Player1Id == PlayerTurnId)
                PlayerTurnId = Player2Id;
            else
                PlayerTurnId = Player1Id;
        }
    }
}
