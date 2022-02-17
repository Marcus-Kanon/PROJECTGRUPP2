using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        public override string Name { get; set; } = "\u2654";
        GamePiece[,] _board;
        
        public King(GamePiece [,] board)
        {
            _board = board;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _board[newCords.Item1, newCords.Item2] = new King(_board);
            _board[oldCords.Item1, oldCords.Item2] = new NoPiece(_board);

            return "Successfully moved king... i think...";
        }
    }
}
