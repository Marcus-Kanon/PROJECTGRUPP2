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
    public class TS_CA_KN_001
    {
        readonly GamesService gamesService = new();
        GameState? customGame;
        GameState? customGame2;
        GameState? customGame3;
        [TestInitialize]
        public void TestInitialize()
        {
            customGame = gamesService.CreateNewGame();
            customGame2 = gamesService.CreateNewGame();
            customGame3 = gamesService.CreateNewGame();

            customGame.Board = new GamePiece[8, 8]
            {
                //   0                                       1                                               2                              3                                           4                                   5                                       6                                               7       
                { new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light),    new NoPiece(customGame, Color.Empty),   new Pawn(customGame, Color.Dark),       new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light),    new NoPiece(customGame, Color.Empty),   new Pawn(customGame, Color.Dark),       new Pawn(customGame, Color.Dark),       new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                 { new NoPiece(customGame, Color.Empty),    new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light),    new Pawn(customGame, Color.Light),      new  Knight(customGame, Color.Light),   new Pawn(customGame, Color.Dark),       new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light),      new Pawn(customGame, Color.Light),      new Pawn(customGame, Color.Light),      new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new Pawn(customGame, Color.Dark),       new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) }
            };
            customGame2.Board = new GamePiece[8, 8]
            {
                //{ new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                //{ new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                //{ new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new Pawn(customGame, Color.Light),      new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                //{ new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new Pawn(customGame, Color.Light),      new Pawn(customGame, Color.Light),      new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                // { new NoPiece(customGame, Color.Empty),    new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark),     new Pawn(customGame, Color.Dark),       new  Knight(customGame, Color.Dark),    new Pawn(customGame, Color.Light),      new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                //{ new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark),       new Pawn(customGame, Color.Dark),       new Pawn(customGame, Color.Dark),       new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                //{ new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new Pawn(customGame, Color.Light),      new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                //{ new NoPiece(customGame, Color.Empty),     new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty),   new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) }
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),   new NoPiece(customGame2, Color.Empty) },
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty) },
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty) },
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty), new Pawn(customGame2, Color.Light),  new NoPiece(customGame2, Color.Empty) },
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),     new Knight(customGame2, Color.Light), new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),   new NoPiece(customGame2, Color.Empty) },
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty) },
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new Pawn(customGame2, Color.Light),     new NoPiece(customGame2, Color.Empty), new Pawn(customGame2, Color.Dark), new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty) },
                { new NoPiece(customGame2, Color.Empty),    new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),     new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty), new NoPiece(customGame2, Color.Empty),  new NoPiece(customGame2, Color.Empty) },
                //       0                                       1                                               2                               3                                           4                                   5                                       6                                               7   
            };
            customGame3.Board = new GamePiece[8, 8]
            {
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),   new NoPiece(customGame3, Color.Empty) },
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty) },
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty) },
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),  new NoPiece(customGame3, Color.Empty) },
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new Knight(customGame3, Color.Light), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),   new NoPiece(customGame3, Color.Empty) },
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty) },
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty) },
                { new NoPiece(customGame3, Color.Empty),    new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),     new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty), new NoPiece(customGame3, Color.Empty),  new NoPiece(customGame3, Color.Empty) },
            };

            //customGame4.Board = new GamePiece[8, 8]

        }

        //        [TestMethod()]
        //        public void MoveTest_LightPlayerMovesDarkKnight_ReturnsWrongPieceColor()
        //        {
        //            var move = newGame?.Board?[0, 6].Move((0, 6), (0, 4));
        //            var actual = move;
        //            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        //        }

        //        [TestMethod()]
        //        public void MoveTest_DarkPlayerMovesLightKnight_ReturnsWrongPieceColor()
        //        {
        //            newGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
        //            newGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
        //            var move = newGame?.Board?[0, 1].Move((0, 1), (0, 3));
        //            var actual = move;
        //            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        //        }

        [TestMethod()]

        [DataRow(4, 4, 3, 6)]
        [DataRow(4, 4, 5, 2)]
        [DataRow(4, 4, 3, 2)]

        public void TC_CA_KN_MOVE_01(int oldCol, int oldRow, int newCol, int newRow)
        {
            var actual = customGame3?.Board?[4, 4].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        //[TestMethod()]
        //[DataRow(4, 4, 6, 3)]
        //[DataRow(4, 4, 5, 2)]
        //[DataRow(4, 4, 3, 2)]
        //[DataRow(4, 4, 2, 5)]
        //public void MoveTest_DarkKnightMovesOneSquareToTheSideAndTwoSquaresForwardOn_ReturnsSucceeded(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        //{
        //    customGame2.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
        //    customGame2.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
        //    var actual = customGame2?.Board?[4, 4].Move((oldCol, oldRow), (newCol, newRow));
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod()]
        [DataRow(4, 4, 4, 4, MoveValidationMessage.IllegalMove)]
        [DataRow(4, 4, 3, 7, MoveValidationMessage.IllegalMove)]
        [DataRow(4, 4, 4, 5, MoveValidationMessage.IllegalMove)]

        public void TC_CA_KN_MOVE_02(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            var actual = customGame3?.Board?[4, 4].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        //[TestMethod()]
        //[DataRow(4, 4, 4, 4, MoveValidationMessage.IllegalMove)]
        //[DataRow(4, 4, 3, 7, MoveValidationMessage.IllegalMove)]
        //[DataRow(4, 4, 4, 5, MoveValidationMessage.IllegalMove)]
        //public void MoveTest_BatmanMovesToSameSpotOrToSomeRandomAssPlaceHeIsNotSupposedTo_ReturnsIllegalMove_ReturnsIllegalMove(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        //{
        //    customGame2.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
        //    customGame2.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
        //    var actual = customGame2?.Board?[4, 4].Move((oldCol, oldRow), (newCol, newRow));
        //    Assert.AreEqual(expected, actual);
        //}

        [TestMethod()]
        public void TC_CA_KN_MOVE_03()
        {
            var move = customGame2?.Board?[4, 4].Move((4, 4), (5, 6));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        //[TestMethod()]
        //public void Diagnostice()
        //{
        //    var color = customGame2?.Board?[4, 4].Color;
        //    var color2 = customGame2?.Board?[3, 6].Color;

        //    Assert.AreEqual(color, color2);
        //}

        [TestMethod()]
        public void TC_CA_KN_MOVE_04()
        {
            var move = customGame2?.Board?[4, 4].Move((4, 4), (3, 6));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.IllegalMove, actual);
        }

        //[TestMethod()]
        //public void MoveTest_DarkKnightCapturesDarkPawn_ReturnsSucceeded()
        //{
        //    customGame2.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
        //    customGame2.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
        //    var move = customGame?.Board?[4, 4].Move((4, 4), (4, 4));
        //    var actual = move;
        //    Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        //}
    }
}