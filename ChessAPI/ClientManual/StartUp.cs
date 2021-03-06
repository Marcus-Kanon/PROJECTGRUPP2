using System.Net;
using Newtonsoft.Json;
using SharedCsharpModels.Models;
using SharedCsharpModels.View;
#pragma warning disable SYSLIB0014 // Type or member is obsolete

namespace ClientManual
{
    public static class StartUp
    {
        /// <summary>
        /// Runs the game.
        /// </summary>
        public static void Run()
        {
            SetWindowSize();
            ConsoleHelper.SetCurrentFont("MS Gothic", 20);

            GameState game = new();
            string playerID = "";
            string results = "";
            UserMenu(ref game, ref playerID, ref results);

            while (true)
            {
                Console.Clear();
                Print.Header();
                Console.WriteLine($"GameId: {game.GameId}\n");
                results = GetBoard(playerID, game.GameId);

                game = Deserializer(results);

                PlayerTurn(game, playerID);
                Print.ChessBoard(game);

                int oldY = 0;
                int newY = 0;
                int oldX = 0;
                int newX = 0;
                RefreshMoveOrExit(game, playerID, ref results, ref oldY, ref newY, ref oldX, ref newX);

                Console.WriteLine("\nPress enter to continue...");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Prompts user to refresh the board or make a move, or exit the game.
        /// </summary>
        /// <param name="game">The current gamestate.</param>
        /// <param name="playerID">The user's player ID.</param>
        /// <param name="results">The results.</param>
        /// <param name="oldY">The current y coordinate.</param>
        /// <param name="newY">The new y coordinate.</param>
        /// <param name="oldX">The current x coordinate.</param>
        /// <param name="newX">The new x coordinate.</param>
        private static void RefreshMoveOrExit(GameState game, string playerID, ref string results, ref int oldY, ref int newY, ref int oldX, ref int newX)
        {
            Console.WriteLine("Do you want to (R)efresh or to make a (M)ove      [Press ESC to exit game]");

            var input = Console.ReadKey();

            while (input.Key != ConsoleKey.R && input.Key != ConsoleKey.M && input.Key != ConsoleKey.Escape)
                input = Console.ReadKey();

            if (input.Key == ConsoleKey.M)
            {
                results = AskCoordinates(game, playerID, ref oldY, ref newY, ref oldX, ref newX);
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                DisplayExitMessage();
            }
        }

        /// <summary>
        /// Displays an exit message to the user.
        /// </summary>
        private static void DisplayExitMessage()
        {
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press enter to exit game.");
            Console.ReadLine();
            Environment.Exit(0);
        }

        /// <summary>
        /// Displays player's turn.
        /// </summary>
        /// <param name="game">The current gamestate.</param>
        /// <param name="playerID">The user's player ID.</param>
        private static void PlayerTurn(GameState game, string playerID)
        {
            Console.WriteLine($"Player Turn: {game.MovingPlayer.Color} ({game.MovingPlayer.Id})");
            Console.WriteLine($"You are playing as player {playerID}");
        }

        /// <summary>
        /// Displays the menu prompting the user to create a new game or join an existing game.
        /// </summary>
        /// <param name="game">The current gamestate.</param>
        /// <param name="playerID">The user's player ID.</param>
        /// <param name="results">The API answer.</param>
        private static void UserMenu(ref GameState game, ref string playerID, ref string results)
        {
            Print.Menu();
            var userChoice = Console.ReadKey();
            while (userChoice.Key != ConsoleKey.N && userChoice.Key != ConsoleKey.J && userChoice.Key != ConsoleKey.Escape)
                userChoice = Console.ReadKey();

            if (userChoice.Key == ConsoleKey.N)
            {
                CreateANewGame(out game, out playerID, out results);
            }
            else if (userChoice.Key == ConsoleKey.J)
            {
                JoinGame(out game, out playerID, out results);
            }
            else if (userChoice.Key == ConsoleKey.E)
            {
                DisplayExitMessage();
            }
        }

        /// <summary>
        /// Runs the logic behind creating a new game
        /// </summary>
        /// <param name="game">The current gamestate.</param>
        /// <param name="playerID">The user's player ID.</param>
        /// <param name="results">The API answer.</param>
        private static void CreateANewGame(out GameState game, out string playerID, out string results)
        {
            results = GetCreateGame();
            game = Deserializer(results);
            playerID = game.Player1.Id;
        }

        /// <summary>
        /// Runs the logic behind joining a game.
        /// </summary>
        /// <param name="game">The current gamestate.</param>
        /// <param name="playerID">The user's player ID.</param>
        /// <param name="results">The API answer.</param>
        private static void JoinGame(out GameState game, out string joinplayerID, out string results)
        {
            AskToJoinGame(out joinplayerID, out string joinGameID);
            results = GetBoard(joinplayerID, joinGameID);
            game = Deserializer(results);
        }

        /// <summary>
        /// Asks the user for gameID and playerID to join a game.
        /// </summary>
        /// <param name="playerID">The user's player ID.</param>
        /// <param name="joinGameID">The game ID.</param>
        private static void AskToJoinGame(out string joinplayerID, out string joinGameID)
        {
            Console.Clear();
            Console.Write("Enter game ID: ");
            joinGameID = Console.ReadLine() ?? "";
            Console.Write("Enter player ID: ");
            joinplayerID = Console.ReadLine() ?? "";
        }

        /// <summary>
        /// Deserializers the json string the API sends us.
        /// </summary>
        /// <param name="results">The API answer.</param>
        /// <returns></returns>
        private static GameState Deserializer(string results) => JsonConvert.DeserializeObject<GameState>(results) ?? new GameState();

        /// <summary>
        /// Connects to API to get the state of chosen chessboard.
        /// </summary>
        /// <param name="playerID">The user's player ID.</param>
        /// <param name="GameID">The game's ID.</param>
        /// <returns></returns>
        private static string GetBoard(string? playerID, string? GameID) => new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + GameID + "/" + playerID);

        /// <summary>
        /// Connects to API to create a new game.
        /// </summary>
        /// <returns></returns>
        private static string GetCreateGame() => new WebClient().DownloadString("https://localhost:7223/api/creategame/create");

        /// <summary>
        /// Asks player for the coordinates.
        /// </summary>
        /// <param name="game">The current gamestate.</param>
        /// <param name="playerID">The user's player ID.</param>
        /// <param name="oldY">The current y coordinate.</param>
        /// <param name="newY">The new y coordinate.</param>
        /// <param name="oldX">The current x coordinate</param>
        /// <param name="newX">The new x coordinate.</param>
        /// <returns></returns>
        private static string AskCoordinates(GameState game, string playerID, ref int oldY, ref int newY, ref int oldX, ref int newX)
        {
            string results;
            Console.WriteLine("\nChoose coordinates of piece to move: ");
            Console.Write("current row (vertical): "); oldY = InputCoordinate();
            Console.Write("current column (horizontal): "); oldX = InputCoordinate();
            Console.Write("new row (vertical): "); newY = InputCoordinate();
            Console.Write("new column (horizontal): "); newX = InputCoordinate();

            results = new WebClient().DownloadString("https://localhost:7223/api/Move/" + $"{game.GameId}/{playerID}/{oldX}/{oldY}/{newX}/{newY}");

            ShowMoveMessage(results, playerID);
            return results;
        }

        /// <summary>
        /// Sets the size of the window.
        /// </summary>
        private static void SetWindowSize()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            Console.WindowWidth = 80;
            Console.WindowHeight = 40;
            Console.BufferWidth = 80;
            Console.BufferHeight = 40;
#pragma warning restore CA1416 // Validate platform compatibility
        }

        /// <summary>
        /// Checks that the input coordinate is valid and returns a message to user.
        /// </summary>
        /// <param name="input">The user's input.</param>
        /// <returns></returns>
        private static int InputCoordinate()
        {
            int input;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input >= 0 && input <= 8)
                    {
                        break;
                    }
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

        /// <summary>
        /// Translates the move message to a userfriendly message.
        /// </summary>
        /// <param name="results">The MoveValidMessage sent from API.</param>
        /// <param name="playerID">The user's player ID.</param>
        private static void ShowMoveMessage(string results, string playerID)
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
                case "5":
                    Console.WriteLine("You can't move the other player's piece!");
                    break;
                default:
                    Console.WriteLine($"It is not your turn yet, player {playerID}");
                    break;
            }
        }
    }
}
#pragma warning restore SYSLIB0014 // Type or member is obsolete