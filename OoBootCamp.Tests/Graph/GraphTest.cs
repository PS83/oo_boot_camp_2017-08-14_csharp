/* 
 * Copyright (c) 2017 by Fred George
 * May be used freely except for training; license required for training.
 */

using System;
using NUnit.Framework;
using OoBootCamp.Graph;

namespace OoBootCamp.Tests.Graph
{
    // Ensures graph algorithms operate correctly
    [TestFixture]
    public class GraphTest
    {
        private static readonly Node A = new Node();
        private static readonly Node B = new Node();
        private static readonly Node C = new Node();
        private static readonly Node D = new Node();
        private static readonly Node E = new Node();
        private static readonly Node F = new Node();
        private static readonly Node G = new Node();

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            B.To(A, cost: 6);
            B.To(C, cost: 7).To(D, cost: 5).To(E, cost: 2).To(B, cost: 3).To(F, cost: 4);
            C.To(D, cost: 1);
            C.To(E, cost: 8);
        }

        [Test]
        public void CanReach()
        {
            Assert.IsTrue(A.CanReach(A));
            Assert.IsTrue(B.CanReach(A));
            Assert.IsFalse(A.CanReach(B));
            Assert.IsTrue(B.CanReach(F));
            Assert.IsTrue(C.CanReach(F));
            Assert.IsFalse(G.CanReach(B));
            Assert.IsFalse(B.CanReach(G));
        }

        [Test]
        public void HopCount()
        {
            Assert.AreEqual(0, A.HopCount(A));
            Assert.AreEqual(1, B.HopCount(A));
            Assert.AreEqual(1, B.HopCount(F));
            Assert.AreEqual(3, C.HopCount(F));
            Assert.Throws<InvalidOperationException>(delegate { A.HopCount(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.HopCount(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.HopCount(G); });
        }

        [Test]
        public void Cost()
        {
            Assert.AreEqual(0, A.Cost(A));
            Assert.AreEqual(6, B.Cost(A));
            Assert.AreEqual(4, B.Cost(F));
            Assert.AreEqual(10, C.Cost(F));
            Assert.Throws<InvalidOperationException>(delegate { A.Cost(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.Cost(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.Cost(G); });
        }

        [Test]
        public void Path()
        {
            AssertPath(A, A, expectedHopCount: 0, expectedCost: 0);
            AssertPath(B, A, expectedHopCount: 1, expectedCost: 6);
            AssertPath(B, F, expectedHopCount: 1, expectedCost: 4);
            AssertPath(C, F, expectedHopCount: 4, expectedCost: 10);
            Assert.Throws<InvalidOperationException>(delegate { A.Path(B); });
            Assert.Throws<InvalidOperationException>(delegate { G.Path(B); });
            Assert.Throws<InvalidOperationException>(delegate { B.Path(G); });
        }

        [Test]
        public void Paths()
        {
            Assert.AreEqual(1, A.Paths(A).Count);
            Assert.AreEqual(1, B.Paths(A).Count);
            Assert.AreEqual(1, B.Paths(F).Count);
            Assert.AreEqual(2, C.Paths(D).Count);
            Assert.AreEqual(3, C.Paths(F).Count);
            Assert.AreEqual(0, A.Paths(B).Count);
            Assert.AreEqual(0, G.Paths(B).Count);
            Assert.AreEqual(0, B.Paths(G).Count);
        }

        private void AssertPath(Node source, Node destination, int expectedHopCount, double expectedCost)
        {
            Path p = source.Path(destination);
            Assert.AreEqual(expectedHopCount, p.HopCount());
            Assert.AreEqual(expectedCost, p.Cost());
        }
    }
}

/*
 *  Size Scorecard  Path()  
 *      Classes     5 + 2  
 *      Methods     22    
 *      xLOC        34      
 *      Avg mthd    1.5     
 *      Test LOC    42      
 *      % Test LOC  55%     
 */
