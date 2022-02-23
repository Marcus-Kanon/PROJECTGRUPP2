﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessAPI.GamePieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCsharpModels.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ChessAPI.GamePieces.Tests
{
    [TestClass()]
    public class BishopTests
    {
        
        [TestMethod()]
        public void MoveTest()
        {

            //Arrange
            var service = new GamesService();

            var actual = service.CreateNewGame();

            actual.Board = new GamePiece[8, 8]
            {
                { new Rook(actual, Color.Light),        new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),   new Rook(actual, Color.Dark) },
                { new Knight(actual, Color.Light),      new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),     new Knight(actual, Color.Dark) },
                { new NoPiece(actual, Color.Empty),     new Pawn(actual, Color.Light),     new Bishop(actual, Color.Light),  new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Bishop(actual, Color.Dark) },
                { new King(actual, Color.Light),        new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Queen(actual, Color.Dark) },
                { new Queen(actual, Color.Light),       new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new King(actual, Color.Dark) },
                { new Bishop(actual, Color.Light),      new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Bishop(actual, Color.Dark) },
                { new Knight(actual, Color.Light),      new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),    new Knight(actual, Color.Dark) },
                { new Rook(actual, Color.Light),        new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),  new Rook(actual, Color.Dark) },
            };


            //Act
            actual.Board[2, 2].Move((2, 2), (1, 3));

            var expected = service.CreateNewGame();

            expected.Board = new GamePiece[8, 8]
            {
                { new Rook(expected, Color.Light),      new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty),     new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new Rook(expected, Color.Dark) },
                { new Knight(expected, Color.Light),    new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new Bishop(expected, Color.Light),      new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new Knight(expected, Color.Dark) },
                { new NoPiece(expected, Color.Empty),   new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty),     new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new Bishop(expected, Color.Dark) },
                { new King(expected, Color.Light),      new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty),     new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new Queen(expected, Color.Dark) },
                { new Queen(expected, Color.Light),     new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty),     new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new King(expected, Color.Dark) },
                { new Bishop(expected, Color.Light),    new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty),     new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new Bishop(expected, Color.Dark) },
                { new Knight(expected, Color.Light),    new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty),     new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new Knight(expected, Color.Dark) },
                { new Rook(expected, Color.Light),      new Pawn(expected, Color.Light),    new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty),     new NoPiece(expected, Color.Empty), new NoPiece(expected, Color.Empty), new Pawn(expected, Color.Dark), new Rook(expected, Color.Dark) },
            };

            var expectedJson = JsonConvert.SerializeObject(expected.Board, Formatting.Indented);
            var actualJson = JsonConvert.SerializeObject(actual.Board, Formatting.Indented);

            Assert.IsTrue(expectedJson==actualJson);

        }
    }
}