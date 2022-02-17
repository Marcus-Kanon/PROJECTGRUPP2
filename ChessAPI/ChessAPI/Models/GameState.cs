namespace ChessAPI.Models
{
    public class GameState
    {
        public GamePiece[,] Board { get; set; }
        public string MatchId { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        bool ToMovePlayer1 { get; set; }
    }
}
