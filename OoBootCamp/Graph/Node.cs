/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using static OoBootCamp.Graph.Path;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace OoBootCamp.Graph
{
    // Understands its neighbours
    public class Node
    {
        private readonly List<Link> _links = new List<Link>();
        private static readonly Path NoPath = new NoPath();

        public Node To(Node neighbour, double cost)
        {
            _links.Add(new Link(neighbour, cost));
            return neighbour;
        }

        public bool CanReach(Node destination)
        {
            return Path(destination, NoVisitedNodes(), LeastCost) != NoPath;
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

        private Path Path(Node destination, IComparer<Path> strategy)
        {
            var result = Path(destination, NoVisitedNodes(), strategy);
            if (result == NoPath) throw new InvalidOperationException("Unreachable destination");
            return result;
        }

        internal Path Path(Node destination, IList<Node> visitedNodes, IComparer<Path> strategy)
        {
            if (this == destination) return new ActualPath();
            if (visitedNodes.Contains(this)) return NoPath;
            if (_links.Count == 0) return NoPath;
            var neighborPaths = _links
                .ConvertAll(link => link.Path(destination, CopyWithThis(visitedNodes), strategy));
            neighborPaths.Sort(strategy);
            return neighborPaths.First();
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
