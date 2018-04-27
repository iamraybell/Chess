using System;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChessTests
{
    [TestClass]
    public class MoveSetTest
    {
        [TestMethod]
        public void TestMoveWorks()
        {
            var yExpected = 1;
            var xExpected = 3;


            var myMoveSet = MoveSet.Set(1, 3);



            Assert.AreEqual(yExpected, 1);
            Assert.AreEqual(xExpected, 1);
            
        }
    }
}
