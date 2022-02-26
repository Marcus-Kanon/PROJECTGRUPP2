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
    public class KnightTests
    {
        readonly GamesService gamesService = new();
        GameState? newGame;
        GameState? Gs;


        public void EmptyBoard()
        {
            if (Gs != null)
            {
                if (Gs.Board != null)
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
            }


        }
        [TestInitialize]

        public void TestInitialize()
        {
            Gs = gamesService.CreateNewGame();
            EmptyBoard();
            Gs.Board[0, 1] = new Knight(Gs, Color.Light);   
            //return person?.Name ?? "Unknown";
        }

        [TestMethod()]
        public void MoveTest()
        {
            Assert.Fail();
        }

 
    }
}