using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class Rook : GamePiece
    {
        public override string Name { get => "\u2656"; }

        public Rook(GameState game, bool color) : base(game, color)
        {
            Type = PieceType.Rook;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
            return MoveValidationMessage.Succeeded;
        }
    }
}
