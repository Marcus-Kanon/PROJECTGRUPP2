namespace ChessAPI.Models
{
    public class GamePiece : IGamePiece
    {   
        public virtual string Name { get; set; } = "";
        public virtual bool? Color { get; set; }

        public virtual bool HasMoved { get; set; }
        public virtual PieceType Type { get; set; }
        protected Game _game;

        public GamePiece(Game game, bool? color)
        {
            Color = color;
            _game = game;
        }

        public virtual string Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
        public virtual bool CheckLegalMove((int, int) first, (int, int) second)
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
