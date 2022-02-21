using System.Drawing;
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

            game.GameId = rnd.Next(0, 10000000).ToString();
            game.Player1.PlayerID = player1Id;
            game.Player2.PlayerID = rnd.Next(0, 10000000).ToString();
            game.MovingPlayer.PlayerID = player1Id;
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
                    Board[x, y] = new NoPiece(game);
                }
            }

            Board = new GamePiece[BOARD_WIDTH, BOARD_HEIGHT]
            {
                { new Rook(game, false), new Knight(game, false), new Bishop(game, false), new Queen(game, false), new King(game, false), new Bishop(game, false), new Knight(game, false), new Rook(game, false) },
                { new Pawn(game, false), new Pawn(game, false), new Pawn(game, false), new Pawn(game, false), new Pawn(game, false), new Pawn(game, false), new Pawn(game, false), new Pawn(game, false) },
                { new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game) },
                { new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game) },
                { new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game) },
                { new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game), new NoPiece(game) },
                { new Pawn(game, true), new Pawn(game, true), new Pawn(game, true), new Pawn(game, true), new Pawn(game, true), new Pawn(game, true), new Pawn(game, true), new Pawn(game, true) },
                { new Rook(game, true), new Knight(game, true), new Bishop(game, true), new Queen(game, true), new King(game, true), new Bishop(game, true), new Knight(game, true), new Rook(game, true) },
            };

            return Board;
        }

        /* TODO: Behöver se hur MoveHelper blir för att implementera så man kan se vart man kan röra sin pjäs (om vi vill ha med det)
        public void DisplayNextLegalMoves(GamePiece currentCell, GamePiece chessPiece)
        {
            // step 1 - clear all previous legal moves
            for (int i = 0; i < BOARD_WIDTH; i++)
            {
                for (int j = 0; j < BOARD_HEIGHT; j++)
                {
                    Board[i, j].IsLegalMove = false;
                    Board[i, j].CurrentlyOccupied = false;
                }
            }


            // step 2 - find all legal moves and mark the cells as "legal"
            switch (chessPiece)
            {
                case Knight:
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;
                case King:
                    break;
                case Rook:
                    break;
                case Bishop:
                    break;
                case Queen:
                    break;
                default:
                    break;

            }
            Board[currentCell.BOARD_WIDTH, currentCell.BOARD_HEIGHT].CurrentlyOccupied = true;
        }
        */
    }
}
