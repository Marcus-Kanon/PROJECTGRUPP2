using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class NoPiece : GamePiece
    {
        public override string Name { get; set; } = " ";
        
        public NoPiece(Game game) : base(game, null)
        {
            Type = PieceType.NoPiece;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            return "No Piece. Cannot move.";
        }
        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            return false;
        }
}
