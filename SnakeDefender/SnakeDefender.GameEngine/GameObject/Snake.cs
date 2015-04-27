using System.Collections.Generic;

namespace SnakeDefender.GameEngine.GameObject
{
    public class Snake
    {
        #region Public Property
        public List<Point> Body { get; set; }
        #endregion

        #region Constructors

        public Snake()
        {
            // Init snake's body
            this.Body = new List<Point>();
            for (var i = 0; i < 5; i++)
            {
                this.Body.Add(new Point(5, i + 1));
            }
        }
      
        #endregion
    }
}
