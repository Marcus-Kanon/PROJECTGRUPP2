
using Newtonsoft.Json;
using System.Net;
using ClientManual;
using SharedCsharpModels.Models;

ConsoleHelper.SetCurrentFont("MS Gothic", 20); //för att få schackpjäserna att funka så måste vi byta font till t.ex MS Gothic som kan läsa hexkoden, lagt fontsize = 20 för tillfället så pjäserna syns tydligare
const int BOARD_WIDTH = 8;
string HorizontalSymbol = "*----";
string VerticalSymbol = "| ";

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

/* TEST FÖR ATT FIXA FONTEN SÅ MAN KAN LÄSA PJÄSTECKEN, SKA TAS BORT
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("\u2659");
Console.ReadLine();
*/

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

while(true)
{
    //Ansluter API med parametrar GameId/Player1Id
    results = new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + game.GameId + "/" + game.Player1Id);

    //Deserialiserar svaret vi får
    game = JsonConvert.DeserializeObject<GameState>(results);

    //Skriver ut schackbrädet
    Console.Clear();
    Console.WriteLine("     0    1    2    3    4    5    6    7");
    for (int y = 0; y < BOARD_WIDTH; y++)
    {
        Console.Write("  ");
        for (int i = 0; i < BOARD_WIDTH; i++)
        {
            Console.Write(HorizontalSymbol);
        }

        Console.Write("*\n");

        for (int x = 0; x < BOARD_WIDTH; x++)
        {
            if(x == 0)
                Console.Write(y + " ");
            var name = game.Board[x, y]?.Name ?? "null";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if(game.Board[x,y].Name == "\u265F")
                Console.Write(VerticalSymbol + name + " ");
            else
                Console.Write(VerticalSymbol + name + "  ");
        }
        Console.Write("|\n");
    }
    Console.Write("  ");
    for (int x = 0; x < 8; x++)
    {
        Console.Write(HorizontalSymbol);
    }
    Console.Write("*\n\n");

    //Väljer parametrar för Move API:n
    Console.WriteLine("Choose coordinates of piece to move: ");
    Console.Write("old column: "); var oldX = Console.ReadLine();
    Console.Write("old row: "); var oldY = Console.ReadLine();
    Console.Write("new column: "); var newX = Console.ReadLine();
    Console.Write("new row: "); var newY = Console.ReadLine();

    //Ansluter Move API:n
    results = new WebClient().DownloadString("https://localhost:7223/api/Move/" + $"{game.GameId}/{game.Player1Id}/{oldX}/{oldY}/{newX}/{newY}");

    //Move API:n returnerar ett string objekt som det är nu så det behövs ingen deserialisering
    string message = results;

    Console.Write("\nMove message: ");
    Console.WriteLine(message);
    Console.WriteLine("Press enter to continue...");
    Console.ReadLine();
}