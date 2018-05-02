using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;

namespace ChessTests
{
    [TestClass]
    public class TopSetupProviderTest
    {
        [TestMethod]
        public void TestPawnPositionSetup()
        {
            var myOwner = new HumanPlayer("ray", ColorType.Black);
            var myBoard = new Board();
            TopPlayerPieceRulesProvider.PawnPositionSetup(myBoard, myOwner);
            for (var idx = 0; idx < myBoard.NumColumns; idx++)
            {
                Assert.AreEqual(PieceType.Pawn, myBoard.contents[1, idx].PieceType);
            }

        }
        [TestMethod]
        public void TestBishopPositionSetup()
        {
            var myOwner = new HumanPlayer("ray", ColorType.Black);
            var myBoard = new Board();

            TopPlayerPieceRulesProvider.BishopPositionSetup(myBoard, myOwner);


            Assert.AreEqual(PieceType.Bishop, myBoard.contents[0, 2].PieceType);
            Assert.AreEqual(PieceType.Bishop, myBoard.contents[0, myBoard.NumColumns - 3].PieceType);


        }
        [TestMethod]
        public void TestKnightPositionSetup()
        {
            var myOwner = new HumanPlayer("ray", ColorType.Black);
            var myBoard = new Board();

            TopPlayerPieceRulesProvider.KnightPositionSetup(myBoard, myOwner);


            Assert.AreEqual(PieceType.Knight, myBoard.contents[0, 1].PieceType);
            Assert.AreEqual(PieceType.Knight, myBoard.contents[0, myBoard.NumColumns - 2].PieceType);


        }
        [TestMethod]
        public void TestRookPositionSetup()
        {
            var myOwner = new HumanPlayer("ray", ColorType.Black);
            var myBoard = new Board();

            TopPlayerPieceRulesProvider.RookPositionSetup(myBoard, myOwner);


            Assert.AreEqual(PieceType.Rook, myBoard.contents[0, 0].PieceType);
            Assert.AreEqual(PieceType.Rook, myBoard.contents[0, myBoard.NumColumns - 1].PieceType);


        }
        [TestMethod]
        public void TestKingPositionSetup()
        {
            var myOwner = new HumanPlayer("ray", ColorType.Black);
            var myBoard = new Board();

            TopPlayerPieceRulesProvider.KingPositionSetup(myBoard, myOwner);


            Assert.AreEqual(PieceType.King, myBoard.contents[0, 4].PieceType);



        }
        [TestMethod]
        public void TestQueenPositionSetup()
        {
            var myOwner = new HumanPlayer("ray", ColorType.Black);
            var myBoard = new Board();

            TopPlayerPieceRulesProvider.QueenPositionSetup(myBoard, myOwner);
            Assert.AreEqual(PieceType.Queen, myBoard.contents[0, 3].PieceType);
        }



    }
}
