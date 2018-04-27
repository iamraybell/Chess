using System;
using System.Collections.Generic;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTests
{
    [TestClass]
    public class BishopTests
    {
        [TestMethod]
        public void TestBishopSetPosition()
        {   //arrange
            var expectedRow = 1;
            var expectedColumn = 1;
            //act
            var myBishop = new Piece(PieceType.Bishop, 1, 1, 3, 3, new List<List<int>>(), true);
            //assert
            Assert.AreEqual(expectedRow, myBishop.Row);
            Assert.AreEqual(expectedColumn, myBishop.Column);

        }
        [TestMethod]
        public void TestBishopPossibleMoves()
        {   //arrange
            var expectedRow = 1;
            var expectedColumn = 1;
            //act
            var myBishop = new Piece(PieceType.Bishop, 1, 1, 3, 3, new List<List<int>>(), true);
            //assert
            Assert.AreEqual(expectedRow, myBishop.Row);
            Assert.AreEqual(expectedColumn, myBishop.Column);
            CollectionAssert.

        }
    }
}
