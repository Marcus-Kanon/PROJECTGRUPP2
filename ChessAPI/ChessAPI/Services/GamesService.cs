using SharedCsharpModels.Models;
using ChessAPI.GamePieces;

namespace ChessAPI
{
    public class GamesService : IGamesService
    {
        const int BOARD_WIDTH = 8;
        const int BOARD_HEIGHT = 8;

        public List<GameState> Games { get; set; }

        public GamesService()
        {
            Games = new List<GameState>();
        }

        public GameState CreateNewGame()
        {
            Random rnd = new();
            GameState game = new();

            string player1Id = rnd.Next(0, 10000000).ToString();

            game.GameId = rnd.Next(0, 10000000).ToString();
            game.Player1Id = player1Id;
            game.Player2Id = rnd.Next(0, 10000000).ToString();
            game.PlayerTurnId = player1Id;
            game.Board = CreateBoard(BOARD_WIDTH, BOARD_HEIGHT, game);

            Games.Add(game);

            return game;
        }

        public GamePiece[,] CreateBoard(int boardWidth, int boardHeight, GameState game)
        {
            GamePiece[,] Board = new GamePiece[boardWidth, boardHeight];

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    Board[x, y] = new NoPiece(game);
                }
            }

            Board = new GamePiece[BOARD_WIDTH, BOARD_WIDTH]
            {
                { new Rook(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new Rook(game, false) },
                { new Knight(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new Knight(game, false) },
                { new Bishop(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new Bishop(game, false) },
                { new Queen(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new King(game, false) },
                { new King(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new Queen(game, false) },
                { new Bishop(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new Bishop(game, false) },
                { new Knight(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new Knight(game, false) },
                { new Rook(game, true), new Pawn(game, true), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new Pawn(game, false), new Rook(game, false) },
            };

            return Board;
        }
    }
}
