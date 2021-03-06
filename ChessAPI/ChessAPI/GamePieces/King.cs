using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        public override string Name { get => "\u265A"; }

        public King(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.King;
        }

        /// <summary>
        /// Returns a specific move validation message, depending on if the king being moved to a new spot is the other player's chess piece, or if the move is valid.
        /// /// </summary>
        /// <param name="oldCords">The current coordinates..</param>
        /// <param name="newCords">The new coordinates..</param>
        /// <returns></returns>
        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords) // TODO && CheckIfMate(this.Color)
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
        /// Compares the king's current coordinates and the new coordinates to check if the move is valid for the king.
        /// </summary>
        /// <param name="first">The current coordinates.</param>
        /// <param name="second">The new coordinates.</param>
        /// <returns></returns>
        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            Color myColor = this.Color == Color.Light ? Color.Dark : Color.Light;
            if (!MoveHelper.AllAreInBounds(new List<int> { first.Item1, first.Item2, second.Item1, second.Item2 })) return false;
            return

                     //(!MoveHelper.IsGuarded(first,_game, myColor)
                     !MoveHelper.IsGuarded(second, _game, myColor)
                            &&
                                Math.Abs(second.Item2 - first.Item2) <= 1 && Math.Abs(second.Item1 - first.Item1) <= 1 &&
                                        !(_game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == this.Color)
                                        // TODO: Villkor f???r rockad h???r

                            ;
        }
    }
}