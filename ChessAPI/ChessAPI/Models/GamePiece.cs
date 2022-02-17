namespace ChessAPI.Models
{
    public class GamePiece : IGamePiece
    {   
        public virtual string Name { get; set; } = "";
        public virtual bool? Color { get; set; }

        public virtual string Move((int, int) oldCords, (int, int) newCords)
        {
            throw new NotImplementedException();
        }
    }
}
