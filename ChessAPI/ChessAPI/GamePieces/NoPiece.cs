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
        /// <summary>
        /// Returns the move validation message illegal move if the player tries to move anything from an empty cell. More of a place holder for empty cells.
        /// /// </summary>
        /// <param name="oldCords">The current coordinates..</param>
        /// <param name="newCords">The new coordinates..</param>
        /// <returns></returns>

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            if (!CheckLegalMove(oldCords, newCords)) { return MoveValidationMessage.IllegalMove; }
            else
            {
                return MoveValidationMessage.IllegalMove;
            }
        }
    }
}
