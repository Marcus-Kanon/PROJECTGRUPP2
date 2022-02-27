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
    public class TS_CA_B_001
    {
        readonly GamesService gamesService = new();
        GameState? customGame;

        [TestInitialize]
        public void TestInitialize()
        {
            customGame = gamesService.CreateNewGame();
            customGame.Board = new GamePiece[8, 8]
            {
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Bishop(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Bishop(customGame, Color.Dark), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) }
            };
        }

        [TestMethod()]
        public void TC_CA_B_MOVE_01()
        {
            var move = customGame?.Board?[4, 4].Move((4, 4), (3, 3));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        }

        [TestMethod()]
        public void TC_CA_B_MOVE_02()
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = customGame?.Board?[2, 2].Move((2, 2), (3, 3));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        }

        [TestMethod()]
        [DataRow(2, 2, 1, 1)]
        [DataRow(2, 2, 3, 1)]
        [DataRow(2, 2, 3, 3)]
        [DataRow(2, 2, 1, 3)] 
        public void TC_CA_B_MOVE_03(int oldCol, int oldRow, int newCol, int newRow)
        {
            var actual = customGame?.Board?[2,2].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        [DataRow(4, 4, 3, 3)]
        [DataRow(4, 4, 5, 3)]
        [DataRow(4, 4, 5, 5)]
        [DataRow(4, 4, 3, 5)]
        public void TC_CA_B_MOVE_04(int oldCol, int oldRow, int newCol, int newRow)
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = customGame?.Board?[4, 4].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        [DataRow(2, 2, 2, 2)]
        [DataRow(2, 2, 5, 5)] 
        [DataRow(2, 2, 2, 3)]
        [DataRow(2, 2, 3, 2)]
        [DataRow(2, 2, 0, 4)]

        public void TC_CA_B_MOVE_05(int oldCol, int oldRow, int newCol, int newRow)
        {
            var actual = customGame?.Board?[2, 2].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.IllegalMove, actual);
        }

        [TestMethod()]
        [DataRow(4, 4, 4, 4)]
        [DataRow(4, 4, 1, 1)]
        [DataRow(4, 4, 4, 3)]
        [DataRow(4, 4, 4, 3)]
        [DataRow(4, 4, 6, 2)]
        [DataRow(4, 4, 7, 1)]
        public void TC_CA_B_MOVE_06(int oldCol, int oldRow, int newCol, int newRow)
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = customGame?.Board?[4, 4].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.IllegalMove, actual);
        }

        [TestMethod()]
        public void TC_CA_B_MOVE_07()
        {
            var move = customGame?.Board?[2, 2].Move((2, 2), (4, 4));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        public void TC_CA_B_MOVE_08()
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = customGame?.Board?[4, 4].Move((4, 4), (2, 2));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }
    }
}