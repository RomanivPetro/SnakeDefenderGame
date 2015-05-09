using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.GameEngine.Test.AdditionalsClasses
{
    class RandomGeneratorTest : IRandomGenerator
    {
        #region Private Field

        private int _count = 0;

        #endregion

        #region Public Property

        public List<Point> genPoints { get; set; }

        #endregion

        // Constructor
        public RandomGeneratorTest()
        {
            genPoints = new List<Point>();
        }

        #region Public Method

        public Point Generate()
        {
            var point = genPoints[_count];
            _count++;
            return point;
        }

        #endregion
    }
}
