using System.Net;
using Newtonsoft.Json;
using SharedCsharpModels.Models;
using SharedCsharpModels.View;

namespace ClientManual
{
    public static class StartUp
    {
        public static void Run()
        {
            SetWindowSize();

            ConsoleHelper.SetCurrentFont("MS Gothic", 20);

            Print.Menu();
            var userChoice = Console.ReadKey();

            GameState game = null;
            string joinplayerID = "";
            string results = "";

            if (userChoice.Key == ConsoleKey.N)
            {
                results = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");
                game = JsonConvert.DeserializeObject<GameState>(results);
                joinplayerID = game.Player1.Id;
            }

            else if (userChoice.Key == ConsoleKey.J)
            {
                Console.Clear();
                Console.Write("Enter game ID: ");
                var joinGameID = Console.ReadLine();
                Console.Write("Enter player ID: ");
                joinplayerID = Console.ReadLine();
                results = new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + joinGameID + "/" + joinplayerID);
                game = JsonConvert.DeserializeObject<GameState>(results);

            }


            int counter = 0;

            ConsoleKeyInfo input = new();

            while (true)
            {
                Console.Clear();
                Print.Header();
                Console.WriteLine($"GameId: {game.GameId}\n");
                counter++;
                results = new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + game.GameId + "/" + joinplayerID);

                //Deserialiserar svaret vi får
                game = JsonConvert.DeserializeObject<GameState>(results);

                Console.WriteLine($"Player Turn: {game.MovingPlayer.Color} ({game.MovingPlayer.Id})");
                Print.ChessBoard(counter, game);

                int oldY = 0;
                int newY = 0;
                int oldX = 0;
                int newX = 0;

                Console.WriteLine("Do you want to (R)efresh or to make a (M)ove");

                input = Console.ReadKey();

                while (input.Key != ConsoleKey.R && input.Key != ConsoleKey.M)
                    input = Console.ReadKey();

                if (input.Key == ConsoleKey.M)
                    results = AskCoordinates(game, joinplayerID, ref oldY, ref newY, ref oldX, ref newX);

                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }

        }

        private static string AskCoordinates(GameState game, string joinplayerID, ref int oldY, ref int newY, ref int oldX, ref int newX)
        {
            string results;
            Console.WriteLine("\nChoose coordinates of piece to move: ");
            Console.Write("current row (vertical): "); oldY = InputCoordinate(oldY);
            Console.Write("current column (horizontal): "); oldX = InputCoordinate(oldX);
            Console.Write("new row (vertical): "); newY = InputCoordinate(newY);
            Console.Write("new column (horizontal): "); newX = InputCoordinate(newX);

            results = new WebClient().DownloadString("https://localhost:7223/api/Move/" + $"{game.GameId}/{joinplayerID}/{oldX.ToString()}/{oldY.ToString()}/{newX.ToString()}/{newY.ToString()}");

            ShowMoveMessage(results, joinplayerID);
            return results;
        }

        private static void SetWindowSize()
        {
            Console.WindowWidth = 80;
            Console.WindowHeight = 40;
            Console.BufferWidth = 80;
            Console.BufferHeight = 40;
        }

        private static int InputCoordinate(int input)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= 0 && input <= 8)
                        break;
                    else
                    {
                        Console.Clear();
                        Console.Write("Invalid coordinate, try again: ");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write("Must be a number, try again: ");
                }
                    
            }
            return input;
        }

        private static void ShowMoveMessage(string results, string joinplayerID)
        {
            Console.Write("\nMove message: ");
            switch (results)
            {
                case "0":
                    Console.WriteLine("You have successfully moved your chess piece.");
                    break;
                case "1":
                    Console.WriteLine("Cannot move out of the board.");
                    break;
                case "2":
                    Console.WriteLine("That spot is blocked");
                    break;
                case "3":
                    Console.WriteLine("Invalid move.");
                    break;
                case "4":
                    Console.WriteLine("You will check yourself!");
                    break;
                default:
                    Console.WriteLine($"It is not your turn yet, player {joinplayerID}");
                    break;
            }
        }
    }
}