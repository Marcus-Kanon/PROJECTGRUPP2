using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessAPI.GamePieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCsharpModels.Models;


namespace ChessAPI.GamePieces.Tests
{
    [TestClass()]
    public   class MoveHelperTests
    {
 
            readonly GamesService gamesService = new();
            GameState? Mated1;
            GameState? CheckedNotMated;

            //GameState? Mated2;
            //GameState? Mated3;
            //GameState? Mated4;
            //GameState? NotMated2;
            //GameState? NotMated3;
            //GameState? NotMated4;
            GameState? Checked1;
            [TestInitialize]
            public void TestInitialize()
            {

            Mated1 = gamesService.CreateNewGame();
            Mated1.Board = new GamePiece[8, 8]
            {
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) },
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) },
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) },
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new Queen(Mated1, Color.Dark), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) },
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) },
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new King(Mated1, Color.Light), new Pawn(Mated1, Color.Light), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) },
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new Rook(Mated1, Color.Dark), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) },
                { new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty), new NoPiece(Mated1, Color.Empty) }
            };
            CheckedNotMated = gamesService.CreateNewGame();
                    CheckedNotMated.Board = new GamePiece[8, 8]
                {
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) },
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) },
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) },
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new Queen(CheckedNotMated, Color.Dark), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) },
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) },
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new King(CheckedNotMated, Color.Light), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) },
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) },
                { new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty), new NoPiece(CheckedNotMated, Color.Empty) }
                };



        }

        [TestMethod()]
        public void IsGuardedTest()
        {
            //Assert.IsTrue(MoveHelper.IsGuarded(MoveHelper.FindKing(Color.Light,Mated1),Mated1,Color.Dark));
            Assert.IsTrue(MoveHelper.IsGuarded((5,4), Mated1, Color.Dark));
        }

        [TestMethod()]
        public void FindKingTest()
        {
            Assert.AreEqual((5, 4), MoveHelper.FindKing(Color.Light, Mated1));
        }

        [TestMethod()]
        public void CheckCheckTest()
        {
            Assert.IsTrue(MoveHelper.CheckCheck(Color.Light, Mated1));
        }

        [TestMethod()]
        public void CrudeMateCheckTest()
        {
            Assert.IsTrue(MoveHelper.CrudeMateCheck(Color.Light, Mated1));
        }

        [TestMethod()]
            public void RealMateCheckTest()
            {

                Assert.IsTrue(MoveHelper.RealMateCheck(Color.Light, Mated1));
            }

            //[TestMethod()]
            //public void CopyCurrentBoardTest()
            //{
            //    Assert.Fail();
            //}

            //[TestMethod()]
            //public void RevertMoveTest()
            //{
            //    Assert.Fail();
            //}
        
    }
}