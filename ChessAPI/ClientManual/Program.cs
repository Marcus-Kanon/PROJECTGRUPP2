using System.Net;
using ClientManual;
using Newtonsoft.Json;
using SharedCsharpModels.Models;

ConsoleHelper.SetCurrentFont("MS Gothic", 20); //för att få schackpjäserna att funka så måste vi byta font till t.ex MS Gothic som kan läsa hexkoden, lagt fontsize = 20 för tillfället så pjäserna syns tydligare
const int BOARD_WIDTH = 8;

/*
 * 1. Installera Nuget: Newtonsoft.Json
 * Det används för att serialisera/deserialisera objekten som ska skickas/tas emot av API
 */

/*
 * 2. Lägg till Models/GameState.cs och Models/GamePiece.cs till projektet
 * Objekten som ska serialiseras/deserialiseras är av typen GameState.
 * Därför behöver Newtonsoft.Json ha klassen GameState för att veta hur objekten ska serialiseras/deserialiseras
 */

/*
 * 3. För att be vår API att skapa ett nytt spel åt oss behöver vi ansluta till dess adress på något sätt. T ex så här:
 */

//Results innehåller svaret vi får från vår API
string results = new WebClient().DownloadString("https://localhost:7223/api/CreateGame");

/*
 * 4. Eftersom svaret vi får från vår API är ett serialiserat objekt, altså en Json-sträng. Så måste vi deserialisera det:
 */

//Här skapar vi ett objekt genom at deserialisera informationen våran API gav oss
GameState game = JsonConvert.DeserializeObject<GameState>(results);

//Skriver ut några properties från vårat objekt
Console.WriteLine("GameId: " + game.GameId);
Console.WriteLine("Player1Id: " + game.Player1Id);
Console.WriteLine("Player2d: " + game.Player2Id);
Console.WriteLine("Press Enter to Continue");
Console.ReadLine();

/*
 * 5. Våra två API:er: GetBoard och Move kräver att man anger parametrar.
 * Parametrar anger man i adressen när man ansluter API:n
 * Om vi ska kalla på GetBoard så behöver vi ange ett GameId och ett PlayerId:
 */

while (true)
{
    //Ansluter API med parametrar GameId/Player1Id
    results = new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + game.GameId + "/" + game.Player1Id);

    //Deserialiserar svaret vi får
    game = JsonConvert.DeserializeObject<GameState>(results);
    //show the empty chess board
    printChessBoard();

    //Väljer parametrar för Move API:n -- TODO: gör en metod
    Console.WriteLine("Choose coordinates of piece to move: ");
    Console.Write("current row: "); var oldX = Console.ReadLine();
    Console.Write("current column: "); var oldY = Console.ReadLine();
    Console.Write("new row: "); var newX = Console.ReadLine();
    Console.Write("new column: "); var newY = Console.ReadLine();

    /* TO DO?? 
    //ask the user for an x and y coordinate where we will place a piece
    Cell currentCell = setCurrentCell(myBoard);
    currentCell.CurrentlyOccupied = true;

    // visa alla "legal moves" för vald pjäs
    DisplayNextLegalMoves();

    //printa schackbrädan igen med alla "legal moves". 
    printChessBoard();
    */


    //Ansluter Move API:n
    results = new WebClient().DownloadString("https://localhost:7223/api/Move/" + $"{game.GameId}/{game.Player1Id}/{oldX}/{oldY}/{newX}/{newY}");

    //Move API:n returnerar ett string objekt som det är nu så det behövs ingen deserialisering
    string message = results;

    Console.Write("\nMove message: ");
    Console.WriteLine(message);
    Console.WriteLine("Press enter to continue...");
    Console.ReadLine();
}


void printChessBoard()
{
    Console.WriteLine("     0    1    2    3    4    5    6    7");

    //print the chess board. Use an X for occupied square. Use a + for legal move. Use . for empty cell
    for (int row = 0; row < BOARD_WIDTH; row++) //one row at a time
    {
        Console.Write("  ");
        for (int i = 0; i < BOARD_WIDTH; i++)
        {
            Console.Write("+----");
        }
        Console.Write("+");
        Console.WriteLine();

        for (int column = 0; column < BOARD_WIDTH; column++) //one column at a time
        {
            if (column == 0)
            {
                Console.Write(row + " ");
            }
            Console.Write("|");

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            if (row % 2 == 0 && column % 2 != 0 || row % 2 != 0 && column % 2 == 0)
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            else
                Console.BackgroundColor = ConsoleColor.DarkGray;

            var name = game.Board[row, column]?.Name ?? "null";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Checkar om OK att röra pjäsen - MoveHelper/För att markera vart man kan röra sig?
            //if (CurrentlyOccupied)
            //{
            //    if (game.Board[row, column].Color == false)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Black;
            //        Console.Write($" {name}  ");
            //    }
            //    else
            //    {
            //        Console.ForegroundColor = ConsoleColor.White;
            //        Console.Write($" {name}  ");
            //    }
            //}
            //else if (IsLegalMove)
            //{
            //    Console.Write(" ++ ");
            //}
            {
                if (game.Board[row, column].Color == false)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($" {name}  ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($" {name}  ");
                }
            }
            Console.ResetColor();
        }
        Console.Write("|\n");
    }

    Console.Write("  ");
    for (int j = 0; j < BOARD_WIDTH; j++)
    {
        Console.Write("+----");
    }
    Console.Write("+");
    Console.WriteLine();

    Console.WriteLine("============================================");
}


