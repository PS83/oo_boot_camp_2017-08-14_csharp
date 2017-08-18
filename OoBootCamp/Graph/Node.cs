/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace OoBootCamp.Graph
{
    // Understands its neighbours
    public class Node
    {
        private readonly IList<Node> _neighbors = new List<Node>();
        private const int Unreachable = -1;

        public Node To(Node neighbour)
        {
            _neighbors.Add(neighbour);
            return neighbour;
        }

        public bool CanReach(Node destination)
        {
            return CanReach(destination, NoVisitedNodes());
        }

        private bool CanReach(Node destination, IList<Node> visitedNodes)
        {
            if (this == destination) return true;
            if (visitedNodes.Contains(this)) return false;
            visitedNodes.Add(this);
            return _neighbors.Any(n => n.CanReach(destination, visitedNodes));
        }

        private IList<Node> NoVisitedNodes()
        {
            return new List<Node>();
        }

        public int HopCount(Node destination)
        {
            var result = HopCount(destination, NoVisitedNodes());
            if (result == Unreachable) throw new InvalidOperationException("Unreachable destination");
            return result;
        }

        private int HopCount(Node destination, IList<Node> visitedNodes)
        {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return Unreachable;
            visitedNodes.Add(this);
            foreach (var n in _neighbors)
            {
                var result = n.HopCount(destination, visitedNodes);
                if (result != Unreachable) return result + 1;
            }
            return Unreachable;
        }
    }
}
