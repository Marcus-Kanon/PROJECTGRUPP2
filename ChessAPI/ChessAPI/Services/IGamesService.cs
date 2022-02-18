using SharedCsharpModels.Models;

namespace ChessAPI
{
    public interface IGamesService
    {
        public List<GameState> Games { get; set; }
        public GameState CreateNewGame();
        public GamePiece[,] CreateBoard(int boardWidth, int boardHeight, GameState game);
    }
}
