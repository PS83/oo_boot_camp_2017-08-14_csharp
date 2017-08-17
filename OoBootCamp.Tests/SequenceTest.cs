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
            var rectangles = new List<Rectangle>() {
                new Rectangle(2, 3),
                new Rectangle(3, 4),
                new Rectangle(3, 3)
            };
            Assert.AreEqual(12.0, Sequence.Best(rectangles).Area());
        }

    }
}