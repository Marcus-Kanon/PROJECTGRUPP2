using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        //Arrange
        public int X { get; set; }
        public int Y { get; set; }

        GamesService Service = new GamesService();
        GameState Gs;

        public BishopTests()
        {
            Gs = Service.CreateNewGame();

            EmptyBoard();

            Gs.Board[0, 0] = new Bishop(Gs, Color.Light);

            Gs.Board[4, 4] = new Pawn(Gs, Color.Dark);
            Gs.Board[6, 6] = new Pawn(Gs, Color.Light);
        }
        public void EmptyBoard()
        {
            Gs.Board = new GamePiece[8, 8]
            {
                { new NoPiece(Gs, Color.Empty),       new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),   new NoPiece(Gs, Color.Empty) },
                { new NoPiece(Gs, Color.Empty),      new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),    new NoPiece(Gs, Color.Empty) },
                { new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty),  new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),    new NoPiece(Gs, Color.Empty) },
                { new NoPiece(Gs, Color.Empty),        new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),  new NoPiece(Gs, Color.Empty) },
                { new NoPiece(Gs, Color.Empty),       new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),   new NoPiece(Gs, Color.Empty) },
                { new NoPiece(Gs, Color.Empty),      new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),    new NoPiece(Gs, Color.Empty) },
                { new NoPiece(Gs, Color.Empty),      new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),    new NoPiece(Gs, Color.Empty) },
                { new NoPiece(Gs, Color.Empty),        new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),     new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty), new NoPiece(Gs, Color.Empty),  new NoPiece(Gs, Color.Empty) },
            };
        }

        [TestMethod()]
        [DataRow(0, 0, MoveValidationMessage.IllegalMove)] //Invalid. Cannot move to same spot
        [DataRow(-1, -1, MoveValidationMessage.IllegalMove)] //Invalid. Outside board.
        [DataRow(1, 1, MoveValidationMessage.Succeeded)] //Succeeded
        [DataRow(1, 3, MoveValidationMessage.IllegalMove)] //Invalid. Bishop can only move diagonally.
        [DataRow(3, 3, MoveValidationMessage.Succeeded)] //Succeeded
        [DataRow(5, 5, MoveValidationMessage.IllegalMove)] //Invalid Blocked. Pawn is blocking the way.
        [DataRow(4, 4, MoveValidationMessage.Succeeded)] //Succeed. Pawn taken.
        [DataRow(6, 6, MoveValidationMessage.IllegalMove)] //Invalid. Spot taken by one of your pieces.
        [DataRow(7, 7, MoveValidationMessage.IllegalMove)] //Invalid. Cannot move passed your own piece.

        public void MoveTest(int moveX, int moveY, MoveValidationMessage expected)
        {
            //Arrange


            //Act
            var actual = Gs.Board[X, Y].Move((X, Y), (moveX, moveY));
            Assert.AreEqual(expected, actual);

            if (actual == MoveValidationMessage.Succeeded)
                X = moveX; Y = moveY;

            /*
            //From 0,0 to 7,7
            Assert.AreEqual(    MoveValidationMessage.IllegalMove,      Gs.Board[0, 0].Move((0, 0), (0, 0)) ); //Invalid. Cannot move to same spot
            Assert.AreEqual(    MoveValidationMessage.IllegalMove,      Gs.Board[0, 0].Move((0, 0), (-1, -1))); //Invalid. Outside board.
            Assert.AreEqual(    MoveValidationMessage.Succeeded,        Gs.Board[0, 0].Move((0, 0), (1, 1)) ); //Succeeded
            Assert.AreEqual(    MoveValidationMessage.Succeeded,        Gs.Board[1, 1].Move((1, 1), (3, 3)) ); //Succeeded
            Assert.AreEqual(    MoveValidationMessage.IllegalMove,      Gs.Board[3, 3].Move((3, 3), (5, 5)) ); //Invalid Blocked
            Assert.AreEqual(    MoveValidationMessage.Succeeded,        Gs.Board[3, 3].Move((3, 3), (4, 4)) ); //Succeed. Pawn taken.
            Assert.AreEqual(    MoveValidationMessage.IllegalMove,      Gs.Board[4, 4].Move((4, 4), (6, 6)) ); //Invalid. Spot taken by one of your pieces.
            Assert.AreEqual(    MoveValidationMessage.IllegalMove,      Gs.Board[4, 4].Move((4, 4), (7, 7)) ); //Invalid. Cannot move passed your own piece.
            Assert.AreEqual(    MoveValidationMessage.Succeeded,        Gs.Board[4, 4].Move((4, 4), (5, 5)) ); //Succeeded.
            */

        }
    }
}