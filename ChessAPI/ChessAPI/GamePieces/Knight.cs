using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public class Knight : GamePiece
    {
        public override string Name { get => "\u265E"; }

        public Knight(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.Knight;
        }

        /// <summary>
        /// Returns a specific move validation message, depending on if the knight being moved to a new spot is the other player's chess piece, or if the move is valid.
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
        /// Compares the knight's current coordinates and the new coordinates to check if the move is valid for the knight.
        /// </summary>
        /// <param name="first">The current coordinates.</param>
        /// <param name="second">The new coordinates.</param>
        /// <returns></returns>
        public override bool CheckLegalMove((int, int) first, (int, int) second) => ((Math.Abs(first.Item2 - second.Item2) == 2 && Math.Abs(first.Item1 - second.Item1) == 1) || (Math.Abs(first.Item1 - second.Item1) == 2 && Math.Abs(first.Item2 - second.Item2) == 1)) && !(_game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == _game.Board[first.Item1, first.Item2].Color);
    }
}