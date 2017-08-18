/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Linq;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace OoBootCamp.Graph
{
    // Understands its neighbours
    public class Node
    {
        private readonly IList<Node> _neighbors = new List<Node>();
        private const double Unreachable = Double.PositiveInfinity;

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
            return (int)result;
        }

        private double HopCount(Node destination, IList<Node> visitedNodes)
        {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return Unreachable;
            return NeighborHopCount(destination, new List<Node>(visitedNodes));
        }

        private double NeighborHopCount(Node destination, IList<Node> visitedNodes)
        {
            visitedNodes.Add(this);
            var champion = Unreachable;
            foreach (var neighbor in _neighbors)
            {
                var challenger = neighbor.HopCount(destination, visitedNodes) + 1;
                if (challenger < champion) champion = challenger;
            }
            return champion;
        }

    }
}
