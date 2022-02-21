namespace SharedCsharpModels.Models
{
    public partial class GamePiece : IGamePiece
    {
        public virtual string Name { get; set; } = "";
        public virtual Color Color { get; set; }
        public virtual PieceType Type { get; set; }
        protected GameState _game;
        public bool LegalNextMove { get; set; }

        public GamePiece(GameState game, Color color)
        {
            Color = color;
            _game = game;
        }

        public virtual MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
    }
}
