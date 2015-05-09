using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeDefender.GameEngine.GameObject;
using SnakeDefender.GameEngine.Test.AdditionalsClasses;

namespace SnakeDefender.GameEngine.Test
{
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void TestSettingsInit()
        {
            var settings = new GameSettingsTest(10,30,40,40.5,50,5,5,5,Direction.Left, "Results.xml");         
            var generator = new RandomGeneratorTest();
                   
            var game = new Game(settings, generator);                       
            Assert.AreEqual(40, game.Speed);
            Assert.AreEqual(40.5, game.Score);            
            Assert.AreEqual(Direction.Left, game.MoveDirection);            
        }
    }

  
   
}
