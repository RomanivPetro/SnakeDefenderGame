using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeDefender.GameEngine.GameObject;
using SnakeDefender.GameEngine.Test.AdditionalsClasses;

namespace SnakeDefender.GameEngine.Test.GameObject
{
    [TestClass]
    public class SnakeTest
    {
        [TestMethod]
        public void TestSnakeCtrWithoutParameters()
        {
            var settings = new GameSettingsTest(10, 30, 40, 40.5, 50, 5, 5, 5, Direction.Left, "Results.xml");           
            Snake playerSnake = new Snake(settings);
            Assert.AreEqual(settings.SnakePosX, playerSnake.Head.X);
            Assert.AreEqual(settings.SnakePosY, playerSnake.Head.Y);
        }
        
    }
}
