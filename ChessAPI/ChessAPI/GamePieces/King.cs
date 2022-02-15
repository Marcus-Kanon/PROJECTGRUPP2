namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        public GamePiece[,] _board { get; set; }
        
        public King(GamePiece [,] board)
        {
            _board = board;
        }

        public string Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
    }
}
