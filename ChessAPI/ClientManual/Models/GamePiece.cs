namespace ClientManual.Models
{
    public class GamePiece
    {
        public string Name { get; set; }
        GamePiece [,] _board { get; set; }
        public virtual string Move((int, int) oldCords, (int, int) newCords)
        {
            return "";
        }
    }
}
