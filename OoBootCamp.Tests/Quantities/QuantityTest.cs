/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;
using static OoBootCamp.Quantities.Unit;

namespace OoBootCamp.Tests.Quantities
{
    // Ensures Quantity operates correctly
    [TestFixture]
    public class QuantityTest
    {

        [Test]
        public void EqualityOfLikeUnits()
        {
            Assert.AreEqual(Tablespoon.S(6), Tablespoon.S(6));
            Assert.AreNotEqual(Tablespoon.S(6), Tablespoon.S(5));
            Assert.AreNotEqual(Tablespoon.S(6), new object());
            Assert.AreNotEqual(Tablespoon.S(6), null);
        }

        [Test]
        public void EqualityOfUnlikeUnits()
        {
            Assert.AreEqual(Tablespoon.S(6), Ounce.S(3));
            Assert.AreEqual(Tablespoon.S(8), Cup.S(0.5));
            Assert.AreEqual(Cup.S(0.5), Tablespoon.S(8));
            Assert.AreEqual(Gallon.S(2), Teaspoon.S(1536));
            Assert.AreNotEqual(Cup.S(6), Tablespoon.S(6));
        }
    }
}