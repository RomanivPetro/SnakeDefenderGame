using System;
using System.Configuration;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.Helpers
{
    public class GameSettings : IGameSettings
    {      
        #region Public Property

        public int GameBoardWidth { get; set; }
        public int GameBoardHeight { get; set; }
        public int GameSpeed { get; set; }
        public double GameScore { get; set; }
        public int GamePoints { get; set; }
        public int SnakeLenght { get; set; }
        public int SnakePosX { get; set; }
        public int SnakePosY { get; set; }
        public Direction GameMoveDirection { get; set; }
        public string ResultPath { get; set; }

        #endregion

        #region Constructor
        public GameSettings()
        {

        }

        #endregion

        #region Public Methods

        public void ReadFromConfig()
        {          
            GameBoardWidth = Convert.ToInt32(ConfigurationManager.AppSettings["Width"]);
            GameBoardHeight = Convert.ToInt32(ConfigurationManager.AppSettings["Height"]);
            GameSpeed = Convert.ToInt32(ConfigurationManager.AppSettings["Speed"]);
            GameScore = Convert.ToDouble(ConfigurationManager.AppSettings["Score"]);
            GamePoints = Convert.ToInt32(ConfigurationManager.AppSettings["Points"]);
            SnakeLenght = Convert.ToInt32(ConfigurationManager.AppSettings["SnakeLenght"]);
            SnakePosX = Convert.ToInt32(ConfigurationManager.AppSettings["SnakePositionX"]);
            SnakePosY = Convert.ToInt32(ConfigurationManager.AppSettings["SnakePositionY"]);
            ResultPath = ConfigurationManager.AppSettings["Path"];

            #region Selected Direction

            var direction = ConfigurationManager.AppSettings["Direction"];
            switch (direction)
            {
                case "Left":
                    GameMoveDirection = Direction.Left;
                    break;
                case "Right":
                    GameMoveDirection = Direction.Right;
                    break;
                case "Up":
                    GameMoveDirection = Direction.Up;
                    break;
                case "Down":
                    GameMoveDirection = Direction.Down;
                    break;
                default:
                    GameMoveDirection = Direction.Left;
                    break;
            }

            #endregion

        }

        #endregion
    }
}
