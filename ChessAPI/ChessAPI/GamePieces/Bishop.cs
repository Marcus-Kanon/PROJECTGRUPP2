using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Bishop : GamePiece
    {
        //public override string Name { get; set; } = "\u2657";
        public override string Name { get; set; } = "B";

        public Bishop(Game game, bool color) : base(game, color)
        {
            Type = PieceType.Bishop;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            if (!(CheckLegalMove(oldCords, newCords))) { return "Illegal move"; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);

                return "Successfully moved bishop... i think...";
            }
        }

        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            if (first.Item2 == second.Item2 || first.Item1 == second.Item1)
            {

                //Console.WriteLine("hej");
                //Console.ReadLine();
                return false;

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
