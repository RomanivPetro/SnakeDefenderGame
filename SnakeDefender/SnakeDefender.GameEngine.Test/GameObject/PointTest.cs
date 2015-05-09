using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.GameEngine.Test.GameObject
{
    [TestClass]
    public class PointTest
    {
        [TestMethod]
        public void TestPointConstructor()
        {
            Point point = new Point(1,2);
            Assert.AreEqual(1,point.X);
            Assert.AreEqual(2,point.Y);
        }

        [TestMethod]
        public void TestPointGetHash()
        {
            Point point = new Point(1, 2);
            Assert.AreEqual(1^2,point.GetHashCode());
        }

        [TestMethod]
        public void TestPointOperator()
        {
            Point a = new Point(2,4);
            Point b = null;
            Assert.IsFalse(a == b);
        }

        [TestMethod]
        public void TestPointOperator2()
        {
            Point a = new Point(2, 4);
            Point b = new Point(2, 5);
            Assert.IsFalse(a == b);
        }
   
    }
}
