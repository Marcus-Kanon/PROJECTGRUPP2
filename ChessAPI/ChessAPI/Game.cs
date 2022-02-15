namespace ChessAPI
{
    public class Game
    {
        GamePiece[,] Board { get; set; }
        public string MatchId { get; set; }
        public string Player1Id { get; set; }
        public string PlayerId { get; set; }
        bool ToMovePlayer1 { get; set; }
    }
}
