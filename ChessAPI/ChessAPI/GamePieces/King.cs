using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        public override string Name { get; set; } = "King";
        Game _game;
        
        public King(Game game, bool color)
        {
            _game = game;

        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
            _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);

            return "Successfully moved king... i think...";
        }
    }
}
