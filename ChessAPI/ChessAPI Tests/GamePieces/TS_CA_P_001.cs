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
    public class TS_CA_P_001
    {
        readonly GamesService gamesService = new();
        GameState newGame = null!;
        GameState customGame = null!;

        [TestInitialize]
        public void TestInitialize()
        {
            newGame = gamesService.CreateNewGame();
            customGame = gamesService.CreateNewGame();
            customGame.Board = new GamePiece[8, 8]
            {
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark), new Pawn(customGame, Color.Dark), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light), new Pawn(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) }
            };
        }

        [TestMethod()]
        public void TS_CA_P_MOVE_01()
        {
            var move = newGame?.Board?[0, 6].Move((0, 6), (0, 4));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        }

        [TestMethod()]
        public void TS_CA_P_MOVE_02()
        {
            newGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            newGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = newGame?.Board?[0, 1].Move((0, 1), (0, 3));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.WrongPieceColor, actual);
        }

        [TestMethod()]
        [DataRow(0, 1, 0, 2)]
        [DataRow(0, 1, 0, 3)]
        public void TS_CA_P_MOVE_03(int oldCol, int oldRow, int newCol, int newRow)
        {
            var actual = newGame?.Board?[0,1].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        [DataRow(0, 6, 0, 5, MoveValidationMessage.Succeeded)]
        [DataRow(0, 6, 0, 4, MoveValidationMessage.Succeeded)]
        public void TS_CA_P_MOVE_04(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            newGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            newGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = newGame?.Board?[0, 6].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(5, 3, 5, 3, MoveValidationMessage.IllegalMove)]
        [DataRow(5, 3, 5, 2, MoveValidationMessage.IllegalMove)]
        [DataRow(4, 3, 3, 3, MoveValidationMessage.IllegalMove)]
        [DataRow(4, 2, 3, 3, MoveValidationMessage.IllegalMove)]
        [DataRow(4, 2, 4, 3, MoveValidationMessage.IllegalMove)]
        public void TS_CA_P_MOVE_05(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            var actual = customGame?.Board?[0, 1].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(2, 4, 2, 4, MoveValidationMessage.IllegalMove)]
        [DataRow(2, 4, 2, 5, MoveValidationMessage.IllegalMove)]
        [DataRow(3, 4, 4, 4, MoveValidationMessage.IllegalMove)]
        [DataRow(2, 4, 3, 3, MoveValidationMessage.IllegalMove)]
        [DataRow(3, 5, 3, 4, MoveValidationMessage.IllegalMove)]
        public void TS_CA_P_MOVE_06(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = customGame?.Board?[3, 3].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void TS_CA_P_MOVE_07()
        {
            var move = customGame?.Board?[4, 3].Move((4, 3), (3, 4));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }

        [TestMethod()]
        public void TS_CA_P_MOVE_08()
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = customGame?.Board?[3, 4].Move((3, 4), (4, 3));
            var actual = move;
            Assert.AreEqual(MoveValidationMessage.Succeeded, actual);
        }
    }
}