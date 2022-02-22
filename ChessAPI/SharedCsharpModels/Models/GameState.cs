using System.Drawing;

namespace SharedCsharpModels.Models
{
    public class GameState
    {
        public GamePiece[,] Board { get; set; }
        public string GameId { get; set; }
        public string? IsCheckedPlayerId { get; set; }
        public string? IsCheckmatedPlayerId { get; set; }


        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Player MovingPlayer => this.Player1?.IsPlayerTurn ?? false ? this.Player2 : this.Player1;
    }
}
