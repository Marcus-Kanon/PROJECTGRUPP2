namespace ChessAPI.GamePieces
{
    public static class MoveHelper

    {
        public static bool LegalMoveVertical ((int,int) oldCoords, (int,int) newCooords, Game game, bool isUp)
        {
            int plusMinus = isUp ? 1 : -1;
            if (oldCoords.Item1 != newCooords.Item1) return false;
            int start = oldCoords.Item2;
            while (start != newCooords.Item2 && start < 7 && start > 0)
            {
                start = start + 1 * plusMinus;
                if (game.Board[oldCoords.Item1,start].Name!=" " || game.Board[oldCoords.Item1, start].Color == game.Board[oldCoords.Item1, oldCoords.Item2].Color)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool LegalMoveHorizontal((int, int) oldCoords, (int, int) newCooords, Game game, bool isRight)
        {
            return true;
        }
        public static bool LegalMoveLeftDiagonals((int, int) oldCoords, (int, int) newCooords, Game game, bool isUp)
        {
            return true;
        }
        public static bool LegalMoveRightDiagonals((int, int) oldCoords, (int, int) newCooords, Game game, bool isUp)
        {
            return true;
        }

    }
}
