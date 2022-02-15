using ClientTEST.Interfaces;

namespace ClientTEST.Models
{
    public class GameState
    {
        IGamePiece[,] Board { get; set; }
        public string GameId { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        bool ToMovePlayer1 { get; set; }
    }
}
