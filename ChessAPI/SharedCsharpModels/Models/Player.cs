namespace SharedCsharpModels.Models
{
    public class Player
    {
        public string Id { get; set; }
        //public bool Color { get; set; }
        public Color Color { get; set; }
        public bool IsPlayerTurn { get; set; } 
        public bool IsCheckedPlayerId { get; set; }
        public bool IsCheckmatedPlayerId { get; set; }
        public bool IsLegalMove { get; set; }

        public Player(string playerId, Color color)
        {
            Id = playerId;
            Color = color;
        }

    }
}
