using System.Net;
using ClientManual;
using Newtonsoft.Json;
using SharedCsharpModels.Models;
using SharedCsharpModels.View;

ConsoleHelper.SetCurrentFont("MS Gothic", 20); //för att få schackpjäserna att funka så måste vi byta font till t.ex MS Gothic som kan läsa hexkoden, lagt fontsize = 20 för tillfället så pjäserna syns tydligare

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
string results = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");
results = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");
results = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");
results = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");
results = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");

Console.WriteLine("Do you want to start a (n)ew game or (j)oin an existing one?");
var userChoice = Console.ReadKey();

GameState game = null;

if (userChoice.Key == ConsoleKey.N)
{
    results = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");

    /*
    * 4. Eftersom svaret vi får från vår API är ett serialiserat objekt, altså en Json-sträng. Så måste vi deserialisera det:
    */

    //Här skapar vi ett objekt genom at deserialisera informationen våran API gav oss
    game = JsonConvert.DeserializeObject<GameState>(results);
}
else if (userChoice.Key == ConsoleKey.J)
{
    results = new WebClient().DownloadString("https://localhost:7223/api/creategame/list");

    var gameStates = JsonConvert.DeserializeObject<List<GameState>>(results);

    Console.Clear();

    var i = 0;

    foreach (var match in gameStates)
    {
        Console.WriteLine($"Game Id: [{i}] {match.GameId}");
        i++;
    }

    Console.Write("Select Game: ");

    int.TryParse(Console.ReadLine(), out var gameIdChoice);
    game = gameStates[gameIdChoice];
}

/*
 * 4. Eftersom svaret vi får från vår API är ett serialiserat objekt, altså en Json-sträng. Så måste vi deserialisera det:
 */

//Här skapar vi ett objekt genom at deserialisera informationen våran API gav oss
//GameState game = JsonConvert.DeserializeObject<GameState>(results);

GamePiece gamePiece = new(game, Color.Dark);
gamePiece.Name = "\u265E";

//Skriver ut några properties från vårat objekt
//Print.printStats(game);

/*
 * 5. Våra två API:er: GetBoard och Move kräver att man anger parametrar.
 * Parametrar anger man i adressen när man ansluter API:n
 * Om vi ska kalla på GetBoard så behöver vi ange ett GameId och ett PlayerId:
 */
int counter = 0;


//TODO ------------------- FIXA MENYN
Console.Clear();
Print.Header();
Console.ReadLine();

while (true)
{
    Console.Clear();
    Print.Header();
    Console.WriteLine($"GameId: {game.GameId}\n");
    counter++;
    //Ansluter API med parametrar GameId/Player1Id
    //if (counter % 2 == 0)
    results = new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + game.GameId + "/" + game.Player1.Id);
    //else
    //    results = new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + game.GameId + "/" + game.Player2.Id);

    //Deserialiserar svaret vi får
    game = JsonConvert.DeserializeObject<GameState>(results);

    //show the empty chess board
    if (counter % 2 != 0)
        Print.Turn(game.Player1);
    else
        Print.Turn(game.Player2);

    Print.ChessBoard(counter, game);

    //game.ChangeTurns();

    //Väljer parametrar för Move API:n -- TODO: gör en metod
    Console.WriteLine("Choose coordinates of piece to move: ");
    Console.Write("current row (vertical): "); var oldX = Console.ReadLine();
    Console.Write("current column (horizontal): "); var oldY = Console.ReadLine();
    Console.Write("new row (vertical):: "); var newX = Console.ReadLine();
    Console.Write("new column (horizontal): "); var newY = Console.ReadLine();


    //Ansluter Move API:n
    //if (counter % 2 == 0)
    results = new WebClient().DownloadString("https://localhost:7223/api/Move/" + $"{game.GameId}/{game.Player1.Id}/{oldX}/{oldY}/{newX}/{newY}");
    //else
    //     results = new WebClient().DownloadString("https://localhost:7223/api/Move/" + $"{game.GameId}/{game.Player2.Id}/{oldX}/{oldY}/{newX}/{newY}");

    //Move API:n returnerar ett string objekt som det är nu så det behövs ingen deserialisering
    string message = results;

    Console.Write("\nMove message: ");
    Console.WriteLine(message);
    Console.WriteLine("Press enter to continue...");
    Console.ReadLine();
}
