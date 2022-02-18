namespace ClientManual.Models
{
    public interface IGamePiece
    {
        public string Name { get; set; }
        public bool? Color { get; set; }
        public string Move((int, int) oldCords, (int, int) newCords);
    }
}
