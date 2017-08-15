/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OoBootCamp.Quantities;
using static OoBootCamp.Quantities.Quantity;

namespace OoBootCamp.Tests.Quantities
{
    // Ensures Quantity operates correctly
    [TestFixture]
    public class QuantityTest
    {
        [Test]
        public void EqualityOfLikeUnits()
        {
            Assert.AreEqual(new Quantity(4, Tablespoon), new Quantity(4, Tablespoon));
            Assert.AreNotEqual(new Quantity(4, Tablespoon), new Quantity(6, Tablespoon));
        }

        [Test]
        public void EqualityOfDifferentUnits()
        {
            Assert.AreNotEqual(new Quantity(4, Tablespoon), new Quantity(4, Teaspoon));
        }
    }
}