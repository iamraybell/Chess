using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;

namespace ChessTests
{
    [TestClass]
    public class OwnerTests
    {
        [TestMethod]
        public void TestOwnerTest()
        {
            var expectedString ="Ray";
            var expectedColor = PlayerKind.Black;

            var myOwner = new HumanPlayer("Ray", PlayerKind.Black);


            Assert.AreEqual(expectedColor, myOwner.PlayerKind);
            Assert.AreEqual(expectedString, myOwner.Name);
        }
    }
}
