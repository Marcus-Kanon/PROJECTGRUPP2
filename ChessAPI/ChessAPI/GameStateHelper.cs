using SharedCsharpModels.Models;

namespace ChessAPI
{
    public class GameStateHelper : GameState
    {
        //public void ChangePlayerTurn()
        //{
        //    if (Player1.IsPlayerTurn)
        //    {
        //        Player1.IsPlayerTurn = false;
        //        Player2.IsPlayerTurn = true;
        //    }
        //    else
        //    {
        //        Player1.IsPlayerTurn = true;
        //        Player2.IsPlayerTurn = false;
        //    }
        //}

        public static void Turn(Player player)
        {
            if (player.Color == Color.Light)
            {
                Console.Write($"Player {player.Id}'s (WHITE) turn: ");
            }
            else
            {
                Console.Write($"Player {player.Id}'s (BLACK) turn: ");
            }
        }
    }
}
