using System;
using System.Configuration;
using SnakeDefender.GameEngine;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.ConsoleUI.AdditionalClasses
{
    public class SettingsReader : IGameSettings
    {
        #region Public Property
        public int GameBoardWidth { get; set; }
        public int GameBoardHeight { get; set; }
        public int GameSpeed { get; set; }
        public double GameScore { get; set; }
        public int GamePoints { get; set; }
        public Direction GameMoveDirection { get; set; }
       
        #endregion

        #region Constructor
        public SettingsReader()
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
