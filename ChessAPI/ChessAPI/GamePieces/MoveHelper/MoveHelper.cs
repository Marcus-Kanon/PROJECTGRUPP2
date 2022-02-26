using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public static class MoveHelper

    {

        public static  bool AllAreInBounds (List<int> numbers)
        {
            foreach (var item in numbers)
            {
                if (item > 7 || item < 0) return false;

            }
            return true;
        }
        public static bool LegalMoveVertical ((int,int) oldCoords, (int,int) newCooords, GameState game, bool isUp)
        {

            int plusMinus = isUp ? 1 : -1;
            if (oldCoords.Item1 != newCooords.Item1) return false;

            int start = oldCoords.Item2;
            do
            {
                if (start < 7 && start > 0 )   start = start + 1 * plusMinus;
                if (
                    game.Board[oldCoords.Item1, start].Name != " "

                        && (game.Board[oldCoords.Item1, start].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color
                            ||
                            start != newCooords.Item2
                            )
                    )
                {
                    return false;
                }
            } while (start != newCooords.Item2);
                return true;
        }
        public static bool LegalMoveHorizontal((int, int) oldCoords, (int, int) newCooords, GameState game, bool isRight)
        {
            int plusMinus = isRight ? 1 : -1;
            if (oldCoords.Item2 != newCooords.Item2) return false;
            int start = oldCoords.Item1;
            do
            {
                if (start < 7 && start > 0) start = start + 1 * plusMinus;
 


                //if (game.Board[start, oldCoords.Item2].Name != " " && game.Board[start,oldCoords.Item2 ].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                    if (
                        game.Board[start, oldCoords.Item2].Name != " "

                                //&& (game.Board[start, oldCoords.Item2].Color == game.Board[start, oldCoords.Item2].Color
                                && (game.Board[start, oldCoords.Item2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color
                                ||
                                start != newCooords.Item1
                                )
                        )

                    {
                    return false;
                }
            } while (start != newCooords.Item1  );
            return true;
        }
        public static bool LegalMoveLeftDiagonals((int, int) oldCoords, (int, int) newCooords, GameState game, bool isUp)
        {
            int plusMinus = isUp ? 1 : -1;

            int start = oldCoords.Item1;
            int start2 = oldCoords.Item2;
 
            do
            {
                //if (AllAreInBounds(new List<int> { start, start2 }))
                //{
                //    start = start - 1;
                //    start2 = start2 + 1 * plusMinus;
                //}
                if (AllAreInBounds(new List<int> { start }))
                {
                    start = start - 1;
                }
                if (AllAreInBounds(new List<int> { start2 }))
                {
                    start2 = start2 + 1 * plusMinus;
                }


                if (start < 0 || start > 7 || start2 < 0 || start2 > 7 || (start==newCooords.Item1 && start2 != newCooords.Item2 ) ) return false;
                //if ((game.Board[start, start2].Name != " " && start != newCooords.Item1) && game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                //if (
                //    (game.Board[start, start2].Name != " ") 

                //    &&      ( game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color
                //              ||
                //             ( start != newCooords.Item1 || start2 != newCooords.Item2)
                //            )
                //    )
                if (
                    (game.Board[start, start2].Name != " ")

                    && (game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                              ||
                             (start == newCooords.Item1 && start2 != newCooords.Item2)

                    )
                {

                    return false;
                }
            } while (start != newCooords.Item1 || start2 != newCooords.Item2) ;

  
                return true;
        }
        public static bool LegalMoveRightDiagonals((int, int) oldCoords, (int, int) newCooords, GameState game, bool isUp)
        {
            int plusMinus = isUp ? 1 : -1;

            int start = oldCoords.Item1;
            int start2 = oldCoords.Item2;
            do
            {
                //start = start + 1;
                //start2 = start2 + 1 * plusMinus;
                if (AllAreInBounds(new List<int> { start }))
                {
                    start = start + 1;
                }
                if (AllAreInBounds(new List<int> { start2 }))
                {
                    start2 = start2 + 1 * plusMinus;
                }

                //start = start + 1;
                //start2 = start2 + 1 * plusMinus;
 

                //if (start < 0 || start > 7 || start2 < 0 || start2 > 7 || (start == newCooords.Item1 && start2 != newCooords.Item2)) return false;
                //if ((game.Board[start, start2].Name != " " ) && game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                if (
                    (game.Board[start, start2].Name != " ")

                    && (game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                              ||
                             (start == newCooords.Item1 && start2 != newCooords.Item2)
                            
                    )


                {
 
                    return false;
                }
            } while (start != newCooords.Item1 || start2 != newCooords.Item2);


            return true;
        }

        public static bool CanAnyMoveTo((int, int) target, GameState game, Color enemyColor)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    bool truth = game.Board[i, j].CheckLegalMove((i, j), (target.Item1, target.Item2)) && game.Board[i, j].Color == enemyColor;
                    if (truth) return truth;

                }

            }
            return false;
        }

        public static bool IsGuarded((int, int) target, GameState game, Color enemyColor) //onödiggör Ovanstående
        {
            //if (game.Board[target.Item1, target.Item2].Color != enemyColor) return false;
             if (game.Board[target.Item1, target.Item2].Color != enemyColor && game.Board[target.Item1, target.Item2].Color != Color.Empty) return false;

            var tempPiece = game.Board[target.Item1, target.Item2].Type.ToString();// vad händer när target ändras? borde inte vára problem bools enums är value types?
            //var targetColor = game.Board[target.Item1, target.Item2].Color.ToString();
            var targetColor = game.Board[target.Item1, target.Item2].Color;
            var myColor = (enemyColor == Color.Dark ) ? Color.Light : Color.Dark;

            //var hasMoved = game.Board[target.Item1, target.Item2].HasMoved; 
            bool truth = false;
            game.Board[target.Item1, target.Item2] = new Pawn(game, myColor);
            //bool returnMe = false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    int plusMinus = enemyColor == Color.Dark ? -1 : 1;
 
                    if (game.Board[i, j].Type != PieceType.King)                //skydd mot regression
                    {
                        //Console.WriteLine(game.Board[target.Item1, target.Item2].Type.ToString()+" "+ game.Board[target.Item1, target.Item2].Color.ToString());
                         truth = (
                                        game.Board[i, j].CheckLegalMove((i, j), (target.Item1, target.Item2))

                                        && game.Board[i, j].Color == enemyColor

                                     //&& game.Board[i, j].Type != PieceType.Pawn

                                     );
                         Console.WriteLine (i+" "+j+" "+truth+" myColor "+myColor.ToString()+" enemyC "+enemyColor.ToString());
                        //bool dare =  (

                        //                (game.Board[i, j].Type == PieceType.Pawn) 

                        //                && (game.Board[i, j].Color == enemyColor) 

                        //                && (target.Item2 - j == 1 * plusMinus) 

                        //                && Math.Abs(target.Item1 - i) == 1

                        //            )    
                        ;


                    }




                    //if (truth  ) return (truth  );

                    if (truth)
                    {
                        switch (tempPiece.ToString())
                        {
                            case "NoPiece":
                                game.Board[target.Item1, target.Item2] = new NoPiece(game, Color.Empty);
                                break;
                            case "Pawn":
                                Console.WriteLine("pawn");
                                game.Board[target.Item1, target.Item2] = new Pawn(game, targetColor);

                                break;
                            case "Rook":
                                game.Board[target.Item1, target.Item2] = new Rook(game, targetColor);
                                break;
                            case "Knight":
                                game.Board[target.Item1, target.Item2] = new Knight(game, targetColor);
                                break;
                            case "Bishop":
                                game.Board[target.Item1, target.Item2] = new Bishop(game, targetColor);
                                break;
                            case "Queen":
                                game.Board[target.Item1, target.Item2] = new Queen(game, targetColor);
                                break;
                            case "King":
                                //        ,,,           borde inte kunna hända
                                //       (O O)       
                                //---ooO--(_)--Ooo--- 
                                //                    
                                //     KILROY WAS    
                                //       HERE


                                break;
                            default:
                                Console.WriteLine("default");
                                //        ,,,           inte detta heller - isf har ngt gått fel.
                                //       (O O)       
                                //---ooO--(_)--Ooo--- 
                                //                    
                                //     KILROY WAS    
                                //       HERE


                                break;
                        }
                        return truth;
                    } ;

                }

            }
            switch (tempPiece.ToString())
            {
                case "NoPiece":
                    game.Board[target.Item1, target.Item2] = new NoPiece(game, Color.Empty);
                    break;
                case "Pawn":
                    Console.WriteLine("pawn");
                    game.Board[target.Item1, target.Item2] = new Pawn(game, targetColor);

                    break;
                case "Rook":
                    game.Board[target.Item1, target.Item2] = new Rook(game, targetColor);
                    break;
                case "Knight":
                    game.Board[target.Item1, target.Item2] = new Knight(game, targetColor);
                    break;
                case "Bishop":
                    game.Board[target.Item1, target.Item2] = new Bishop(game, targetColor);
                    break;
                case "Queen":
                    game.Board[target.Item1, target.Item2] = new Queen(game, targetColor);
                    break;
                case "King":
                    //        ,,,           borde inte kunna hända
                    //       (O O)       
                    //---ooO--(_)--Ooo--- 
                    //                    
                    //     KILROY WAS    
                    //       HERE


                    break;
                default:
                    Console.WriteLine("default");
                    //        ,,,           inte detta heller - isf har ngt gått fel.
                    //       (O O)       
                    //---ooO--(_)--Ooo--- 
                    //                    
                    //     KILROY WAS    
                    //       HERE


                    break;
            }
            return truth;
        }

    }
}
