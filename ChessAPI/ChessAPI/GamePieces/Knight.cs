using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class Knight : GamePiece
    {
        public override string Name { get => "\u265E"; }

        public Knight(GameState game, bool color) : base(game, color)
        {
            Type = PieceType.Knight;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
            return MoveValidationMessage.Succeeded;
        }
    }
}
