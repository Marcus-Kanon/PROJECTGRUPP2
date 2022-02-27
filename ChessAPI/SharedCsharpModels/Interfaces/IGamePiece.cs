namespace SharedCsharpModels.Models
{
    public interface IGamePiece
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public MoveValidationMessage Move((int, int) oldCords, (int, int) newCords);
    }
}
