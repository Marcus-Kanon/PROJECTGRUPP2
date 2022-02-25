using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class King : GamePiece
    {
        public override string Name { get => "\u265A"; }

        public King(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.King;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords) // TODO && CheckIfMate(this.Color)
        {
            if (_game.MovingPlayer.Color != Color)
                return MoveValidationMessage.WrongColor;

            if (!(CheckLegalMove(oldCords, newCords))) { return MoveValidationMessage.IllegalMove; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game, Color);
                
                var gamestatehelper = new GameStateHelper(_game);
                gamestatehelper.ChangePlayerTurn();

                return MoveValidationMessage.Succeeded;
            }
        }

        public override bool CheckLegalMove((int, int) first, (int, int) second)
        {
            Color myColor = this.Color == Color.Light ? Color.Dark : Color.Light;
            return (

                     //(!MoveHelper.IsGuarded(first,_game, myColor)
                     (!MoveHelper.IsGuarded(second, _game, myColor)
                            && ( 
                                (Math.Abs(second.Item2 - first.Item2)  <= 1 &&  Math.Abs(second.Item1 - first.Item1) <= 1) &&
                                        !(_game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == this.Color)
                    
                    
                    
                              )
                       )
                       // TODO: Villkor f�r rockad h�r
                 )           
                            ;
        }

    }
}
