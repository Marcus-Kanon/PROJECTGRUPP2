//using System.Drawing;
using ChessAPI.GamePieces;
using SharedCsharpModels.Models;

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
            string player2Id = rnd.Next(0, 10000000).ToString();

            game.GameId = rnd.Next(0, 10000000).ToString();
            game.Player1 = new(player1Id, Color.Light);
            game.Player2 = new(player2Id, Color.Dark);
            game.Board = CreateBoard(BOARD_WIDTH, BOARD_HEIGHT, game);

            Games.Add(game);

            return game;
        }

        public GamePiece[,] CreateBoard(int boardWidth, int boardHeight, GameState game)
        {
            // skapar ny 2D array av typen GamePiece
            GamePiece[,] Board = new GamePiece[boardWidth, boardHeight];

            // fyller 2D arrayen med nya GamePieces, där varje har sin "unika" x och y koordinat
            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    Board[x, y] = new NoPiece(game, Color.Empty);
                }
            }

            Board = new GamePiece[BOARD_WIDTH, BOARD_HEIGHT]
            {
                { new Rook(game, Color.Dark), new Knight(game, Color.Dark), new Bishop(game, Color.Dark), new Queen(game, Color.Dark), new King(game, Color.Dark), new Bishop(game, Color.Dark), new Knight(game, Color.Dark), new Rook(game, Color.Dark) },
                { new Pawn(game, Color.Dark), new Pawn(game, Color.Dark), new Pawn(game, Color.Dark), new Pawn(game, Color.Dark), new Pawn(game, Color.Dark), new Pawn(game, Color.Dark), new Pawn(game, Color.Dark), new Pawn(game, Color.Dark) },
                { new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty) },
                { new Pawn(game, Color.Light), new Pawn(game, Color.Light), new Pawn(game, Color.Light), new Pawn(game, Color.Light), new Pawn(game, Color.Light), new Pawn(game, Color.Light), new Pawn(game, Color.Light), new Pawn(game, Color.Light) },
                { new Rook(game, Color.Light), new Knight(game, Color.Light), new Bishop(game, Color.Light), new King(game, Color.Light), new Queen(game, Color.Light), new Bishop(game, Color.Light), new Knight(game, Color.Light), new Rook(game, Color.Light) },
            };

            return Board;
        }
    }
}
