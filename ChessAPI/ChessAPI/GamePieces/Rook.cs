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

        /// <summary>
        /// Returns a specific move validation message, depending on if the rook being moved to a new spot is the other player's chess piece, or if the move is valid.
        /// /// </summary>
        /// <param name="oldCords">The current coordinates..</param>
        /// <param name="newCords">The new coordinates..</param>
        /// <returns></returns>
        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            if (_game.MovingPlayer.Color != Color)
                return MoveValidationMessage.WrongPieceColor;

            if (!CheckLegalMove(oldCords, newCords)) { return MoveValidationMessage.IllegalMove; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game, Color);

                var gamestatehelper = new GameStateHelper(_game);
                gamestatehelper.ChangePlayerTurn();

                return MoveValidationMessage.Succeeded;
            }
        }
        /// <summary>
        /// Compares the rook's current coordinates and the new coordinates to check if the move is valid for the rook.
        /// </summary>
        /// <param name="first">The current coordinates.</param>
        /// <param name="second">The new coordinates.</param>
        /// <returns></returns>
        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            if (!MoveHelper.AllAreInBounds(new List<int> { first.Item1, first.Item2, second.Item1, second.Item2 })) return false;
            if (first.Item2 == second.Item2)
            {
                return MoveHelper.LegalMoveHorizontal(first, second, _game, first.Item1 < second.Item1);
            }
            else if (first.Item1 == second.Item1)
            {
                return MoveHelper.LegalMoveVertical(first, second, _game, first.Item2 < second.Item2);
            }
            else return false;
        }
    }
}