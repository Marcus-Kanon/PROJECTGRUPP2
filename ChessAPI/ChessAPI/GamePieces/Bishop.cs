using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public class Bishop : GamePiece
    {
        public override string Name { get => "\u265D"; }

        public Bishop(GameState game, bool color) : base(game, color)
        {
            Type = PieceType.Bishop;

        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);

            return MoveValidationMessage.Succeeded;
        }
    }
}
