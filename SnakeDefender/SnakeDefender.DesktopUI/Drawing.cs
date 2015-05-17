
using SnakeDefender.GameEngine;
using System.Drawing;
using System.Windows.Forms;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.DesktopUI
{
    static class Drawing
    {
        private static readonly  Image AppleImage;
        private static readonly  Image FruitImage;
        private static readonly Image BadFruitImage;
        private static PictureBox _container;
        private static IGameSettings _gameSettings;

        static Drawing()
        {
            AppleImage = SnakeDefender.DesktopUI.Properties.Resources.apple;
            FruitImage = SnakeDefender.DesktopUI.Properties.Resources.redApple;
            BadFruitImage = SnakeDefender.DesktopUI.Properties.Resources.blackfruit;
        }
               
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
       
        public static void DrawBadFruits(Game game, PaintEventArgs e)
        {
            foreach (var point in game.EmptyField)
            {
                e.Graphics.DrawImage(BadFruitImage, DrawingRectangle(point));
            }
        }

        public static void DrawGame(Game game, object sender, PaintEventArgs e)
        {
            DrawFoods(game, e);
            DrawBadFruits(game, e);
            DrawSnake(game, sender, e);                     
        }

        public static void DrawSnake(Game game, object sender, PaintEventArgs e)
        {
            foreach (var point in game.Body)
            {
                e.Graphics.FillEllipse(Brushes.DarkGreen, DrawingRectangle(point));
            }          
        }
      
        public static void DrawFoods(Game game, PaintEventArgs e)
        {                     
            for (var i = 0; i < _gameSettings.GameBoardWidth; i++)
            {
                for (var j = 0; j < _gameSettings.GameBoardHeight; j++)
                {                  
                    e.Graphics.DrawImage(AppleImage, DrawingRectangle(new SnakeDefender.GameEngine.GameObject.Point(i, j)));
                }
            }

            DrawFruit(game,e);
        }
       
        public static void DrawFruit(Game game, PaintEventArgs e)
        {          
            e.Graphics.DrawImage(FruitImage, DrawingRectangle(game.Food));
        }
    }
}
