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
    public class TS_CA_Q_001
    {
        readonly GamesService gamesService = new();
        GameState customGame = new();

        [TestInitialize]
        public void TestInitialize()
        {
            customGame = gamesService.CreateNewGame();
            customGame.Board = new GamePiece[8, 8]
            {
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new Queen(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Queen(customGame, Color.Dark), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) }
            };
        }

        [TestMethod()]
        public void TC_CA_Q_MOVE_01()
        {
            var move = customGame?.Board?[6, 6].Move((6, 6), (6, 5));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        }

        [TestMethod()]
        public void TC_CA_Q_MOVE_02()
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = customGame?.Board?[1, 1].Move((1, 1), (3, 3));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        }

        [TestMethod()]
        [DataRow(1, 1, 0, 0)]
        [DataRow(1, 1, 1, 0)]
        [DataRow(1, 1, 2, 0)]
        [DataRow(1, 1, 1, 2)]
        [DataRow(1, 1, 2, 2)]
        [DataRow(1, 1, 1, 2)]
        [DataRow(1, 1, 0, 2)]
        [DataRow(1, 1, 0, 1)]
        public void TC_CA_Q_MOVE_03(int oldCol, int oldRow, int newCol, int newRow)
        {
            var actual = customGame?.Board?[1,1].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        [DataRow(6, 6, 5, 5)]
        [DataRow(6, 6, 6, 5)]
        [DataRow(6, 6, 7, 5)]
        [DataRow(6, 6, 7, 6)]
        [DataRow(6, 6, 7, 7)]
        [DataRow(6, 6, 6, 7)]
        [DataRow(6, 6, 5, 7)]
        [DataRow(6, 6, 5, 6)]
        public void TC_CA_Q_MOVE_04(int oldCol, int oldRow, int newCol, int newRow)
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = customGame?.Board?[6, 6].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        [DataRow(1, 1, 1, 1)]
        [DataRow(1, 1, 7, 7)]
        [DataRow(1, 1, 1, 7)]
        [DataRow(1, 1, 7, 1)]
        [DataRow(1, 1, 6, 1)]
        public void TC_CA_Q_MOVE_05(int oldCol, int oldRow, int newCol, int newRow)
        {
            var actual = customGame?.Board?[1, 1].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.IllegalMove, actual);
        }

        [TestMethod()]
        [DataRow(6, 6, 6, 6)]
        [DataRow(6, 6, 0, 0)]
        [DataRow(6, 6, 0, 6)]
        [DataRow(6, 6, 6, 0)]
        [DataRow(6, 6, 1, 6)]
        public void TC_CA_Q_MOVE_06(int oldCol, int oldRow, int newCol, int newRow)
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = customGame?.Board?[6, 6].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.IllegalMove, actual);
        }

        [TestMethod()]
        public void TC_CA_Q_MOVE_07()
        {
            var move = customGame?.Board?[1, 1].Move((1, 1), (1, 6));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        public void TC_CA_Q_MOVE_08()
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = customGame?.Board?[6, 6].Move((6, 6), (6, 1));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }
    }
}