using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class Rook : GamePiece
    {
        public override string Name { get => "\u265C"; }

        public Rook(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.Rook;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            if (_game.MovingPlayer.Color != Color)
                return MoveValidationMessage.WrongPlayerTurn;

            if (!(CheckLegalMove(oldCords, newCords))) { return MoveValidationMessage.IllegalMove; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game, Color);


                var gamestatehelper = new GameStateHelper(_game);
                gamestatehelper.ChangePlayerTurn();


                return MoveValidationMessage.Succeeded;
            }
        }

        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            //return true;
            if (first.Item2 == second.Item2)
            {
                return MoveHelper.LegalMoveHorizontal(first, second, _game, (first.Item1 < second.Item1));

            }
            else if (first.Item1 == second.Item1)
            {
                return MoveHelper.LegalMoveVertical(first, second, _game, (first.Item2 < second.Item2));
            }
            else return false;
        }
    }
}
