using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Rook : GamePiece
    {
        public override string Name
        {
            get { if (Color == true) { return "\u2656"; } else { return "\u265C"; } }
        }

        public Rook(Game game, bool color) : base(game, color)
        {
            Type = PieceType.Rook;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
            return "Successfully moved rook... i think...";
        }
    }
}
