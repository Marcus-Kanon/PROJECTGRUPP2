using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class Pawn : GamePiece
    {
        public override string Name { get => "\u265F"; }
        //public override string Name { get => "P"; }

        public Pawn(GameState game, Color color) : base(game, color)
        {
            Type = PieceType.Pawn;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
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
            //return true;


            return (
                //first.Item1 < 8 && first.Item1 >=0 && first.Item1 < 8 && first.Item1 >= 0 ORKAR INTE MED DETTA, Gör koordinaterna till objekt, sätt 0<=x,y<=7 i accessorerna
                //  && this.Color == true) funkar inte
                (second.Item2 - first.Item2 == 1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name == " " && this.Color == Color.Light) // vanligt drag vit  
                 ||
                 //(second.Item2 - first.Item2 == -1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name == " " && this.Color == Color.Dark) // vanligt drag svart
                 (second.Item2 - first.Item2 == -1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name == " ") // vanligt drag svart
                 ||
                (second.Item2 == 3 && first.Item2 == 1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name == " " && _game.Board[second.Item1, 2].Name == " " && this.Color == Color.Light) // två steg tillåtet första drag vit
                 ||                                                                                                                                                                                                //||
                (second.Item2 == 4 && first.Item2 == 6 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name == " " && _game.Board[second.Item1, 5].Name == " " && this.Color == Color.Dark) // två steg tillåtet första drag svart
                ||
                (second.Item2 - first.Item2 == 1 && Math.Abs(second.Item1 - first.Item1) == 1 && _game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == Color.Dark)  // slag vit
                ||
                (second.Item2 - first.Item2 == -1 && Math.Abs(second.Item1 - first.Item1) == 1 && _game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == Color.Light)  // slag svart

                   ////////////////
                   ///
                   //(second.Item1 - first.Item1 == 1 && second.Item2 == first.Item2 && _game.Board[second.Item2, second.Item1].Name == " " && this.Color == Color.Light) // vanligt drag vit  
                   // ||
                   // (second.Item1 - first.Item1 == -1 && second.Item2 == first.Item2 && _game.Board[second.Item2, second.Item1].Name == " " && this.Color == Color.Dark) // vanligt drag svart

                   // ||
                   //(second.Item1 == 3 && first.Item1 == 1 && second.Item2 == first.Item2 && _game.Board[second.Item2, second.Item1].Name == " " && _game.Board[2, second.Item2].Name == " " && this.Color == Color.Light) // två steg tillåtet första drag vit
                   // ||                                                                                                                                                                                                //||
                   //(second.Item1 == 4 && first.Item1 == 6 && second.Item2 == first.Item2 && _game.Board[second.Item2, second.Item1].Name == " " && _game.Board[5, second.Item2].Name == " " && this.Color == Color.Dark) // två steg tillåtet första drag svart
                   //||
                   //(second.Item1 - first.Item1 == 1 && Math.Abs(second.Item2 - first.Item2) == 1 && _game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == Color.Dark)  // slag vit
                   //||
                   //(second.Item1 - first.Item1 == -1 && Math.Abs(second.Item2 - first.Item2) == 1 && _game.Board[second.Item1, second.Item2].Name != " " && _game.Board[second.Item1, second.Item2].Color == Color.Light)  // slag svart

                   ////////////////






                   ) ;
        }

    }
}
