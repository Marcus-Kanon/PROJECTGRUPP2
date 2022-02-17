using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Pawn : GamePiece
    { 
         
        public override string Name { get; set; } = "\u2659";  //white pawn unicode
        GamePiece[,] _board;
        public Pawn(GamePiece [,] board)
        {
            _board = board;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _board[newCords.Item1, newCords.Item2] = new Pawn(_board);
            _board[oldCords.Item1, oldCords.Item2] = new NoPiece(_board);

            return "Successfully moved pawn... i think...";
        }
    }
}
