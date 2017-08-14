/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */
 
using NUnit.Framework;

namespace OoBootCamp.Tests
{
    // Ensures Rectangle works correctly
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

        [Test]
        public void InvalidRectangles()
        {
            Assert.That(() => new Rectangle(0, 1), Throws.ArgumentException);
            Assert.That(() => new Rectangle(1, 0), Throws.ArgumentException);
        }
    }
}
