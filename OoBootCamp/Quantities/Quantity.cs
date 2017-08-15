/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp.Quantities
{
    public class Quantity : IEquatable<Quantity>
    {
        public static readonly object Teaspoon = new object();
        public static readonly object Tablespoon = new object();
        public static readonly object Ounce = new object();

        private readonly double _amount;
        private readonly object _unit;

        public Quantity(double amount, object unit)
        {
            _amount = amount;
            _unit = unit;
        }

        public bool Equals(Quantity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this._amount.Equals(other._amount) && Equals(this._unit, other._unit);
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.GetType() == this.GetType() && Equals((Quantity) other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_amount.GetHashCode() * 397) ^ (_unit != null ? _unit.GetHashCode() : 0);
            }
        }
    }
}