using ClientTEST;

var APIHandler = new SelectAPI();

while(true)
{
    APIHandler.Menu();
    APIHandler.Act();

    Console.WriteLine("GameId: " + APIHandler.Game.GameId);
    Console.WriteLine("Player1Id: " + APIHandler.Game.Player1Id);
    Console.WriteLine("Player2Id: " + APIHandler.Game.Player2Id);
}


