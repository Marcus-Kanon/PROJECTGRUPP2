namespace ChessAPI
{
    public class GamesService : IGamesService
    {
        public List<Game> Games { get; set; }

        public GamesService()
        {
            Games = new List<Game>();
        }
    }
}
