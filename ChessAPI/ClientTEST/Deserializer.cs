using ClientTEST.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTEST
{
    internal class Deserializer
    {
        public GameState GameState { get; set; } = new GameState();

        public Deserializer(string json)
        {
            GameState = JsonConvert.DeserializeObject<GameState>(json);
        }
    }
}
