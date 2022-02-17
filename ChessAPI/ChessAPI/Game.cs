using ChessAPI.GamePieces;
using ChessAPI.Models;

namespace ChessAPI
{
    public class Game : GameState
    {
        const int BOARD_WIDTH = 8;
        const int BOARD_HEIGHT = 8;

        public Game()
        {
            CreateNewGame();
            CreateBoard(BOARD_WIDTH, BOARD_HEIGHT);
        }

        public Game CreateNewGame()
        {
            Random rnd = new();
            string player1Id = rnd.Next(0, 10000000).ToString();

            GameId = rnd.Next(0, 10000000).ToString();
            Player1Id = player1Id;
            Player2Id = rnd.Next(0, 10000000).ToString();
            PlayerTurnId = player1Id;

            return this;
        }

        public void CreateBoard(int boardWidth, int boardHeight)
        {
            Board = new GamePiece[boardWidth, boardHeight];

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    Board[x, y] = new NoPiece(this);
                }
            }


            Board[2, 0] = new King(this, true);
        }

        public void ChangePlayerTurn()
        {
            if (Player1Id == PlayerTurnId)
                PlayerTurnId = Player2Id;
            else
                PlayerTurnId = Player1Id;
        }
    }
}
