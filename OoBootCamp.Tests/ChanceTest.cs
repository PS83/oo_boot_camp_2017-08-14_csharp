﻿/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;
using ExtensionMethods;

namespace OoBootCamp.Tests
{
    // Ensures Chance operates correctly
    [TestFixture]
    public class ChanceTest
    {
        private static readonly Chance Impossible = new Chance(0.0);
        private static readonly Chance Unlikely = 0.25.Chance();
        private static readonly Chance EquallyLikely = 0.5.Chance();
        private static readonly Chance Likely = 0.75.Chance();
        private static readonly Chance Certain = 1.Chance();

        [Test]
        public void Equality()
        {
            Assert.AreEqual(new Chance(0.75), Likely);
            Assert.AreEqual(0.75.Chance(), 0.75.Chance());
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

        [Test]
        public void Or()
        {
            Assert.AreEqual(Likely, EquallyLikely | EquallyLikely);
            Assert.AreEqual(new Chance(0.8125), Likely | Unlikely);
            Assert.AreEqual(Unlikely.Or(Likely), Likely | Unlikely);
            Assert.AreEqual(Certain, Likely | Certain);
            Assert.AreEqual(Likely, Impossible | Likely);
        }

        [Test]
        public void ValidFractions()
        {
            Assert.That(() => new Chance(1.1), Throws.ArgumentException);
            Assert.That(() => new Chance(-0.1), Throws.ArgumentException);
        }

    }
}