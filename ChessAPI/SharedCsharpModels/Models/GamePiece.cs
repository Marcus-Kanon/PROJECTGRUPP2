namespace SharedCsharpModels.Models
{
    public partial class GamePiece : IGamePiece
    {
        public virtual string Name { get; set; } = "";
        public virtual bool? Color { get; set; }
        public virtual PieceType Type { get; set; }
        protected GameState _game;

        public GamePiece(GameState game, bool? color)
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
