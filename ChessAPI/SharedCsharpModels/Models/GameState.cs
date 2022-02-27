using System.Drawing;

namespace SharedCsharpModels.Models
{
    public class GameState
    {
        public GamePiece[,] Board { get; set; } = null!;
        public string GameId { get; set; } = "";
        //Kod som ej används än, kanske för framtiden
        //public string? IsCheckedPlayerId { get; set; }
        //public string? IsCheckmatedPlayerId { get; set; }

        public Player Player1 { get; set; } = null!;
        public Player Player2 { get; set; } = null!;

        /// <summary>
        /// If moving player is not player 1, then the bool property IsPlayerTurn of player 1 will be false and the bool property IsPlayerTurn of player 2 will be true.
        /// </summary>
        public Player MovingPlayer => !Player1.IsPlayerTurn ? Player2 : Player1;
    }
}
