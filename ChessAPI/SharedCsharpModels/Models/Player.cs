namespace SharedCsharpModels.Models
{
    public class Player
    {
        /// <summary>
        /// Gets or sets the player ID.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public Color Color { get; set; }
        /// <summary>
        /// Gets or sets if it is the player's turn
        /// </summary>
        public bool IsPlayerTurn { get; set; }

        //Kod som inte har använts ännu, kanske för framtiden
        //public bool IsCheckedPlayerId { get; set; }
        //public bool IsCheckmatedPlayerId { get; set; }
        //public bool IsLegalMove { get; set; }

    }
}
