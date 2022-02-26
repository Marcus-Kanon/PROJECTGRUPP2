using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCsharpModels.Models;
using System.Net;
using Newtonsoft.Json;

namespace ClientManual.Tests
{
    [TestClass()]
    public class StartUpTests
    {
        string connect = "";
        GameState game = null;

        [TestInitialize]
        public void TestInitialize()
        {
            connect = new WebClient().DownloadString("https://localhost:7223/api/creategame/create");
            game = JsonConvert.DeserializeObject<GameState>(connect);
        }

        [TestMethod()]
        public void RunTest_CreatingANewGame_ReturnsWhitePlayerAsPlayingTurn()
        {
            //Arrange
            StartUp.Run();

            //Act
            var actual = game.MovingPlayer.Color;

            var expected = game.Player1.Color;
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}