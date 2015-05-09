using System;
using System.Timers;
using SnakeDefender.GameEngine;
using SnakeDefender.GameEngine.GameObject;
using SnakeDefender.Helpers;



namespace SnakeDefender.ConsoleUI
{
    class ConsoleGame
    {
        #region Private fields      
 
        private Game _game;
        private Timer _gameTimer;        
        private ConsoleKeyInfo _keyInfo;
        private readonly int _gameBoardHeight;
        private readonly int _gameBoardWidth;

        #endregion

        #region Public Property

        public int Score
        {
            get { return (int) this._game.Score; }
        }

        #endregion

        #region Constructor

        public ConsoleGame(IGameSettings gameSettings, IRandomGenerator randomGenerator)
        {           
            this._game = new Game(gameSettings, randomGenerator);
            this._gameBoardHeight = gameSettings.GameBoardHeight;
            this._gameBoardWidth = gameSettings.GameBoardWidth;
        }

        #endregion

        #region Public Methods

        public void StartGame()
        {             
            this._game.Start();               
            DrawField();
            this._gameTimer = new Timer(this._game.Speed);
            this._gameTimer.Elapsed += new ElapsedEventHandler(RunningGame);
            this._gameTimer.Enabled = true;
            GameControl();
            this._gameTimer.Dispose();
        }

        #endregion

        #region Private Methods

        private void RunningGame(object source, ElapsedEventArgs e)
        {
            if (this._game.Status != GameStatus.Completed)
            {
                this._game.Move();
            }            
            if (this._game.Status != GameStatus.Completed)
            {               
                DrawMoving();
                this._gameTimer.Interval = this._game.Speed;
            }
            else
            {
                GameCompleted();
            }
        }
     
        private void GameControl()
        {
            while (this._game.Status != GameStatus.Completed)
            {
                this._keyInfo = Console.ReadKey();

                switch (this._keyInfo.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (this._game.MoveDirection != Direction.Left)
                        {
                            this._game.MoveDirection = Direction.Right;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (this._game.MoveDirection != Direction.Right)
                        {
                            this._game.MoveDirection = Direction.Left;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (this._game.MoveDirection != Direction.Down)
                        {
                            this._game.MoveDirection = Direction.Up;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (this._game.MoveDirection != Direction.Up)
                        {
                            this._game.MoveDirection = Direction.Down;
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
            while (true)
            {
                this._keyInfo = Console.ReadKey();
                if (this._keyInfo.Key == ConsoleKey.Escape ||
                    this._keyInfo.Key == ConsoleKey.Enter)
                {
                    this._gameTimer.Start();
                    return;
                }
            }
        }

        #region Drawing

        private void GameCompleted()
        {
            Console.SetCursorPosition(0, this._gameBoardHeight + 3);
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("GAME OVER");
            Console.ForegroundColor = color;
        }

        private void DrawMoving()
        {
            DrawFood();
            // Draw new head
            DrawHead();
            // Remove Tail
            DrawTail();
            // Show Score
            DrawScore();
        }

        private void DrawScore()
        {
            Console.SetCursorPosition(this._gameBoardWidth + 3, 0);
            Console.Write("SCORE: ");
            Console.Write(this.Score);
        }

        private void DrawTail()
        {
            Console.SetCursorPosition(this._game.Tail.X, this._game.Tail.Y);
            Console.Write(" ");
        }

        private void DrawHead()
        {
            Console.SetCursorPosition(this._game.Head.X, this._game.Head.Y);
            Console.Write("#");
        }

        private void DrawFood()
        {
            Console.SetCursorPosition(this._game.Food.X, this._game.Food.Y);
            Console.Write("@");
        }

        private void DrawField()
        {
            for (int x = 0; x < this._gameBoardWidth; x++)
            {
                for (int y = 0; y < this._gameBoardHeight; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(".");
                }
            }
        }

        public void ShowResults(object sender, ResultsHolder e)
        {
            Console.WriteLine("-> - {0} -- {1}",e.Name,e.Score);
            
        }

        #endregion

        #endregion

    }
}
