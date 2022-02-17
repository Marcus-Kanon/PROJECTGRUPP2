using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Bishop : GamePiece
    {
        public override string Name { get; set; } = "\u2657";
        GamePiece[,] _board;
        
        public Bishop(GamePiece [,] board)
        {
            _board = board;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _board[newCords.Item1, newCords.Item2] = new Bishop(_board);
            _board[oldCords.Item1, oldCords.Item2] = new NoPiece(_board);

            return "Successfully moved bishop... i think...";
        }
    }
}
