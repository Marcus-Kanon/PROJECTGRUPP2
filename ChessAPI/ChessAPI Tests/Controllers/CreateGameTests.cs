using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCsharpModels.Models;

namespace ChessAPI.Controllers.Tests
{
    [TestClass()]
    public class CreateGameTests
    {
        readonly GamesService gamesService = new();
        GameState? gameState;

        [TestInitialize]
        public void TestInitialize()
        {
            gameState = gamesService.CreateNewGame();
        }

        [TestMethod()]
        public void CreateTest_CreatingANewGame_ReturnsWhitePlayerAsPlayingTurn()
        {
            var actual = gameState?.MovingPlayer?.Color;

            Assert.AreEqual(gameState?.Player1.Color, actual);
        }
    }
}