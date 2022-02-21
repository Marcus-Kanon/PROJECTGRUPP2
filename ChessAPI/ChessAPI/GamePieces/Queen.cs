using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Queen : GamePiece
    {
        //public override string Name { get; set; } = "\u2655";
        public override string Name { get; set; } = "Q";

        public Queen(Game game, bool color) : base(game, color)
        {
            Type = PieceType.Queen;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            if (!(CheckLegalMove(oldCords, newCords))) { return "Illegal move"; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
                return "Successfully moved queen... i think...";
            }



        }
        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            if (first.Item2 == second.Item2)
            {
                return MoveHelper.LegalMoveHorizontal(first, second, _game, (first.Item1 < second.Item1));
                 
            }
            else if (first.Item1 == second.Item1)
            {
                return MoveHelper.LegalMoveVertical (first, second, _game, (first.Item2 < second.Item2));
            }
            else if (second.Item1 < first.Item1)
            {
                return MoveHelper.LegalMoveLeftDiagonals(first, second, _game, (second.Item2 > first.Item2));

            }
            else 
            {
                return MoveHelper.LegalMoveRightDiagonals(first, second, _game, (second.Item2 > first.Item2));
            }
 
        }
    }
}
