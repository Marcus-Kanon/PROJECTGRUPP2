namespace ChessAPI.GamePieces.MoveHelper
{
    public static class MoveHelper

    {
        public static bool LegalMoveVertical ((int,int) oldCoords, (int,int) newCooords, Game game, bool isUp)
        {
            int plusMinus = isUp ? 1 : -1;
            if (oldCoords.Item1 != newCooords.Item1) return false;
            int start = oldCoords.Item2;
            while (start != newCooords.Item2)
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
        public static bool LegalMoveLeftDiagonal((int, int) oldCoords, (int, int) newCooords, Game game, bool isUp)
        {
            return true;
        }
        public static bool LegalMoveRightDiagonal((int, int) oldCoords, (int, int) newCooords, Game game, bool isUp)
        {
            return true;
        }

    }
}
