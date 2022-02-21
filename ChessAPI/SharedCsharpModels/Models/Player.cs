using System;
using System.Collections.Generic;
using System.Text;

namespace SharedCsharpModels.Models
{
    public class Player
    {
        public string PlayerID { get; set; }
        public bool Color { get; set; }
        public bool IsPlayerTurn { get; set; } 
        public bool IsCheckedPlayerId { get; set; }
        public bool IsCheckmatedPlayerId { get; set; }
        public bool IsLegalMove { get; set; }

        public Player(string playerId, bool color)
        {
            PlayerID = playerId;
            Color = color;
        }

        public Player GetPlayer()
        {
            return new Player(PlayerID, Color);
        }
    }
}
