/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Rectangle works correctlyS
    [TestFixture]
    public class RectangleTest
    {
        [Test]
        public void Area()
        {
            Assert.AreEqual(24.0, new Rectangle(4.0, 6.0).Area());
        }

        [Test]
        public void Perimeter()
        {
            Assert.AreEqual(20.0, new Rectangle(4.0, 6.0).Perimeter());
        }
    }
}
