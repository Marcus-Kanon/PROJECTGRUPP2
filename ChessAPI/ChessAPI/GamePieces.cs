namespace ChessAPI
{
    public interface GamePieces
    {
        string Move((int, int) oldCords, (int, int) newCords);
    }
}
