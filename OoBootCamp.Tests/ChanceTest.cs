/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Chance operates correctly
    [TestFixture]
    public class ChanceTest
    {
        public void Equality()
        {
            Assert.AreEqual(new Chance(0.75), new Chance(0.75));
            Assert.AreNotEqual(new Chance(0.75), new object());
            Assert.AreNotEqual(new Chance(0.75), null);
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(new Chance(0.75).GetHashCode(), new Chance(0.75).GetHashCode());
        }
    }
}