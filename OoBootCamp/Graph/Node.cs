﻿/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using static OoBootCamp.Graph.Link;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace OoBootCamp.Graph
{
    // Understands its neighbours
    public class Node
    {
        private readonly List<Link> _links = new List<Link>();
        private const double Unreachable = Double.PositiveInfinity;

        public LinkBuilder Cost(double amount)
        {
            return new LinkBuilder(amount, _links);
        }

        public bool CanReach(Node destination)
        {
            return Cost(destination, NoVisitedNodes(), LeastCost) != Unreachable;
        }

        private IList<Node> NoVisitedNodes()
        {
            return new List<Node>();
        }

        public int HopCount(Node destination)
        {
            return (int)Cost(destination, FewestHops);
        }

        public double Cost(Node destination)
        {
            return Cost(destination, LeastCost);
        }

        private double Cost(Node destination, CostStrategy strategy)
        {
            var result = Cost(destination, NoVisitedNodes(), strategy);
            if (result == Unreachable) throw new InvalidOperationException("Unreachable destination");
            return result;
        }

        internal double Cost(Node destination, IList<Node> visitedNodes, CostStrategy strategy)
        {
            if (this == destination) return 0;
            if (visitedNodes.Contains(this)) return Unreachable;
            if (_links.Count == 0) return Unreachable;
            return _links
                .ConvertAll(link => link.Cost(destination, CopyWithThis(visitedNodes), strategy))
                .Min();
        }

        private List<Node> CopyWithThis(IList<Node> originalNodes)
        {
            return new List<Node>(originalNodes) {this};
        }

        public class LinkBuilder
        {
            private readonly double _cost;
            private readonly List<Link> _links;

            internal LinkBuilder(double cost, List<Link> links)
            {
                _cost = cost;
                _links = links;
            }

            public Node To(Node target)
            {
                _links.Add(new Link(target, _cost));
                return target;
            }
        }

    }
}
