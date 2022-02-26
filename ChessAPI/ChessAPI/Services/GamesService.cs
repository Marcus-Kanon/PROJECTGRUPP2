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

        /// <summary>
        /// Creates a new game by preloading a chessboard with chesspieces and randomly generating six digit numbers for game ID and players ID.
        /// </summary>
        /// <returns></returns>
        public GameState CreateNewGame()
        {
            Random rnd = new();
            GameState game = new();

            string player1Id = rnd.Next(0, 10000000).ToString();
            string player2Id = rnd.Next(0, 10000000).ToString();

            game.GameId = rnd.Next(0, 10000000).ToString();
            game.Player1 = new() {Id = player1Id, Color = Color.Light, IsPlayerTurn = true };
            game.Player2 = new() { Id = player2Id, Color = Color.Dark, IsPlayerTurn = false };
            game.Board = CreateBoard(BOARD_WIDTH, BOARD_HEIGHT, game);

            Games.Add(game);

            return game;
        }
        /// <summary>
        /// Creates a new 2D array of type GamePiece, and fills the array with new GamePieces, where each piece has its own unique x and y coordinates.
        /// </summary>
        /// <param name="boardWidth">Chessboard width.</param>
        /// <param name="boardHeight">Chessboard height.</param>
        /// <param name="game">The current gamestate.</param>
        /// <returns></returns>
        public GamePiece[,] CreateBoard(int boardWidth, int boardHeight, GameState game)
        {
            GamePiece[,] Board = new GamePiece[boardWidth, boardHeight];

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    Board[x, y] = new NoPiece(game, Color.Empty);
                }
            }

            Board = new GamePiece[BOARD_WIDTH, BOARD_HEIGHT]
            //{
            //    { new Rook(game, Color.Light),   new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new Rook(game, Color.Dark) },
            //    { new Knight(game, Color.Light), new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new Knight(game, Color.Dark) },
            //    { new Bishop(game, Color.Light), new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new Bishop(game, Color.Dark) },
            //    { new King(game, Color.Light),   new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new Queen(game, Color.Dark) },
            //    { new Queen(game, Color.Light),  new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new King(game, Color.Dark) },
            //    { new Bishop(game, Color.Light), new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new Bishop(game, Color.Dark) },
            //    { new Knight(game, Color.Light), new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new Knight(game, Color.Dark) },
            //    { new Rook(game, Color.Light),   new Pawn(game, Color.Light),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new Pawn(game, Color.Dark), new Rook(game, Color.Dark) },
            //};
 
            {
                { new NoPiece(game, Color.Empty),       new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Light), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),   new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty),      new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),    new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty),     new Bishop(game, Color.Light),  new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),    new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty),        new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),  new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty),       new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new Pawn(game, Color.Dark), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),   new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty),      new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),    new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty),      new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),    new NoPiece(game, Color.Empty) },
                { new NoPiece(game, Color.Empty),        new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),     new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty), new NoPiece(game, Color.Empty),  new NoPiece(game, Color.Empty) },
            };
            return Board;
        }
    }
}
