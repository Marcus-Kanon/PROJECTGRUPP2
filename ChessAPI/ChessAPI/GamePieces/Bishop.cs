using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Bishop : GamePiece
    {
        public override string Name
        {
            get { if (Color == true) { return "\u2657"; } else { return "\u265D"; } }
        }

        public Bishop(Game game, bool color) : base(game, color)
        {
            Type = PieceType.Bishop;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);

            return "Successfully moved bishop... i think...";
        }
    }
}
