using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public class Bishop : GamePiece
    {
        public override string Name { get => "\u265D"; }

        public Bishop(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.Bishop;

        }


        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            if (_game.MovingPlayer.Color != Color)
                return MoveValidationMessage.WrongColor;

            if (!(CheckLegalMove(oldCords, newCords))) { return MoveValidationMessage.IllegalMove; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game, Color.Empty);

                var gamestatehelper = new GameStateHelper(_game);
                gamestatehelper.ChangePlayerTurn();

                return MoveValidationMessage.Succeeded;
            }
        }

        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            //return true;
            if (first.Item2 == second.Item2 || first.Item1 == second.Item1)
            {
 
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
