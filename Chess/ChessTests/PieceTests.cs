using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System.Collections.Generic;
using Moq;

namespace ChessTests
{
    [TestClass]
    public class PieceTests
    {
     [TestMethod]
     public void TestPieceConstructor()
        {
            var MockPlayer = new Mock<IPlayer>(MockBehavior.Strict);
            var myPawn = new Piece(PieceType.Pawn,new List<MoveSet>(), true, new Position(2, 3), MockPlayer.Object);

            Assert.AreEqual(PieceType.Pawn, myPawn.PieceType);
        }
    }
}
