using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChessAPI.GamePieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedCsharpModels.Models;
using Newtonsoft.Json;

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
                { new Rook(actual, Color.Light),   new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),   new Rook(actual, Color.Dark) },
                { new Knight(actual, Color.Light), new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),     new Knight(actual, Color.Dark) },
                { new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Light),     new Bishop(actual, Color.Light), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Bishop(actual, Color.Dark) },
                { new King(actual, Color.Light),   new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Queen(actual, Color.Dark) },
                { new Queen(actual, Color.Light),  new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new King(actual, Color.Dark) },
                { new Bishop(actual, Color.Light), new Pawn(actual, Color.Light),      new NoPiece(actual, Color.Empty),new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Bishop(actual, Color.Dark) },
                { new Knight(actual, Color.Light), new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),    new Knight(actual, Color.Dark) },
                { new Rook(actual, Color.Light),   new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),  new Rook(actual, Color.Dark) },
            };


            //Act
            //actual.Board[2, 2].Move((2, 2), (5, 5));

            //var json = JsonConvert.SerializeObject(actual, Formatting.Indented);
            //var expected = JsonConvert.DeserializeObject<GameState>(json);
            var expected = service.CreateNewGame();

            expected.Board = new GamePiece[8, 8]
            {
                { new Rook(actual, Color.Light),   new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),   new Rook(actual, Color.Dark) },
                { new Knight(actual, Color.Light), new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),     new Knight(actual, Color.Dark) },
                { new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Light),     new Bishop(actual, Color.Light), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Bishop(actual, Color.Dark) },
                { new King(actual, Color.Light),   new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Queen(actual, Color.Dark) },
                { new Queen(actual, Color.Light),  new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new King(actual, Color.Dark) },
                { new Bishop(actual, Color.Light), new Pawn(actual, Color.Light),      new NoPiece(actual, Color.Empty),new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark), new Bishop(actual, Color.Dark) },
                { new Knight(actual, Color.Light), new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),    new Knight(actual, Color.Dark) },
                { new Rook(actual, Color.Light),   new Pawn(actual, Color.Light),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty),     new NoPiece(actual, Color.Empty), new NoPiece(actual, Color.Empty), new Pawn(actual, Color.Dark),  new Rook(actual, Color.Dark) },
            };

            //AsseCollectionAssertrt
            
            
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Assert.IsTrue(expected.Board[x, y].Equals(actual.Board[x, y]));
                }
            }
            
            
            //CollectionAssert.AreEqual(expected.Board, actual.Board);
            
        }
    }
}