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

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            return MoveValidationMessage.Succeeded;
        }
    }
}
