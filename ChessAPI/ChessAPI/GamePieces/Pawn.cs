using ChessAPI.Models;

namespace ChessAPI.GamePieces
{
    public class Pawn : GamePiece
    {
        public override string Name { get; set; } = "\u2659";  //white pawn unicode

        public Pawn(Game game, bool color) : base(game, color)
        {
            Type = PieceType.Pawn;
        }

        public override string Move((int, int) oldCords, (int, int) newCords)
        {
            if (!(CheckLegalMove(oldCords, newCords))) { return "Illegal move"; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
                return "Successfully moved pawn... i think...";
            }
        }

        public bool CheckLegalMove((int, int) first, (int, int) second)
        {
            return (
                    //first.Item1 < 8 && first.Item1 >=0 && first.Item1 < 8 && first.Item1 >= 0 ORKAR INTE MED DETTA, Gör koordinaterna till objekt, sätt 0<=x,y<=7 i accessorerna
                   //  && this.Color == true) funkar inte
                   (second.Item2 - first.Item2 == 1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name==" " && this.Color == true) // vanligt drag vit  


                    ||
                    (second.Item2 - first.Item2 == -1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name == " " && this.Color == false) // vanligt drag svart
                    ||
                   ( second.Item2 == 3 &&   first.Item2 == 1 && second.Item1 == first.Item1 &&  _game.Board[second.Item1, second.Item2].Name==" "  && _game.Board[second.Item1, 2].Name==" " && this.Color == true) // två steg tillåtet första drag vit
                    ||                                                                                                                                                                                                //||
                   (second.Item2 == 4 && first.Item2 == 6 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name == " " && _game.Board[second.Item1, 5].Name == " " && this.Color == false) // två steg tillåtet första drag svart
                   ||
                   (second.Item2 - first.Item2 == 1 && Math.Abs(second.Item1 - first.Item1) == 1 &&  _game.Board[second.Item1, second.Item2].Name!=" " && _game.Board[second.Item1, second.Item2].Color==!this.Color )  // slag vit
                   ||
                   (second.Item2 - first.Item2 == -1 && Math.Abs(second.Item1 - first.Item1) == 1 && _game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == !this.Color)  // slag svart

                   );
        }

    }
}
