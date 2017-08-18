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
    }
}
