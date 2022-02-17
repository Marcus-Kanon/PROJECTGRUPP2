using ChessAPI.GamePieces;
using ChessAPI.Models;

namespace ChessAPI
{
    public class Game
    {
        const int BOARD_WIDTH = 8;

        public GamePiece[,] Board { get; set; }
        public string GameId { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        public string PlayerTurnId { get; set; }

        public Game()
        {
            Board = new GamePiece[BOARD_WIDTH, BOARD_WIDTH];

            for (int x = 0; x < BOARD_WIDTH; x++)
            {
                for (int y = 0; y < BOARD_WIDTH; y++)
                {
                    Board[x, y] = new NoPiece(Board);
                }
            }

            //Board[2, 0] = new King(Board);

            Board = new GamePiece[BOARD_WIDTH, BOARD_WIDTH]
            {
                { new Rook(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new Rook(Board) },
                { new Knight(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new Knight(Board) },
                { new Bishop(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new Bishop(Board) },
                { new Queen(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new King(Board) },
                { new King(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new Queen(Board) },
                { new Bishop(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new Bishop(Board) },
                { new Knight(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new Knight(Board) },
                { new Rook(Board), new Pawn(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new NoPiece(Board), new Pawn(Board), new Rook(Board) },
            };
        }
    }
}
