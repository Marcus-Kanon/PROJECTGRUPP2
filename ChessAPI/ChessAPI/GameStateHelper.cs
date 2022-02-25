using SharedCsharpModels.Models;

namespace ChessAPI
{
    public class GameStateHelper
    {
        GameState _gameState;

        public GameStateHelper(GameState gameState)
        {
            _gameState = gameState;
        }

        public void ChangePlayerTurn()
        {
            if (_gameState.Player1.IsPlayerTurn)
            {
                _gameState.Player1.IsPlayerTurn = false;
                _gameState.Player2.IsPlayerTurn = true;
            }
            else
            {
                _gameState.Player1.IsPlayerTurn = true;
                _gameState.Player2.IsPlayerTurn = false;
            }
        }
    }
}
