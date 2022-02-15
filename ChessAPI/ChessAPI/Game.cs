namespace ChessAPI
{
    public class Game
    {
        const int BOARD_WIDTH = 8;

        public IGamePiece[,] Board { get; set; }
        public string GameId { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        public string PlayerTurnId { get; set; }

        public Game()
        {
            Board = new IGamePiece[BOARD_WIDTH, BOARD_WIDTH];
        }
    }
}
