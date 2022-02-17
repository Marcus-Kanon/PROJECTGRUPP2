using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Rook : GamePiece
    {
        public override string Name { get; set; } = "\u2656";
        GamePiece[,] _board;
        
        public Rook(GamePiece [,] board)
        {
            _board = board;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _board[newCords.Item1, newCords.Item2] = new Rook(_board);
            _board[oldCords.Item1, oldCords.Item2] = new NoPiece(_board);

            return "Successfully moved rook... i think...";
        }
    }
}
