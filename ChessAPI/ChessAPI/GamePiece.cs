namespace ChessAPI
{
    public interface GamePiece
    {
        GamePiece [,] _board { get; set; }
        string Move((int, int) oldCords, (int, int) newCords);

    }
}
