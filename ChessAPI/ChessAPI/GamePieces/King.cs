using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        public override string Name { get => "\u265A"; }
        //public override string Name { get => "K"; }

        public King(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.King;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game, Color);

            return MoveValidationMessage.Succeeded;
        }
    }
}
