using ChessAPI.Controllers;
using ChessAPI.Controllers.GetBord;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedCsharpModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAPI_Tests.Controllers
{
    [TestClass()]
    class GetBoardTests
    {
        private GetBoard _gameState;
        private Mock<IGetGameState> _mockGameState;
        [TestInitialize]
        public void SetUp()
        {
            _mockGameState = new Mock<IGetGameState>();

            _gameState = new GetBoard((GetGameState)_mockGameState.Object);
        }

        [TestMethod()]
        public void Get_EmptyGameIdAndPlayerId_ReturnEmptyJsonFile()
        {
            _mockGameState.Setup(x => x.GetGame("", "")).Returns(new GameState());

            var result = _gameState.Get("", "");

            Assert.IsInstanceOfType(result, typeof(GameState));
            //Assert.That(result, Is.EqualTo(@"{'Board' : 'null' , 'GameId' : 'null' , 'IsCheckedPlayerId' : 'null' , 'IsCheckmatedPlayerId' : 'null' , 'Player1' : 'null' , 'Player2' : 'null' , 'MovingPlayer' : 'null'}"));
            Assert.AreEqual(result, "{\"Board\":null,\"GameId\":null,\"IsCheckedPlayerId\":null,\"IsCheckmatedPlayerId\":null,\"Player1\":null,\"Player2\":null,\"MovingPlayer\":null}");

        }

        [TestMethod()]
        public void Get_GameIdAndPlayerId_ReturnJsonFile()
        {
            var ply = new Player() { Id = "3", Color = Color.Light };
            var game = new GameState { GameId = "1", Player1 = ply };


            _mockGameState.Setup(x => x.GetGame("1", "3")).Returns(game);

            var result = _gameState.Get("1", "3");

            Assert.IsInstanceOfType(result, typeof(string));
            Assert.AreEqual(result, "{\"Board\":null,\"GameId\":\"1\",\"IsCheckedPlayerId\":null,\"IsCheckmatedPlayerId\":null,\"Player1\":{\"Id\":\"3\",\"Color\":0,\"IsPlayerTurn\":false,\"IsCheckedPlayerId\":false," +
                "\"IsCheckmatedPlayerId\":false,\"IsLegalMove\":false},\"Player2\":null,\"MovingPlayer\":{\"Id\":\"3\",\"Color\":0,\"IsPlayerTurn\":false,\"IsCheckedPlayerId\":false,\"IsCheckmatedPlayerId\":false,\"IsLegalMove\":false}}");

        }
    }
}
