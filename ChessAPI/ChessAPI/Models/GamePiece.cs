namespace ChessAPI.Models
{
    public partial class GamePiece : IGamePiece
    {
        public virtual string Name { get; set; } = "";
        public virtual bool? Color { get; set; }
        public virtual PieceType Type { get; set; }
        protected Game _game;

        public GamePiece(Game game, bool? color)
        {
            Color = color;
            _game = game;
        }

        public virtual MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }

        public enum PieceType
        {
            NoPiece,
            Pawn,
            Rook,
            Knight,
            Bishop,
            Queen,
            King
        }
    }
}
