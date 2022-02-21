using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        //public override string Name { get; set; } = "\u2654";        
        public override string Name { get; set; } = "K";

        public King(Game game, bool color) : base(game, color)
        {
            Type = PieceType.King;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            if (!(CheckLegalMove(oldCords, newCords))) { return "Illegal move"; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);

                return "Successfully moved king... i think...";
            }
        }

        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            //return !CanAnyMoveTo(second) 
            return true;
        }

    }
}
