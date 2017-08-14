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
        private static readonly Chance Impossible = new Chance(0.0);
        private static readonly Chance Unlikely = new Chance(0.25);
        private static readonly Chance EquallyLikely = new Chance(0.5);
        private static readonly Chance Likely = new Chance(0.75);
        private static readonly Chance Certain = new Chance(1.0);

        public void Equality()
        {
            Assert.AreEqual(new Chance(0.75), Likely);
            Assert.AreNotEqual(Likely, new object());
            Assert.AreNotEqual(Likely, null);
        }

        [Test]
        public void Hash()
        {
            Assert.AreEqual(new Chance(0.75).GetHashCode(), Likely.GetHashCode());
        }

        [Test]
        public void Not()
        {
            Assert.AreEqual(Unlikely, !Likely);
            Assert.AreEqual(Likely, !!Likely);
            Assert.AreEqual(Likely, Likely.Not().Not());
            Assert.AreEqual(Impossible, !Certain);
            Assert.AreEqual(Certain, !Impossible);
        }

        [Test]
        public void And()
        {
            Assert.AreEqual(Unlikely, EquallyLikely & EquallyLikely);
            Assert.AreEqual(new Chance(0.1875), Likely & Unlikely);
            Assert.AreEqual(Unlikely.And(Likely), Likely & Unlikely);
            Assert.AreEqual(Likely, Likely & Certain);
            Assert.AreEqual(Impossible, Impossible & Likely);
        }

    }
}