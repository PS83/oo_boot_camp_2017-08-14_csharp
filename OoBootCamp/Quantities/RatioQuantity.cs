/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    public class RatioQuantity : IEquatable<RatioQuantity>
    {
        private static readonly double Tolerance = 1e-6;
        private readonly double _amount;
        private readonly Unit _unit;

        internal RatioQuantity(double amount, Unit unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public bool Equals(RatioQuantity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (!this.IsCompatible(other)) return false;
            return Math.Abs(this._amount - ConvertedAmount(other)) < Tolerance;
        }

        private bool IsCompatible(RatioQuantity other)
        {
            return this._unit.IsCompatible(other._unit);
        }

        private double ConvertedAmount(RatioQuantity other)
        {
            return this._unit.ConvertedAmount(other._amount, other._unit);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == this.GetType() && Equals((RatioQuantity) other);
        }

        public override int GetHashCode()
        {
            return _unit.HashCode(_amount);
        }

        public static RatioQuantity operator +(RatioQuantity left, RatioQuantity right)
        {
            return new RatioQuantity(left._amount + left.ConvertedAmount(right), left._unit);
        }

        public static RatioQuantity operator -(RatioQuantity q) => new RatioQuantity(-q._amount, q._unit);

        public static RatioQuantity operator -(RatioQuantity left, RatioQuantity right) => left + -right;
    }
}