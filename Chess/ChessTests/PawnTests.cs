using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System.Collections.Generic;

namespace ChessTests
{
    [TestClass]
    public class PawnTests
    {
        [TestMethod]
        public void TestPawnGenerateMove()
        {
            //arrange
            var expectedPossibleMove1 = new List<int> { 2, 1 };
            var expectedPossibleMove2 = new List<int> { 2, 3 };

            //act
            var moveSetList = new List<List<int>>();
            moveSetList.Add(new List<int>() { -1, -1 });
            moveSetList.Add(new List<int>() { -1, 1 });

            var myPawn = new Pawn(3,2,8,8,moveSetList);


            var results = myPawn.GetPossibleMoves();

            CollectionAssert.AreEqual(expectedPossibleMove1, results[0]);
            CollectionAssert.AreEqual(expectedPossibleMove2, results[1]);





        }
        [TestMethod]
        public void TestPawnRowColumns()
        {
            //arrange
            var expectedRow = 2;
            var expectedColumn = 2;

            //act


            var myPawn = new Pawn(2,2,8,8,new List<List<int>>());


           

            Assert.AreEqual(expectedRow, myPawn.Row);
            Assert.AreEqual(expectedColumn, myPawn.Row);






        }
        [TestMethod]
        public void TestPawnSetPosition()
        {
            //arrange
            var expectedRow = 4;
            var expectedColumn = 4;

            //act


            var myPawn = new Pawn(2, 2, 8, 8, new List<List<int>>());
            myPawn.SetPosition(4, 4);




            Assert.AreEqual(expectedRow, myPawn.Row);
            Assert.AreEqual(expectedColumn, myPawn.Row);






        }
    }
}
