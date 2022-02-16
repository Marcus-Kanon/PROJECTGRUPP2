using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class NoPiece : GamePiece
    {
        public string Name { get; set; } = "";
        public GamePiece[,] _board { get; set; }   
        
        public NoPiece(GamePiece [,] board)
        {
            _board = board;

        }

        public string Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
    }
}
