namespace SharedCsharpModels.Models
{
    public class Player
    {
        public string Id { get; set; }
        public Color Color { get; set; }
        public bool IsPlayerTurn { get; set; }
        //Kod som inte har använts ännu, kanske för framtiden
        //public bool IsCheckedPlayerId { get; set; }
        //public bool IsCheckmatedPlayerId { get; set; }
        //public bool IsLegalMove { get; set; }

    }
}
