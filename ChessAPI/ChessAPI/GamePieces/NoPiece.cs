using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class NoPiece : GamePiece
    {
        public override string Name { get; set; } = " No ";
        Game _game;
        
        public NoPiece(Game game)
        {
            _game = game;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            return "No Piece. Cannot move.";
        }
    }
}
