﻿using System;
using System.Timers;
using SnakeDefender.GameEngine;
using SnakeDefender.ConsoleUI.AdditionalClasses;
using GameStatus = SnakeDefender.GameEngine.GameStatus;


namespace SnakeDefender.ConsoleUI
{
    class ConsoleGame
    {
        #region Private fields

        // MR: змінну варто назвати відповідно до назви класу _settingsReader
        private SettingsReader _gameSettings;
        private RandomGenerator _randomGenerator;
        private Game _game;
        private System.Timers.Timer _gameTimer;
        // MR: зайвий символ підкреслення _
        private ConsoleKeyInfo _key_info;

        #endregion

        #region Public Property
        public int Score
        {
            get { return (int) this._game.Score; }
        }

        #endregion

        #region Constructor
        public ConsoleGame()
        {
            this._gameSettings = new SettingsReader();
            this._gameSettings.ReadFromConfig();
            this._randomGenerator = new RandomGenerator(this._gameSettings.GameBoardWidth,
                this._gameSettings.GameBoardHeight);
            this._game = new Game(this._gameSettings, this._randomGenerator);             
        }

        #endregion

        #region Public Methods
        public void StartGame()
        {             
            this._game.Start();      
            // MR: зайвий пробіл
             DrawField();
            // MR: треба було підключити using System.Timers
            this._gameTimer = new System.Timers.Timer(this._game.Speed);
            this._gameTimer.Elapsed += new ElapsedEventHandler(RunningGame);
            this._gameTimer.Enabled = true;
            GameControl();
            this._gameTimer.Dispose();
        }

        #endregion

        #region Private Methods
        // MR: відповідна назва OnTimerTick чи OnTimerElapsed
        private void RunningGame(object source, ElapsedEventArgs e)
        {
            if (this._game.Status != GameStatus.Completed)
            {
                this._game.Move();
                // MR: незрозуміло для чого ще одна перевірка, еквівалентна попередній
                //     без неї всі тести зелені + гра йде без вильотів чи багів
                if (this._game.Status != GameStatus.Completed)
                {
                    DrawMoving();
                }
                this._gameTimer.Interval = this._game.Speed;
            }
            else
            {
                // MR: цей блок коду варто винести в окремий метод CompleteGame()
                Console.SetCursorPosition(0, this._gameSettings.GameBoardHeight + 3);
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(0, this._gameSettings.GameBoardHeight + 3);
                Console.WriteLine("GAME OVER");
                Console.ForegroundColor = color;
            }
        }
        // MR: занадто великий метод; всі дії потрібно винести в окремі методи TryChangeDirectionRight() і т.д. або якось інакше
        private void GameControl()
        {
            while (this._game.Status != GameStatus.Completed)
            {
                this._key_info = Console.ReadKey();

                switch (this._key_info.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (this._game.MoveDirection != GameEngine.Direction.Left)
                        {
                            this._game.MoveDirection = GameEngine.Direction.Right;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (this._game.MoveDirection != GameEngine.Direction.Right)
                        {
                            this._game.MoveDirection = GameEngine.Direction.Left;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (this._game.MoveDirection != GameEngine.Direction.Down)
                        {
                            this._game.MoveDirection = GameEngine.Direction.Up;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (this._game.MoveDirection != GameEngine.Direction.Up)
                        {
                            this._game.MoveDirection = GameEngine.Direction.Down;
                        }
                        break;
                    case ConsoleKey.Escape:
                        this._gameTimer.Stop();
                        Pause();
                        break;
                }

            }

        }
        private void Pause()
        {
            // MR: while(true) - погана практика
            while (true)
            {
                this._key_info = Console.ReadKey();
                if (this._key_info.Key == ConsoleKey.Escape ||
                    this._key_info.Key == ConsoleKey.Enter)
                {
                    this._gameTimer.Start();
                    return;
                }
            }
        }

        #region Drawing
        // MR: можна порозбивати цей метод на кілька менших DrawFood(), DrawHead(), DrawTail(), ShowScore()
        private void DrawMoving()
        {
            Console.SetCursorPosition(this._game.Food.X, this._game.Food.Y);
            Console.Write("@");

            // Draw new head
            Console.SetCursorPosition(this._game.Head.X, this._game.Head.Y);
            Console.Write("#");          
            // Remove Tail
            Console.SetCursorPosition(this._game.Tail.X, this._game.Tail.Y);           
            Console.Write(" ");
            // Show Score
            Console.SetCursorPosition(this._gameSettings.GameBoardWidth + 3, 0);
            Console.Write("SCORE: ");
            Console.Write(this.Score);

        }
        private void DrawField()
        {
            for (int x = 0; x < this._gameSettings.GameBoardWidth; x++)
            {
                for (int y = 0; y < this._gameSettings.GameBoardHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(".");
                }
            }
        }
        #endregion

        #endregion

    }
}
