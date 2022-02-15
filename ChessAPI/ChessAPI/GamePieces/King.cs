namespace ChessAPI.GamePieces
{
    public class King : IGamePiece
    {
        public IGamePiece[,] _board { get; set; }
        
        public King(IGamePiece [,] board)
        {
            _board = board;

        }

        public string Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
    }
}
