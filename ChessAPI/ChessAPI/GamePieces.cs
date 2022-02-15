namespace ChessAPI
{
    public interface GamePieces
    {
        string Move((int x, int y), (int x2, int y2));
    }
}
