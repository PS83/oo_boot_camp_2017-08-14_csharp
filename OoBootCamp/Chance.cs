/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;

namespace OoBootCamp
{
    // Understands the likelihood of something occurring
    public class Chance : IEquatable<Chance>
    {
        private readonly double _fraction;

        public Chance(double likelihoodAsFraction)
        {
            _fraction = likelihoodAsFraction;
        }

        public bool Equals(Chance other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return this._fraction.Equals(other._fraction);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Chance) obj);
        }

        public override int GetHashCode()
        {
            return _fraction.GetHashCode();
        }
    }


}