using System.Drawing;
using ChessAPI.GamePieces;

namespace SharedCsharpModels.Models
{
    public class GameState
    {
        public GamePiece[,] Board { get; set; }
        public string GameId { get; set; }

        //public string Player1Id { get; set; }
        ////public string Player2Id { get; set; }
        //public string PlayerTurnId { get; set; }
        public string? IsCheckedPlayerId { get; set; }
        public string? IsCheckmatedPlayerId { get; set; }


        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public Player MovingPlayer => this.Player1?.IsPlayerTurn ?? false ? this.Player2 : this.Player1;

        public void ChangeTurns() //TODO: VRF VILL INTE DENNA FUNKA
        {
            if (this.Player1.IsPlayerTurn)
            {
                this.Player1.IsPlayerTurn = false;
                this.Player2.IsPlayerTurn = true;
            }
            else
            {
                this.Player2.IsPlayerTurn = false;
                this.Player1.IsPlayerTurn = true;
            }
        }

        public void Turn(Player player)
        {
            if (player.Color == Color.Light)
            {
                Console.Write($"Player {player.Id}'s (WHITE) turn: ");
            }
            else
            {
                Console.Write($"Player {player.Id}'s (BLACK) turn: ");
            }
        }
    }
}
