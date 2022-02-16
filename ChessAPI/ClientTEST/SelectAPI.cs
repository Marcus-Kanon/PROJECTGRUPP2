using ClientTEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTEST
{
    internal class SelectAPI
    {
        public int Choice { get; set; } = 0;
        public GameState Game { get; set; } = new GameState();
        public string MoveMessage { get; set; } = "";
        ConnectToAPI Connection = new ConnectToAPI();

        public void Menu()  
        {
            Console.WriteLine("1. Create new game (api/CreateGame)");
            Console.WriteLine("2. Get Board (api/GetBoard)");
            Console.WriteLine("3. Move game piece (api/Move)");

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice));

            Choice = choice;
        }

        public void Act()
        {
            switch (Choice)
            {
                case 1:
                    Connection.SetController("CreateGame").MakeRequest();
                    var createGameDeserializer = new Deserializer(Connection.Results);
                    Game = createGameDeserializer.GameState;
                    break;
                case 2:
                    Connection.SetController("GetBoard")
                        .SetParameter(Game.GameId)
                        .SetParameter(Game.Player1Id)
                        .MakeRequest();
                    var getBoardDeserializer = new Deserializer(Connection.Results);
                    Game = getBoardDeserializer.GameState;
                    break;
                case 3:
                    Connection.SetController("Move")
                        .SetParameter(Game.GameId)
                        .SetParameter(Game.Player1Id)
                        .SetParameter("1")
                        .SetParameter("1")
                        .SetParameter("2")
                        .SetParameter("2")
                        .MakeRequest();
                    MoveMessage = Connection.Results;
                    break;
                default:
                    break;
            }
        }
    }
}
