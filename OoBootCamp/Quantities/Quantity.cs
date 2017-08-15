/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    public class Quantity : IEquatable<Quantity>
    {
        private static readonly double Tolerance = 1e-6;
        private readonly double _amount;
        private readonly Unit _unit;

        internal Quantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public bool Equals(Quantity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Math.Abs(this._amount - ConvertedAmount(other)) < Tolerance;
        }

        private double ConvertedAmount(Quantity other)
        {
            return this._unit.ConvertedAmount(other._amount, other._unit);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == this.GetType() && Equals((Quantity) other);
        }

        public override int GetHashCode()
        {
            return _unit.HashCode(_amount);
        }
    }
}