namespace SharedCsharpModels.Models
{
    public class Player
    {
        public string Id { get; set; }
        public bool Color { get; set; }
        public bool IsPlayerTurn { get; set; } 
        public bool IsCheckedPlayerId { get; set; }
        public bool IsCheckmatedPlayerId { get; set; }
        public bool IsLegalMove { get; set; }

        //public Player(string playerId, bool color)
        //{
        //    Id = playerId;
        //    Color = color;
        //}

        public Player(string playerId)
        {
            Id = playerId;
        }

        //public Player GetPlayer()
        //{
        //    return new Player(Id, Color);
        //}
    }
}
