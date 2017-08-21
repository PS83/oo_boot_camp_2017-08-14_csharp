/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    // Understands a connection from one specific Node to another
    internal class Link
    {
        private readonly Node _target;
        private readonly double _cost;

        internal delegate double CostStrategy(double cost);

        internal static readonly CostStrategy LeastCost = c => c;
        internal static readonly CostStrategy FewestHops = c => 1;

        internal Link(Node target, double cost)
        {
            _target = target;
            _cost = cost;
        }

        internal double Cost(Node destination, List<Node> visitedNodes, CostStrategy strategy)
        {
            return _target.Cost(destination, visitedNodes, strategy) + strategy(_cost);
        }
    }
}