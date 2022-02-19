using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Knight : GamePiece
    {
        public override string Name { get; set; } = "\u2658";

        public Knight(Game game, bool color) : base(game, color)
        {

            Type = PieceType.Knight;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            if (!(CheckLegalMove(oldCords, newCords))) { return "Illegal move"; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
                return "Successfully moved knight... i think...";
            }


        }
        public bool CheckLegalMove((int, int) first, (int, int) second)
        {
            return (Math.Abs(first.Item2 - second.Item2) == 2 && Math.Abs(first.Item1 - second.Item1) == 1 && !(_game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == this.Color));
 

        }
    }
}
