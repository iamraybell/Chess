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
            var expectedColor = ColorType.Black;

            var myOwner = new HumanPlayer("Ray", ColorType.Black);


            Assert.AreEqual(expectedColor, myOwner.Color);
            Assert.AreEqual(expectedString, myOwner.Name);
        }
    }
}
