using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Queen : GamePiece
    {
        public override string Name { get; set; } = "\u2655";
        GamePiece[,] _board;
        
        public Queen(GamePiece [,] board)
        {
            _board = board;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _board[newCords.Item1, newCords.Item2] = new Queen(_board);
            _board[oldCords.Item1, oldCords.Item2] = new NoPiece(_board);

            return "Successfully moved queen... i think...";
        }
    }
}
