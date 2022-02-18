﻿using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces
{
    public class Pawn : GamePiece
    {
        public override string Name
        {
            get { if (Color == true) { return "\u2659"; } else { return "\u265F"; } }
        }

        public Pawn(GameState game, bool color) : base(game, color)
        {
            Type = PieceType.Pawn;
        }

        public override MoveValidationMessage Move((int, int) oldCords, (int, int) newCords)
        {
            if (!(CheckLegalMove(oldCords, newCords))) { return MoveValidationMessage.IllegalMove; }
            else
            {
                _game.Board[newCords.Item1, newCords.Item2] = _game.Board[oldCords.Item1, oldCords.Item2];
                _game.Board[oldCords.Item1, oldCords.Item2] = new NoPiece(_game);
                return MoveValidationMessage.Succeeded;
            }
        }

        public bool CheckLegalMove((int, int) first, (int, int) second)
        {
            return (
                        //(second.Item2 - first.Item2 == 1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2] is NoPiece && this.Color == true)  // vanligt drag vit
                   (second.Item2 - first.Item2 == 1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2].Name==" "   ) // vanligt drag vit  


                   //||
                   ////(second.Item2 - first.Item2 == -1 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2] is NoPiece && this.Color == false) //svart
                    ||
                   ( second.Item2 == 3 &&   first.Item2 == 1 && second.Item1 == first.Item1 &&  _game.Board[second.Item1, second.Item2].Name==" "  && _game.Board[second.Item1, 2].Name==" "  ) // två steg tillåtet första drag vit
                   //||
                   ////(second.Item2 == 4 && first.Item2 == 6 && second.Item1 == first.Item1 && _game.Board[second.Item1, second.Item2] is NoPiece && _game.Board[second.Item1, 5] is NoPiece && this.Color == false) // två steg tillåtet första drag svart
                   ||
                   (second.Item2 - first.Item2 == 1 && Math.Abs(second.Item1 - first.Item1) == 1 &&  _game.Board[second.Item1, second.Item2].Name!=" " && _game.Board[second.Item1, second.Item2].Color==!this.Color )  // slag vit
                   //||
                   ////(second.Item2 - first.Item2 == -1 && Math.Abs(second.Item1 - first.Item1) == 1 && _game.Board[second.Item1, second.Item2] is not NoPiece && _game.Board[second.Item1, second.Item2].Color == !this.Color)  // slag svart

                   );
        }

    }
}
