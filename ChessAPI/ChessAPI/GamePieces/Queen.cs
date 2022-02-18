using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Queen : GamePiece
    {
        public override string Name { get; set; } = "\u2655";

        public Queen(Game game, bool color) : base(game, color)
        {
            Type = PieceType.Queen;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
            return "Successfully moved queen... i think...";
        }
    }
}
