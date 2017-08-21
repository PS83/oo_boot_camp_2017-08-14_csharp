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
            B.Cost(6).To(A);
            B.Cost(7).To(C).Cost(5).To(D).Cost(2).To(E).Cost(3).To(B).Cost(4).To(F);
            C.Cost(1).To(D);
            C.Cost(8).To(E);
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
    }
}
