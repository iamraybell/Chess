using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System.Linq;

namespace ChessTests
{
    [TestClass]
    public class GameAppTests
    {
        [TestMethod]
        public void GenerateMovesKnight_Row0_Column1Returns2()
        {
            var expectedPostion1 = new Position(2, 0);
            var expectedPostion2 = new Position(2, 2);
            var expectedCount = 2;
            MainGameApp myGameApp = new MainGameApp(new Board(), new TopPlayerSetupProvider(), new HumanPlayer("ray", ColorType.Black));
            myGameApp.GenerateMoves(new Position(0, 1));


            var results = myGameApp.possibleMoves.Where(
                x => x.Row == expectedPostion1.Row && x.Column == expectedPostion1.Column ||
                x.Row == expectedPostion2.Row && x.Column == expectedPostion2.Column
                ).ToList();
            Assert.AreEqual(expectedCount, results.Count);
            Assert.AreEqual(expectedCount, myGameApp.possibleMoves.Count);

        }
        [TestMethod]
        public void GenerateMovesBishop_Row0_Column2Returns0()
        {

            var expectedCount = 0;
            MainGameApp myGameApp = new MainGameApp(new Board(), new TopPlayerSetupProvider(), new HumanPlayer("ray", ColorType.Black));
            myGameApp.GenerateMoves(new Position(0, 2));

            var results = myGameApp.possibleMoves.Count;
            Assert.AreEqual(expectedCount, results);

        }
    }
}
