﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class RookTests
    {
        readonly GamesService gamesService = new();
        GameState? customGame;

        [TestInitialize]
        public void TestInitialize()
        {           
            customGame = gamesService.CreateNewGame();
            customGame.Board = new GamePiece[8, 8]
            {
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new Rook(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Dark), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new Pawn(customGame, Color.Light), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new Rook(customGame, Color.Dark), new NoPiece(customGame, Color.Empty) },
                { new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty), new NoPiece(customGame, Color.Empty) }
            };
        }

        [TestMethod()]
        public void MoveTest_LightPlayerMovesDarkRook_ReturnsWrongPieceColor()
        {
            var move = customGame?.Board?[6, 6].Move((6, 6), (6, 5));
            var actual = move;
            var expected = MoveValidationMessage.WrongPieceColor;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MoveTest_DarkPlayerMovesLightRook_ReturnsWrongPieceColor()
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = customGame?.Board?[1, 1].Move((1, 1), (3, 3));
            var actual = move;
            var expected = MoveValidationMessage.WrongPieceColor;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1, 1, 0, 1, MoveValidationMessage.Succeeded)]
        [DataRow(1, 1, 1, 0, MoveValidationMessage.Succeeded)]
        [DataRow(1, 1, 2, 1, MoveValidationMessage.Succeeded)]
        [DataRow(1, 1, 1, 2, MoveValidationMessage.Succeeded)]
        public void MoveTest_LightRookMovesOneSquareVerticallyOrHorizontally_ReturnsSucceeded(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            var actual = customGame?.Board?[1,1].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(6, 6, 6, 5, MoveValidationMessage.Succeeded)]
        [DataRow(6, 6, 7, 6, MoveValidationMessage.Succeeded)]
        [DataRow(6, 6, 6, 7, MoveValidationMessage.Succeeded)]
        [DataRow(6, 6, 5, 6, MoveValidationMessage.Succeeded)]
        public void MoveTest_DarkRookMovesOneSquareVerticallyOrHorizontally_ReturnsSucceeded(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = customGame?.Board?[6, 6].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(1, 1, 1, 1, MoveValidationMessage.IllegalMove)]
        [DataRow(1, 1, 2, 2, MoveValidationMessage.IllegalMove)]
        [DataRow(1, 1, 1, 7, MoveValidationMessage.IllegalMove)]
        [DataRow(1, 1, 6, 1, MoveValidationMessage.IllegalMove)]
        public void MoveTest_LightRookMovesWhenMoveToSameSpotOrPathBlockedOrToOwnColorPieceOrDiagonally_ReturnsIllegalMove(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            var actual = customGame?.Board?[1, 1].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(6, 6, 6, 6, MoveValidationMessage.IllegalMove)]
        [DataRow(6, 6, 0, 6, MoveValidationMessage.IllegalMove)]
        [DataRow(6, 6, 5, 5, MoveValidationMessage.IllegalMove)]
        [DataRow(6, 6, 1, 6, MoveValidationMessage.IllegalMove)]
        public void MoveTest_DarkRookMovesWhenMoveToSameSpotOrPathBlockedOrToOwnColorPieceOrDiagonally_ReturnsIllegalMove(int oldCol, int oldRow, int newCol, int newRow, MoveValidationMessage expected)
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var actual = customGame?.Board?[6, 6].Move((oldCol, oldRow), (newCol, newRow));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MoveTest_LightRookMovesToDarkPawn_ReturnsSucceeded()
        {
            var move = customGame?.Board?[1, 1].Move((1, 1), (1, 6));
            var actual = move;
            var expected = MoveValidationMessage.Succeeded;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MoveTest_DarkRookMovesToLightPawn_ReturnsSucceeded()
        {
            customGame.Player1 = new() { Color = Color.Light, IsPlayerTurn = false };
            customGame.Player2 = new() { Color = Color.Dark, IsPlayerTurn = true };
            var move = customGame?.Board?[6, 6].Move((6, 6), (6, 1));
            var actual = move;
            var expected = MoveValidationMessage.Succeeded;
            Assert.AreEqual(expected, actual);
        }
    }
}