using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        public string Name { get; set; } = "King";
        public GamePiece[,] _board { get; set; }   
        
        public King(GamePiece [,] board)
        {
            _board = board;

        }

        public string Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
    }
}
