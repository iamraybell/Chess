using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System.Collections.Generic;

namespace ChessTests
{
    [TestClass]
    public class PieceTests
    {
     [TestMethod]
     public void TestPieceConstructor()
        {
            var myPawn = new Piece(PieceType.Pawn,new List<MoveSet>(), true);

            Assert.AreEqual(PieceType.Pawn, myPawn.PieceType);
        }
    }
}
