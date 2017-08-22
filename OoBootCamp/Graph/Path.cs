/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    // Understands a specific route from one Node to another Node
    public abstract class Path : IComparable<Path>
    {
        public static IComparer<Path> LeastCost =
            Comparer<Path>.Create((left, right) => left.Cost().CompareTo(right.Cost()));
        public static IComparer<Path> FewestHops =
            Comparer<Path>.Create((left, right) => left.HopCount().CompareTo(right.HopCount()));

        public abstract int HopCount();

        public abstract double Cost();

        internal abstract Path Prepend(Link link);

        public int CompareTo(Path other)
        {
            return this.Cost().CompareTo(other.Cost());
        }

        internal class ActualPath : Path
        {

            private readonly List<Link> _links = new List<Link>();

            public override int HopCount()
            {
                return _links.Count;
            }

            public override double Cost()
            {
                return Link.TotalCost(_links);
            }

            internal override Path Prepend(Link link)
            {
                _links.Insert(0, link);
                return this;
            }
        }

        internal class NoPath : Path
        {

            public override int HopCount()
            {
                return Int32.MaxValue;
            }

            public override double Cost()
            {
                return double.PositiveInfinity;
            }

            internal override Path Prepend(Link ignore)
            {
                return this;
            }
        }
    }
}
