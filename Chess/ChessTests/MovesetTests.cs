using System;
using Chess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ChessTests
{
    [TestClass]
    public class MovesetTests
    {
        [TestMethod]
        public void TestMoveSetConstructor()
        {
            var expectedRowModifier = -1;
            var expectedColumnModifier = 0;

            var myMoveset = new MoveSet( -1,0, null);
            Assert.AreEqual(expectedRowModifier, myMoveset.RowModifier);
            Assert.AreEqual(expectedColumnModifier, myMoveset.ColumnModifier);
        }
        [TestMethod]
        public void TestMoveSetValidatorReturnsTrue()
        {
            var expectedOutcome = true;
            var MockBoard = new Mock<IBoard>(MockBehavior.Strict);
            var MockPiece = new Mock<IPiece>(MockBehavior.Strict);
            MockBoard.Setup(x => x.NumRows).Returns(4);
            var myMoveset = new MoveSet( -1,0, (IBoard board, IPiece piece)=> { return board.NumRows > 2; });

            var results = myMoveset.RunValidator(MockBoard.Object, MockPiece.Object);

            Assert.AreEqual(expectedOutcome, results);

        }
        [TestMethod]
        public void TestMoveSetValidatorReturnsFalse()
        {
            var expectedOutcome = false;
            var MockBoard = new Mock<IBoard>(MockBehavior.Strict);
            var MockPiece = new Mock<IPiece>(MockBehavior.Strict);
            MockBoard.Setup(x => x.NumRows).Returns(4);
            var myMoveset = new MoveSet(-1, 0, (IBoard board, IPiece piece) => { return board.NumRows > 5; });

            var results = myMoveset.RunValidator(MockBoard.Object, MockPiece.Object);

            Assert.AreEqual(expectedOutcome, results);

        }
        [TestMethod]
        public void TestMoveSetValidatorReturnsFalseWhenNull()
        {
            var expectedOutcome = true;
            var MockBoard = new Mock<IBoard>(MockBehavior.Strict);
            var MockPiece = new Mock<IPiece>(MockBehavior.Strict);
            MockBoard.Setup(x => x.NumRows).Returns(4);
            var myMoveset = new MoveSet(-1, 0, null);

            var results = myMoveset.RunValidator(MockBoard.Object, MockPiece.Object);

            Assert.AreEqual(expectedOutcome, results);

        }
    }
}
