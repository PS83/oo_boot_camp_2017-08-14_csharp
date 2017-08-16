/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using NUnit.Framework;
using OoBootCamp.Quantities.ExtensionMethods;
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
            Assert.AreEqual(Inch.S(126720), Mile.S(2));
            Assert.AreNotEqual(Inch.Es(1), Teaspoon.S(1));
            Assert.AreNotEqual(Foot.S(2), Cup.S(0.5));

            Assert.AreEqual(6.Tablespoons(), 3.Ounces());
            Assert.AreEqual(8.Tablespoons(), 0.5.Cups());
            Assert.AreEqual(0.5.Cups(), 8.Tablespoons());
            Assert.AreEqual(2.Gallons(), 1536.Teaspoons());
            Assert.AreNotEqual(6.Cups(), 6.Tablespoons());
            Assert.AreNotEqual(1.Inches(), 1.Teaspoons());
            Assert.AreNotEqual(2.Feet(), 0.5.Cups());
        }

        [Test]
        public void TemperatureEquality()
        {
            Assert.AreEqual(Celsius.Es(0), Fahrenheit.S(32));
            Assert.AreEqual(Fahrenheit.S(32), Celsius.Es(0));
            Assert.AreEqual(Celsius.Es(-40), Fahrenheit.S(-40));
            Assert.AreEqual(Fahrenheit.S(-40), Celsius.Es(-40));
            Assert.AreEqual(Celsius.Es(10), Fahrenheit.S(50));
            Assert.AreEqual(Fahrenheit.S(50), Celsius.Es(10));
            Assert.AreEqual(Celsius.Es(100), Fahrenheit.S(212));
            Assert.AreEqual(Fahrenheit.S(212), Celsius.Es(100));
        }


        [Test]
        public void Hash()
        {
            Assert.AreEqual(Tablespoon.S(8).GetHashCode(), Cup.S(0.5).GetHashCode());
            Assert.AreEqual(Yard.S(2).GetHashCode(), Inch.Es(72).GetHashCode());
        }

        [Test]
        public void Arithmetic()
        {
            Assert.AreEqual(Tablespoon.S(-3), -Tablespoon.S(3));
            Assert.AreEqual(-Cup.S(1.5), Cup.S(6.5) - Cup.S(8));
            Assert.AreEqual(-Tablespoon.S(24), Cup.S(6.5) - Gallon.S(0.5));
            Assert.AreEqual(-24.Tablespoons(), 6.5.Cups() - 0.5.Gallons());
            Assert.AreEqual(-Foot.S(6), Inch.Es(18) - Yard.S(2.5));
        }

        [Test]
        public void InvalidArithmetic()
        {
            Assert.That(() => Inch.Es(3) + Teaspoon.S(4), Throws.InvalidOperationException);
        }
    }
}