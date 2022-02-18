namespace ClientManual.Models
{
    public class GamePiece : IGamePiece
    {
        public string Name { get; set; } = "";
        public bool? Color { get; set; }

        public string Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
    }
}
