namespace SharedCsharpModels.Models
{
    public class GamePiece : IGamePiece
    {
        public virtual string Name { get; set; } = "";
        public virtual Color Color { get; set; }
        public virtual PieceType Type { get; set; }

        protected GameState _game;
        public bool LegalNextMove { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GamePiece"/> class.
        /// </summary>
        /// <param name="game">The current gamestate.</param>
        /// <param name="color">The color of the piece.</param>
        public GamePiece(GameState game, Color color)
        {
            Color = color;
            _game = game;
        }

        /// <summary>
        /// Returns a specific move validation message, depending on if the chess piece being moved to a new spot is the other player's chess piece, or if the move is valid.
        /// /// </summary>
        /// <param name="oldCords">The current coordinates..</param>
        /// <param name="newCords">The new coordinates..</param>
        /// <returns></returns>
        public virtual MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Compares the chess piece's current coordinates and the new coordinates to check if the move is valid for the chess piece.
        /// </summary>
        /// <param name="first">The current coordinates.</param>
        /// <param name="second">The new coordinates.</param>
        /// <returns></returns>
        public virtual bool CheckLegalMove((int, int) first, (int, int) second)
        {
            return false;
            //throw new NotImplementedException();
        }
    }
}
