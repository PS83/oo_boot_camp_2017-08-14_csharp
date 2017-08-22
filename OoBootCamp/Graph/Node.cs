/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using static OoBootCamp.Graph.Path;

namespace OoBootCamp.Graph
{
    // Understands its neighbours
    public class Node
    {
        private readonly List<Link> _links = new List<Link>();

        public Node To(Node neighbour, double cost)
        {
            _links.Add(new Link(neighbour, cost));
            return neighbour;
        }

        public bool CanReach(Node destination)
        {
            return Paths(destination).Any();
        }

        public int HopCount(Node destination)
        {
            return Path(destination, FewestHops).HopCount();
        }

        public double Cost(Node destination)
        {
            return Path(destination).Cost();
        }

        public Path Path(Node destination)
        {
            return Path(destination, LeastCost);
        }

        public List<Path> Paths(Node destination)
        {
            return Paths(destination, NoVisitedNodes());
        }

        internal List<Path> Paths(Node destination, IList<Node> visitedNodes)
        {
            if (this == destination) return new List<Path>{new Path()};
            if (visitedNodes.Contains(this)) return new List<Path>();
            return _links
                .SelectMany(link => link.Paths(destination, CopyWithThis(visitedNodes)))
                .ToList();
        }

        private Path Path(Node destination, IComparer<Path> strategy)
        {
            var results = Paths(destination);
            if (!results.Any()) throw new InvalidOperationException("Unreachable destination");
            results.Sort(strategy);
            return results.First();
        }

        private IList<Node> NoVisitedNodes()
        {
            return new List<Node>();
        }

        private List<Node> CopyWithThis(IList<Node> originalNodes)
        {
            return new List<Node>(originalNodes) {this};
        }

    }
}
