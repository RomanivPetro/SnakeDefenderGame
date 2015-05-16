
using SnakeDefender.GameEngine;
using System.Drawing;
using System.Windows.Forms;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.DesktopUI
{
    class Drawing
    {
        private static PictureBox _container;
        private static IGameSettings _gameSettings;

        public static Rectangle DrawingRectangle(SnakeDefender.GameEngine.GameObject.Point point)
        {
            var height = _container.Height/_gameSettings.GameBoardHeight;
            var widht = _container.Width/_gameSettings.GameBoardWidth;
            return new Rectangle(point.X * widht, point.Y * height, widht, height);
        }
      
        public static void InitDrawing(PictureBox container, IGameSettings settings)
        {
            _container = container;
            _gameSettings = settings;
        }

        public static void DrawField(Game game, PaintEventArgs e)
        {
            DrawFoods(game, e);
            DrawBody(game, e);
        }

        public static void DrawGame(Game game, object sender, PaintEventArgs e)
        {           
            DrawHead(game, sender, e);
            DrawTail(game, sender, e);
            DrawFruit(game,e);
        }

        public static void DrawHead(Game game, object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.BlanchedAlmond, DrawingRectangle(game.Head));
        }

        public static void DrawTail(Game game, object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Black, DrawingRectangle(game.Tail));
        }

        public static void DrawFoods(Game game, PaintEventArgs e)
        {                     
            for (var i = 0; i < _gameSettings.GameBoardWidth; i++)
            {
                for (var j = 0; j < _gameSettings.GameBoardHeight; j++)
                {
                    e.Graphics.FillEllipse(Brushes.Tomato, DrawingRectangle(new SnakeDefender.GameEngine.GameObject.Point(i,j)));
                }
            }

            DrawFruit(game,e);
        }

        public static void DrawBody(Game game, PaintEventArgs e)
        {
            for (var i = 0; i < _gameSettings.SnakeLenght; i++)
            {
                e.Graphics.FillEllipse(Brushes.BlanchedAlmond, DrawingRectangle(
                    new SnakeDefender.GameEngine.GameObject.Point(
                        _gameSettings.SnakePosX, _gameSettings.SnakePosY + i)));
            } 
            
        }

        public static void DrawFruit(Game game, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Blue, DrawingRectangle(game.Food));
        }
    }
}
