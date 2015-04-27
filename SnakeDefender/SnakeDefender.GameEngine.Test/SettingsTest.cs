using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.GameEngine.Test
{
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void TestSettingsInit()
        {
            var settings = new SetTest
            {
                GameBoardWidth = 10,
                GameBoardHeight = 30,
                GameSpeed = 40,
                GameScore = 40.5,
                GamePoints = 50,
                GameMoveDirection = Direction.Left,                
            };
            var generator = new RandomTest
            {
                genPoints = new List<Point>()

            };           
            var game = new Game(settings, generator);                       
            Assert.AreEqual(40, game.Speed);
            Assert.AreEqual(40.5, game.Score);            
            Assert.AreEqual(Direction.Left, game.MoveDirection);
            
        }
    }

    public class SetTest : IGameSettings
    {
        public int GameBoardWidth { get; set; }
        public int GameBoardHeight { get; set; }
        public int GameSpeed { get; set; }
        public double GameScore { get; set; }
        public int GamePoints { get; set; }
        public Direction GameMoveDirection { get; set; }       
    }
    public class RandomTest : IRandomGenerator
    {
        private int _count = 0;
        public List<Point> genPoints { get; set; }

        public RandomTest()
        {
            genPoints = new List<Point>();
        }
        public Point Generate()
        {
            var point = genPoints[_count];
            _count++;
            return point;
        }
    }    
}
