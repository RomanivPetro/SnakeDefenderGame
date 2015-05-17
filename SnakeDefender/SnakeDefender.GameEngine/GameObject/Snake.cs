using System.Collections.Generic;

namespace SnakeDefender.GameEngine.GameObject
{
    public class Snake
    {
        #region Private field

        private List<Point> _body;

        #endregion

        public List<Point> Body
        {
            get { return this._body; }
        }

        #region Public Properties

        public Point Head
        {
            get { return this._body[0]; }
        }
        public Point Tail
        {
            get { return this._body[this.Lenght - 1]; }
        }
        public int Lenght
        {
            get { return this._body.Count; }
        }
    
        #endregion

        #region Constructors

        public Snake(IGameSettings settings)
        {
            // Init snake's body
            this._body = new List<Point>();
            for (var i = 0; i < settings.SnakeLenght; i++)
            {
                this._body.Add(new Point(settings.SnakePosX,
                    settings.SnakePosY + i));
            }
        }   

        #endregion

        #region Public Methods

        public Point RemoveTail()
        {
            Point removedTail = this.Tail;
            this._body.RemoveAt(this.Lenght - 1);
            return removedTail;
        }

        public void AddHead(Point head)
        {
            this._body.Insert(0,head);
        }

        public bool CheckingCollisions(Point point, int startPos)
        {
            var results = new bool();
            for (var i = startPos; i < this.Lenght; i++)
            {
                if (this._body[i] == point)
                {
                    results = true;
                }
            }
            return results;
        }

        public void AddToBody()
        {
            this._body.Add(Tail);
        }

        #endregion
    }
}
