namespace ClientTEST.Interfaces
{
    public interface IGamePiece
    {
        IGamePiece [,] _board { get; set; }
        string Move((int, int) oldCords, (int, int) newCords);

    }
}
