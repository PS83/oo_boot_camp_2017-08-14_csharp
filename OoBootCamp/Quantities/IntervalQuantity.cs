/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    public class IntervalQuantity : IEquatable<IntervalQuantity>
    {
        private static readonly double Tolerance = 1e-6;
        private readonly double _amount;
        private readonly Unit _unit;

        internal IntervalQuantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public bool Equals(IntervalQuantity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (!this.IsCompatible(other)) return false;
            return Math.Abs(this._amount - ConvertedAmount(other)) < Tolerance;
        }

        private bool IsCompatible(IntervalQuantity other)
        {
            return this._unit.IsCompatible(other._unit);
        }

        private double ConvertedAmount(IntervalQuantity other)
        {
            return this._unit.ConvertedAmount(other._amount, other._unit);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == this.GetType() && Equals((IntervalQuantity)other);
        }

        public override int GetHashCode()
        {
            return _unit.HashCode(_amount);
        }
    }
}