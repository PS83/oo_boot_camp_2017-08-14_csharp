/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    // Understands a specific metric
    public class Unit
    {
        public static readonly Unit Teaspoon = new Unit();
        public static readonly Unit Tablespoon = new Unit(3, Teaspoon);
        public static readonly Unit Ounce = new Unit(2, Tablespoon);
        public static readonly Unit Cup = new Unit(8, Ounce);
        public static readonly Unit Pint = new Unit(2, Cup);
        public static readonly Unit Quart = new Unit(2, Pint);
        public static readonly Unit Gallon = new Unit(4, Quart);

        private static readonly int DecimalPlaceCount = 6;
        private readonly double _baseUnitRatio;

        public Unit()
        {
            _baseUnitRatio = 1;
        }

        public Unit(double relativeRatio, Unit relativeUnit)
        {
            _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
        }

        public Quantity S(double amount)
        {
            return new Quantity(amount, this);
        }

        internal double ConvertedAmount(double otherAmount, Unit other)
        {
            return otherAmount * other._baseUnitRatio / this._baseUnitRatio;
        }

        internal int HashCode(double amount)
        {
            return Math.Round(amount * _baseUnitRatio, DecimalPlaceCount).GetHashCode();
        }
    }
}