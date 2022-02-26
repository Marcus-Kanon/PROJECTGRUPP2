using ChessAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessAPI_Tests.GameServicesTests
{
    [TestClass()]
    class GameServicecTests
    {
        private GamesService _gamesService;
        [TestInitialize]
        public void SetUp()
        {
            _gamesService = new GamesService();
        }

        [TestMethod()]
        public void CreateNewGame_WhenCalled_ReturnNewGame()
        {

            var result = (_gamesService.CreateNewGame()).ToString();

            Assert.IsNotNull(result);

            Assert.AreEqual(result, "SharedCsharpModels.Models.GameState");

        }

        [TestMethod()]
        public void CreateBoard_AnacceptableValues_ReturnGamePiece()
        {
            var game = _gamesService.CreateNewGame();
            _gamesService.Games.Add(game);

            var Place = (_gamesService.CreateBoard(0, 0, game)).Length;
            Assert.AreEqual(Place, 64);

            var result = (_gamesService.CreateBoard(1, 1, game)).ToString();
            Assert.AreEqual(result, "SharedCsharpModels.Models.GamePiece[,]");


        }
    }
}
