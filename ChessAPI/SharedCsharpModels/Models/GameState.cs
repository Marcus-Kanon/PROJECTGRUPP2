using System.Drawing;
using System.Net.NetworkInformation;

namespace SharedCsharpModels.Models
{
    public class GameState
    {
        public GamePiece[,] Board { get; set; }
        public string GameId { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player MovingPlayer => this.Player1?.IsPlayerTurn ?? false ? this.Player2 : this.Player1;

        public Player Opponent => this.Player1?.IsPlayerTurn ?? false ? this.Player1 : this.Player2;

        public void PlayersDisplay(bool color)
        {
            if(color)
                Player1.Color = color;
            else
                Player2.Color = color;

            Console.Write($"PLAYER {color} NAME: ");
        }
        public void GetPlayers()
        {
            Player player1 = Player1.GetPlayer();
            Player player2 = Player2.GetPlayer();

            this.Player1 = player1;
            this.Player2 = player2;
        }



        //public string Player1Id { get; set; }
        //public string Player2Id { get; set; }
        //public string PlayerTurnId { get; set; }
        //public string? IsCheckedPlayerId { get; set; }
        //public string? IsCheckmatedPlayerId { get; set; }
    }
}
