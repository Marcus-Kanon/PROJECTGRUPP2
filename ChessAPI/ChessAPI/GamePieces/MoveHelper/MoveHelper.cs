using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public static class MoveHelper

    {

        public static Color OppositeColor( Color myColor)
        {
            switch (myColor)
            {
                case Color.Light:
                    return Color.Dark;
                     
                case Color.Dark:
                    return Color.Light;
                     
                case Color.Empty:
                    return Color.Empty;
                default:
                    return Color.Empty;
                     
            }
        }
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



        public static bool IsThreathened((int, int) target, GameState game, Color enemyColor) //onödiggör Ovanstående
        {
            var tempPiece = game.Board[target.Item1, target.Item2].Type.ToString();// vad händer när target ändras? borde inte vára problem bools enums är value types?
            //var targetColor = game.Board[target.Item1, target.Item2].Color.ToString();
            var targetColor = game.Board[target.Item1, target.Item2].Color;
            var myColor = (enemyColor == Color.Dark) ? Color.Light : Color.Dark;

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
                    };

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
        /// <summary>
        /// Finds the position of the king of the specified color
        /// </summary>
        /// <param name="color">the specified color</param>
        /// <returns>tuple int int repressenting the position</returns>
 
        public static (int, int) FindKing(Color myColor, GameState game)
        {
 
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(game.Board[i,j].Type==PieceType.King && game.Board[i, j].Color == myColor)
                    {
                        return (i, j);
                    }
                }
            }

            return (99, 99);        //Shouldn't ever happen
        }
        /// <summary>
        /// checks whether the king of the specified color is checked
        /// </summary>
        /// <param name="color"> the specified color</param>
        /// <returns>true if checked</returns>
 
        public static bool CheckCheck(Color myColor, GameState game)
        {
            (int, int) kingPos = FindKing(myColor, game);

            //return (IsGuarded(kingPos, game, OppositeColor(myColor)));
            return (IsThreathened(kingPos, game, OppositeColor(myColor)));/////////////////TILLBAKA HIT SEN
            //return (CanAnyMoveTo(kingPos, game, OppositeColor(myColor)));

        }
        /// <summary>
        /// checks whether the king of the specified color is checkmated
        /// </summary>
        /// <param name="color">the specified color</param>
        /// <returns>true if check mate</returns>

        public static bool CrudeMateCheck(Color myColor, GameState game)
        {
 
            (int, int) kingPos = FindKing(myColor, game);
            for (int i = kingPos.Item1 -1; i <= kingPos.Item1 +1; i++)
            {
                for (int j = kingPos.Item1 - 1; j <= kingPos.Item1 + 1; j++)
                {
                    if ( i <=7 && j <=7 && i >=0 && j >= 0)
                    {
                        if (
                                !(
                                        (
                                                IsGuarded((i,j),game,OppositeColor(myColor))  
                                                
                                                ||
                                                
                                                game.Board[i,j].Color==myColor && game.Board[i, j].Type != PieceType.King
                                                
                                       )
                                 )
                            )
                        {
                            return false;
                        }
                    }
                }
            }


            return true;
        }

        public static bool RealMateCheck(Color myColor, GameState game)
        {
            GamePiece[,] RestoreFromHere = new GamePiece[8, 8];

            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {
                    switch (game.Board[m,n].Color)
                    {
                        case Color.Light:
                            switch (game.Board[m, n].Type)
                            {
                                case PieceType.NoPiece:
                                    //ERROR
                                    break;
                                case PieceType.Pawn:
                                    RestoreFromHere[m, n] = new Pawn(game, Color.Light);
                                    break;
                                case PieceType.Rook:
                                    RestoreFromHere[m, n] = new Rook(game, Color.Light);
                                    break;
                                case PieceType.Knight:
                                    RestoreFromHere[m, n] = new Knight(game, Color.Light);
                                    break;
                                case PieceType.Bishop:
                                    RestoreFromHere[m, n] = new Bishop(game, Color.Light);
                                    break;
                                case PieceType.Queen:
                                    RestoreFromHere[m, n] = new Queen(game, Color.Light);
                                    break;
                                case PieceType.King:
                                    RestoreFromHere[m, n] = new King(game, Color.Light);
                                    break;
                                default:
                                    //Nothing
                                    break;
                            }
                            break;
                        case Color.Dark:
                            switch (game.Board[m, n].Type)
                            {
                                case PieceType.NoPiece:
                                    //ERROR
                                    break;
                                case PieceType.Pawn:
                                    RestoreFromHere[m, n] = new Pawn(game, Color.Dark);
                                    break;
                                case PieceType.Rook:
                                    RestoreFromHere[m, n] = new Rook(game, Color.Dark);
                                    break;
                                case PieceType.Knight:
                                    RestoreFromHere[m, n] = new Knight(game, Color.Dark);
                                    break;
                                case PieceType.Bishop:
                                    RestoreFromHere[m, n] = new Bishop(game, Color.Dark);
                                    break;
                                case PieceType.Queen:
                                    RestoreFromHere[m, n] = new Queen(game, Color.Dark);
                                    break;
                                case PieceType.King:
                                    RestoreFromHere[m, n] = new King(game, Color.Dark);
                                    break;
                                default:
                                    //Nothing
                                    break;
                            }
                            break;
                        case Color.Empty:
                            RestoreFromHere[m, n] = new NoPiece(game, Color.Empty);
                            break;
                        default:
                            //Nothing
                            break;
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        for (int l = 0; l < 8; l++) //Herrejävlar...
                        {
                            if (game.Board[i,j].Color==myColor &&   game.Board[i,j].CheckLegalMove((i,j),(k,l)))// strunta i denna ifsats?
                            {
                                game.Board[i, j].Move((i, j), (k, l));
                                if (game.Player1.IsPlayerTurn)
                                {
                                    game.Player1.IsPlayerTurn = false;
                                    game.Player2.IsPlayerTurn = true;
                                }
                                else
                                {
                                    game.Player1.IsPlayerTurn = true;
                                    game.Player2.IsPlayerTurn = false;
                                }
                                
                                if (CrudeMateCheck(myColor,game))
                                {
                                    switch (game.Board[k, l].Color)
                                    {
                                        case Color.Light:
                                            switch (RestoreFromHere[k, l].Type) // borde ha flyttat ut detta till funktion...
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    RestoreFromHere[k,l] = new Pawn(game, Color.Light);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[k,l] = new Rook(game, Color.Light);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[k,l] = new Knight(game, Color.Light);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[k,l] = new Bishop(game, Color.Light);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[k,l] = new Queen(game, Color.Light);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[k,l] = new King(game, Color.Light);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Dark:
                                            switch (RestoreFromHere[k, l].Type)
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    game.Board[k,l] = new Pawn(game, Color.Dark);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[k,l] = new Rook(game, Color.Dark);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[k,l] = new Knight(game, Color.Dark);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[k,l] = new Bishop(game, Color.Dark);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[k,l] = new Queen(game, Color.Dark);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[k,l] = new King(game, Color.Dark);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Empty:
                                            game.Board[k, l] = new NoPiece(game, Color.Empty);
                                            break;
                                        default:
                                            //Nothing
                                            break;
                                    }
 

                                    ////////////////////
                                    switch (game.Board[i,j].Color)
                                    {
                                        case Color.Light:
                                            switch (RestoreFromHere[i,j].Type) // borde ha flyttat ut detta till funktion...
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    RestoreFromHere[i,j] = new Pawn(game, Color.Light);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[i,j] = new Rook(game, Color.Light);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[i,j] = new Knight(game, Color.Light);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[i,j] = new Bishop(game, Color.Light);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[i,j] = new Queen(game, Color.Light);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[i,j] = new King(game, Color.Light);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Dark:
                                            switch (RestoreFromHere[i,j].Type)
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    game.Board[i,j] = new Pawn(game, Color.Dark);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[i,j] = new Rook(game, Color.Dark);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[i,j] = new Knight(game, Color.Dark);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[i,j] = new Bishop(game, Color.Dark);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[i,j] = new Queen(game, Color.Dark);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[i,j] = new King(game, Color.Dark);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Empty:
                                            game.Board[i,j] = new NoPiece(game, Color.Empty);
                                            break;
                                        default:
                                            //Nothing
                                            break;
                                    }



                                }
                                /*
                                 * 
                                 * 
                                 * 
                                 * 
                                 * */
                                else
                                {
                                    switch (game.Board[k, l].Color)
                                    {
                                        case Color.Light:
                                            switch (RestoreFromHere[k, l].Type) // borde ha flyttat ut detta till funktion...
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    RestoreFromHere[k, l] = new Pawn(game, Color.Light);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[k, l] = new Rook(game, Color.Light);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[k, l] = new Knight(game, Color.Light);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[k, l] = new Bishop(game, Color.Light);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[k, l] = new Queen(game, Color.Light);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[k, l] = new King(game, Color.Light);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Dark:
                                            switch (RestoreFromHere[k, l].Type)
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    game.Board[k, l] = new Pawn(game, Color.Dark);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[k, l] = new Rook(game, Color.Dark);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[k, l] = new Knight(game, Color.Dark);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[k, l] = new Bishop(game, Color.Dark);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[k, l] = new Queen(game, Color.Dark);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[k, l] = new King(game, Color.Dark);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Empty:
                                            game.Board[k, l] = new NoPiece(game, Color.Empty);
                                            break;
                                        default:
                                            //Nothing
                                            break;
                                    }


                                    ////////////////////
                                    switch (game.Board[i, j].Color)
                                    {
                                        case Color.Light:
                                            switch (RestoreFromHere[i, j].Type) // borde ha flyttat ut detta till funktion...
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    RestoreFromHere[i, j] = new Pawn(game, Color.Light);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[i, j] = new Rook(game, Color.Light);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[i, j] = new Knight(game, Color.Light);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[i, j] = new Bishop(game, Color.Light);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[i, j] = new Queen(game, Color.Light);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[i, j] = new King(game, Color.Light);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Dark:
                                            switch (RestoreFromHere[i, j].Type)
                                            {
                                                case PieceType.NoPiece:
                                                    //ERROR
                                                    break;
                                                case PieceType.Pawn:
                                                    game.Board[i, j] = new Pawn(game, Color.Dark);
                                                    break;
                                                case PieceType.Rook:
                                                    game.Board[i, j] = new Rook(game, Color.Dark);
                                                    break;
                                                case PieceType.Knight:
                                                    game.Board[i, j] = new Knight(game, Color.Dark);
                                                    break;
                                                case PieceType.Bishop:
                                                    game.Board[i, j] = new Bishop(game, Color.Dark);
                                                    break;
                                                case PieceType.Queen:
                                                    game.Board[i, j] = new Queen(game, Color.Dark);
                                                    break;
                                                case PieceType.King:
                                                    game.Board[i, j] = new King(game, Color.Dark);
                                                    break;
                                                default:
                                                    //Nothing
                                                    break;
                                            }
                                            break;
                                        case Color.Empty:
                                            game.Board[i, j] = new NoPiece(game, Color.Empty);
                                            break;
                                        default:
                                            //Nothing
                                            break;
                                    }
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static GamePiece[,] CopyCurrentBoard (GameState game)
        {
            GamePiece[,] RestoreFromHere = new GamePiece[8, 8];

            for (int m = 0; m < 8; m++)
            {
                for (int n = 0; n < 8; n++)
                {

                    switch (game.Board[m,n].Color)
                    {
                        case Color.Light:
                            switch (game.Board[m,n].Type) // borde ha flyttat ut detta till funktion...
                            {
                                case PieceType.NoPiece:
                                    //ERROR
                                    break;
                                case PieceType.Pawn:
                                    RestoreFromHere[m,n] = new Pawn(game, Color.Light);
                                    break;
                                case PieceType.Rook:
                                    RestoreFromHere[m,n] = new Rook(game, Color.Light);
                                    break;
                                case PieceType.Knight:
                                    RestoreFromHere[m,n] = new Knight(game, Color.Light);
                                    break;
                                case PieceType.Bishop:
                                    RestoreFromHere[m,n] = new Bishop(game, Color.Light);
                                    break;
                                case PieceType.Queen:
                                    RestoreFromHere[m,n] = new Queen(game, Color.Light);
                                    break;
                                case PieceType.King:
                                    RestoreFromHere[m,n] = new King(game, Color.Light);
                                    break;
                                default:
                                    //Nothing
                                    break;
                            }
                            break;
                        case Color.Dark:
                            switch (game.Board[m,n].Type)
                            {
                                case PieceType.NoPiece:
                                    //ERROR
                                    break;
                                case PieceType.Pawn:
                                    RestoreFromHere[m,n] = new Pawn(game, Color.Dark);
                                    break;
                                case PieceType.Rook:
                                    RestoreFromHere[m,n] = new Rook(game, Color.Dark);
                                    break;
                                case PieceType.Knight:
                                    RestoreFromHere[m,n] = new Knight(game, Color.Dark);
                                    break;
                                case PieceType.Bishop:
                                    RestoreFromHere[m,n] = new Bishop(game, Color.Dark);
                                    break;
                                case PieceType.Queen:
                                    RestoreFromHere[m,n] = new Queen(game, Color.Dark);
                                    break;
                                case PieceType.King:
                                    RestoreFromHere[m,n] = new King(game, Color.Dark);
                                    break;
                                default:
                                    //Nothing
                                    break;
                            }
                            break;
                        case Color.Empty:
                            RestoreFromHere[m,n] = new NoPiece(game, Color.Empty);
                            break;
                        default:
                            //Nothing
                            break;
                    }




                }
            }

            return RestoreFromHere;
                    //throw new NotImplementedException();
        }

        public static void RevertMove(GamePiece[,] myPieces) 
        { 
        
        
        }



    }
}
