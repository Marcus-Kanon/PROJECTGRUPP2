﻿
using Newtonsoft.Json;
using System.Net;
using ClientManual.Models;

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
Console.WriteLine("Player1Id: " + game.GameId);
Console.WriteLine("Player2d: " + game.GameId);
Console.WriteLine("Press Enter to Continue");
Console.ReadLine();

/*
 * 5. Våra två API:er: GetBoard och Move kräver att man anger parametrar.
 * Parametrar anger man i adressen när man ansluter API:n
 * Om vi ska kalla på GetBoard så behöver vi ange ett GameId och ett PlayerId:
 */

//Ansluter API med parametrar GameId/Player1Id
results = new WebClient().DownloadString("https://localhost:7223/api/GetBoard/" + game.GameId + "/" + game.Player1Id);

//Deserialiserar svaret vi får
game = JsonConvert.DeserializeObject<GameState>(results);

//Skriver ut schackbrädet
for (int x = 0; x < 8; x++)
{
    for (int y = 0; y < 8; y++)
    {
        var name = game.Board[x, y]?.Name ?? "null";
        Console.Write(name + " | ");
    }
    Console.WriteLine("\n----------------------------------------------------------------");
}
Console.ReadLine();