/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;
using NUnit.Framework;
using OoBootCamp.Quantities;
using static OoBootCamp.Quantities.Unit;

namespace OoBootCamp.Tests
{
    // Ensures Sequence and corresponding interface Sequenceable operate correctly
    [TestFixture]
    public class SequenceTest
    {

        [Test]
        public void RectangleArea()
        {
            var rectangles = new List<Rectangle>
            {
                new Rectangle(2, 3),
                new Rectangle(3, 4),
                new Rectangle(3, 3)
            };
            Assert.AreEqual(12.0, rectangles.Best().Area());
            Assert.AreEqual(12.0, rectangles.ToArray().Best().Area());
        }

        [Test]
        public void Chance()
        {
            Chance[] chances =
            {
                new Chance(0.50), new Chance(0.25), new Chance(0.75), new Chance(0.1)
            };
            Assert.AreEqual(new Chance(0.75), Sequence.Best(chances));
        }

        [Test]
        public void Quantity()
        {
            var quantities = new List<IntervalQuantity>
            {
                Teaspoon.S(10), Quart.S(1), Tablespoon.S(6), Ounce.S(13)
            };
            Assert.AreEqual(Pint.S(2), Sequence.Best(quantities));
        }

    }
}