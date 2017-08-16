﻿/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using static OoBootCamp.Quantities.Unit;

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

        public static readonly Unit Inch = new Unit();
        public static readonly Unit Foot = new Unit(12, Inch);
        public static readonly Unit Yard = new Unit(3, Foot);
        public static readonly Unit Furlong = new Unit(220, Yard);
        public static readonly Unit Mile = new Unit(8, Furlong);

        public static readonly Unit Celsius = new Unit();
        public static readonly Unit Fahrenheit = new Unit(5/9.0, 32, Celsius);

        private static readonly int DecimalPlaceCount = 6;
        private readonly double _baseUnitRatio;
        private readonly double _offset;
        private readonly Unit _baseUnit;

        public Unit()
        {
            _baseUnit = this;
            _baseUnitRatio = 1;
            _offset = 0;
        }

        public Unit(double relativeRatio, Unit relativeUnit): this(relativeRatio, 0, relativeUnit)
        {
        }

        public Unit(double relativeRatio, double offset, Unit relativeUnit)
        {
            _baseUnit = relativeUnit._baseUnit;
            _offset = offset;
            _baseUnitRatio = relativeRatio * relativeUnit._baseUnitRatio;
        }

        public Quantity S(double amount) => new Quantity(amount, this);

        public Quantity Es(double amount) => this.S(amount);

        internal double ConvertedAmount(double otherAmount, Unit other)
        {
            if (!this.IsCompatible(other)) throw new InvalidOperationException("Mixed Unit arithmetic");
            return (otherAmount - other._offset) * other._baseUnitRatio / this._baseUnitRatio + this._offset;
        }

        internal int HashCode(double amount)
        {
            return Math.Round(amount * _baseUnitRatio, DecimalPlaceCount).GetHashCode();
        }

        public bool IsCompatible(Unit otherUnit) => this._baseUnit == otherUnit._baseUnit;
    }

    namespace ExtensionMethods
    {
        public static class QuantityConstructors
        {
            public static Quantity Teaspoons(this double amount) => Teaspoon.S(amount);
            public static Quantity Teaspoons(this int amount) => Teaspoon.S(amount);
            public static Quantity Tablespoons(this double amount) => Tablespoon.S(amount);
            public static Quantity Tablespoons(this int amount) => Tablespoon.S(amount);
            public static Quantity Ounces(this double amount) => Ounce.S(amount);
            public static Quantity Ounces(this int amount) => Ounce.S(amount);
            public static Quantity Cups(this double amount) => Cup.S(amount);
            public static Quantity Cups(this int amount) => Cup.S(amount);
            public static Quantity Pints(this double amount) => Pint.S(amount);
            public static Quantity Pints(this int amount) => Pint.S(amount);
            public static Quantity Quarts(this double amount) => Quart.S(amount);
            public static Quantity Quarts(this int amount) => Quart.S(amount);
            public static Quantity Gallons(this double amount) => Gallon.S(amount);
            public static Quantity Gallons(this int amount) => Gallon.S(amount);

            public static Quantity Inches(this double amount) => Inch.S(amount);
            public static Quantity Inches(this int amount) => Inch.S(amount);
            public static Quantity Feet(this double amount) => Foot.S(amount);
            public static Quantity Feet(this int amount) => Foot.S(amount);
            public static Quantity Yards(this double amount) => Yard.S(amount);
            public static Quantity Yards(this int amount) => Yard.S(amount);
            public static Quantity Furlongs(this double amount) => Furlong.S(amount);
            public static Quantity Furlongs(this int amount) => Furlong.S(amount);
            public static Quantity Miles(this double amount) => Mile.S(amount);
            public static Quantity Miles(this int amount) => Mile.S(amount);
        }
    }
}