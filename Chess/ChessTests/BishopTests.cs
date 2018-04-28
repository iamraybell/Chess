using System;
using System.Collections.Generic;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
            var expectedPossibleMove = new List<int>() { 0, 0 };
            var expectedLength = 8;
           
            //act
            var moveSet = new List<List<int>>();
            moveSet.Add(new List<int> { -1, -1 });
            moveSet.Add(new List<int> { -1, 1 });
            moveSet.Add(new List<int> { 1, 1 });
            moveSet.Add(new List<int> { 1, -1 });



            var myBishop = new Piece(PieceType.Bishop, 2, 2, 5, 5, moveSet, true);
            var results = myBishop.GetPossibleMoves();
            //assert
            Assert.IsTrue( results.Any(x => x[0] == expectedPossibleMove[0] && x[1] == expectedPossibleMove[1]));
            Assert.AreEqual(expectedLength, results.Count);

        }
    }
}
