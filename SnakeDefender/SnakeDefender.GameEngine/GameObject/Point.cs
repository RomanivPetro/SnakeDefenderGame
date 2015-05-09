
namespace SnakeDefender.GameEngine.GameObject
{
    public class Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Point p = obj as Point;
            if ((object)p == null)
            {
                return false;
            }
            // Return true if the fields match:
            return ((X == p.X) && (Y == p.Y));
        }

        public override int GetHashCode()
        {
            return (this.X ^ this.Y);
        }

        public static bool operator ==(Point a, Point b)
        {          
            return a.Equals(b);
        }

        public static bool operator !=(Point a, Point b)
        {
            return !a.Equals(b);
        }
    }
}