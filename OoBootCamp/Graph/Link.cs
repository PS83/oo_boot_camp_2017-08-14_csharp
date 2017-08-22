/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;
using System.Linq;

namespace OoBootCamp.Graph
{
    // Understands a connection from one specific Node to another
    internal class Link
    {
        private readonly Node _target;
        private readonly double _cost;

        internal Link(Node target, double cost)
        {
            _target = target;
            _cost = cost;
        }

        internal List<Path> Paths(Node destination, List<Node> visitedNodes)
        {
            return _target
                .Paths(destination, visitedNodes)
                .Select(p => p.Prepend(this))
                .ToList();
        }

        public static double TotalCost(List<Link> links)
        {
            return links.Sum(link => link._cost);
        }
    }
}