using System;
using System.Configuration;
using SnakeDefender.GameEngine;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.ConsoleUI.AdditionalClasses
{
    // MR: судячи з назви SettingsReader мав би тільки зчитувати дані з config
    //     запам'ятовувати їх мав би окремий клас GameSettings : IGameSettings
    //     АБО
    //     SettingsReader перейменувати в GameSettings і реалізувати в ньому окремий метод ReadConfig()
    //
    // MR: в AppConfig не мають зберігатися дані про саму гру, наприклад швидкість чи розмір
    //     AppConfig має зберігати дані лише для репрезентації консольної аплікації, наприклад розмір вікна консолі і т.д.
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
            // MR: можливо варто було зробити якусь перевірку чи конвертація пройде
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
