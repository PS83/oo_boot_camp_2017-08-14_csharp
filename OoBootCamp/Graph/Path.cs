/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    // Understands a specific route from one Node to another Node
    public class Path : IComparable<Path>
    {
        private readonly List<Link> _links = new List<Link>();

        public int HopCount()
        {
            return _links.Count;
        }

        public double Cost()
        {
            return Link.TotalCost(_links);
        }

        internal Path Prepend(Link link)
        {
            _links.Insert(0, link);
            return this;
        }

        public int CompareTo(Path other)
        {
            return this.Cost().CompareTo(other.Cost());
        }
    }
}
