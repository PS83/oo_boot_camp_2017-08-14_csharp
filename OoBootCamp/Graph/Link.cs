/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System.Collections.Generic;

namespace OoBootCamp.Graph
{
    // Understands a connection from one specific Node to another
    public class Link
    {
        private readonly Node _target;
        private readonly double _cost;

        public Link(Node target, double cost)
        {
            _target = target;
            _cost = cost;
        }

        public double HopCount(Node destination, List<Node> visitedNodes)
        {
            return _target.HopCount(destination, visitedNodes) + 1;
        }
    }
}