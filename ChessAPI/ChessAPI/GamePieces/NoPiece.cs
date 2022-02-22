using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public class NoPiece : GamePiece
    {
        public override string Name { get; set; } = " ";
        
        public NoPiece(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.NoPiece;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {

            return MoveValidationMessage.IllegalMove;
        }
    }
}
