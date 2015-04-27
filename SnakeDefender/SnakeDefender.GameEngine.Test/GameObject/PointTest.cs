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
    }
}
