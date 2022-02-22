using SharedCsharpModels.Models;

namespace ChessAPI.GamePieces
{
    public static class MoveHelper

    {
        public static bool LegalMoveVertical ((int,int) oldCoords, (int,int) newCooords, GameState game, bool isUp)
        {

            int plusMinus = isUp ? 1 : -1;
            if (oldCoords.Item1 != newCooords.Item1) return false;

            int start = oldCoords.Item2;
            do
            {
                start = start + 1 * plusMinus;
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

                start = start + 1 * plusMinus;


                //if (game.Board[start, oldCoords.Item2].Name != " " && game.Board[start,oldCoords.Item2 ].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                    if (
                        game.Board[start, oldCoords.Item2].Name != " "

                            && (game.Board[start, oldCoords.Item2].Color == game.Board[start, oldCoords.Item2].Color
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
                start2 = start2 + 1 * plusMinus;
 
                if (start < 0 || start > 7 || start2 < 0 || start2 > 7 || (start==newCooords.Item1 && start2 != newCooords.Item2 ) ) return false;
                //if ((game.Board[start, start2].Name != " " && start != newCooords.Item1) && game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                if (
                    (game.Board[start, start2].Name != " ") 
                    
                    &&      ( game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color
                              ||
                             ( start != newCooords.Item1 || start2 != newCooords.Item2)
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
                start2 = start2 + 1 * plusMinus;
                if (start < 0 || start > 7 || start2 < 0 || start2 > 7 || (start == newCooords.Item1 && start2 != newCooords.Item2)) return false;
                //if ((game.Board[start, start2].Name != " " ) && game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                if (
                    (game.Board[start, start2].Name != " ")

                    && (game.Board[start, start2].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color
                              ||
                             (start != newCooords.Item1 || start2 != newCooords.Item2)
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

    }
}
