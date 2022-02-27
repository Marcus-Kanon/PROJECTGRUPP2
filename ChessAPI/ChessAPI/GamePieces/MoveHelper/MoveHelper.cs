using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public static class MoveHelper

    {
     /// <summary>
     ///  Checks whether a move along the is along the vertical axis and legal, returning true if it is.
     /// </summary>
     /// <param name="oldCoords">The current coordinates</param>
     /// <param name="newCooords">The new coordinates</param>
     /// <param name="game"></param>
     /// <param name="isUp">whether target vertical coordinate is greater  than current</param>
     /// <returns>bool true if move legal </returns>
        public static bool LegalMoveVertical ((int,int) oldCoords, (int,int) newCooords, GameState game, bool isUp)
        {

            int plusMinus = isUp ? 1 : -1;
            if (oldCoords.Item1 != newCooords.Item1) return false;

            int start = oldCoords.Item2;
            do
            {
                start = start + (1 * plusMinus);
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
        /// <summary>
        ///  Checks whether a move along the is along the horizontal axis and legal, returning true if it is.
        /// </summary>
        /// <param name="oldCoords">The current coordinates</param>
        /// <param name="newCooords">The new coordinates</param>
        /// <param name="game"></param>
        /// <param name="isRight">whether target horizontal coordinate is greater  than current</param>
        /// <returns>bool true if move legal </returns>
        public static bool LegalMoveHorizontal((int, int) oldCoords, (int, int) newCooords, GameState game, bool isRight)
        {
            int plusMinus = isRight ? 1 : -1;
            if (oldCoords.Item2 != newCooords.Item2) return false;
            int start = oldCoords.Item1;
            do
            {

                start = start + (1 * plusMinus);


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
        /// <summary>
        /// Checks whether a move is along a left hand diagonal and legal, returning true if it is.
        /// </summary>
        /// <param name="oldCoords">The current coordinates</param>
        /// <param name="newCooords">The new coordinates</param>
        /// <param name="game"></param>
        /// <param name="isUp">whether target vertical coordinate is greater  than current</param>
        /// <returns>bool true if move legal </returns>
        public static bool LegalMoveLeftDiagonals((int, int) oldCoords, (int, int) newCooords, GameState game, bool isUp)
        {
            int plusMinus = isUp ? 1 : -1;

            int start = oldCoords.Item1;
            int start2 = oldCoords.Item2;
 
            do
            {
 
                start = start - 1;
                start2 = start2 + (1 * plusMinus);
 
                if (start < 0 || start > 7 || start2 < 0 || start2 > 7 || (start==newCooords.Item1 && start2 != newCooords.Item2 ) ) return false;
                //if ((game.Board[start, start2].Name != " " && start != newCooords.Item1) && game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                if (
                    (game.Board[start, start2].Name != " ") 
                    
                    &&      ( game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color
                              ||
                              start != newCooords.Item1 || start2 != newCooords.Item2
                            )
                    )
                {

                    return false;
                }
            } while (start != newCooords.Item1 || start2 != newCooords.Item2) ;

  
                return true;
        }
        /// <summary>
        ///  Checks whether a move is along a left hand diagonal and legal, returning true if it is.
        /// </summary>
        /// <param name="oldCoords">The current coordinates</param>
        /// <param name="newCooords">The new coordinates</param>
        /// <param name="game"></param>
        /// <param name="isUp">whether target vertical coordinate is greater  than current</param>
        /// <returns>bool true if move legal </returns>
 
        public static bool LegalMoveRightDiagonals((int, int) oldCoords, (int, int) newCooords, GameState game, bool isUp)
        {
            int plusMinus = isUp ? 1 : -1;

            int start = oldCoords.Item1;
            int start2 = oldCoords.Item2;
            do
            {
                start = start + 1;
                start2 = start2 + (1 * plusMinus);
                if (start < 0 || start > 7 || start2 < 0 || start2 > 7 || (start == newCooords.Item1 && start2 != newCooords.Item2)) return false;
                //if ((game.Board[start, start2].Name != " " ) && game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                if (
                    (game.Board[start, start2].Name != " ")

                    && (game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color
                              ||
                             start != newCooords.Item1 || start2 != newCooords.Item2
                            )
                    )


                {
 
                    return false;
                }
            } while (start != newCooords.Item1 || start2 != newCooords.Item2);


            return true;
        }
        /// <summary>
        /// Tests whether any piece of a specified color can move to a position
        /// </summary>
        /// <param name="target">the coordinates to tested for ability  to move to</param>
        /// <param name="game"></param>
        /// <param name="enemyColor">the color of the pieces to be tested for ability to move to target</param>
        /// <returns>true if any piece of the specified color can</returns>
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
        /// <summary>
        /// test whether the specified square is guarded by pieces of a specified color, that is to say wheter a 
        /// piece on the square could be captured, were it the other sides turn.
        /// </summary>
        /// <param name="target">the square to be tested</param>
        /// <param name="game"></param>
        /// <param name="enemyColor">the color of pieces to be tested for ability to move to square</param>
        /// <returns>true if the piece could be captured</returns>
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
                         truth = 
                                        game.Board[i, j].CheckLegalMove((i, j), (target.Item1, target.Item2))

                                        && game.Board[i, j].Color == enemyColor



                                     //&& game.Board[i, j].Type != PieceType.Pawn

                                     ;
                         //Console.WriteLine (i+" "+j+" "+truth+" myColor "+myColor.ToString()+" enemyC "+enemyColor.ToString());
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
                                //Console.WriteLine("default");
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
                    //Console.WriteLine("pawn");
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
