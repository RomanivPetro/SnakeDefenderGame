using System;
using System.Collections.Generic;
using System.Linq;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.GameEngine
{
    #region Public Enumerations

    public enum GameStatus
    {
        ReadyToStart,
        InProgress,
        Completed
    }
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    #endregion
    public class Game
    {
        #region Private field   
   
        private int _count;        
        private List<Point> _emptyField;
        private Snake _playerSnake;
        private IGameSettings _gameSettings;
        private IRandomGenerator _randomGenerator;

        #endregion

        #region Public Properties

        public Point Head { get; private set; }
        public Point Tail { get; private set; }    
        public Point Food { get; private set; }                        
        public int Speed { get { return _gameSettings.GameSpeed; } }
        public double Score { get { return _gameSettings.GameScore; } }
        public GameStatus Status { get; private set; }
        public Direction MoveDirection
        {
            get
            {
                return this._gameSettings.GameMoveDirection;
            }
            set
            {
                this._gameSettings.GameMoveDirection = value;
            }
        }
        
        #endregion

        #region Constructor

        public Game(IGameSettings gameSettings, IRandomGenerator randomGenerator)
        {       
            this._gameSettings = gameSettings;
            this._randomGenerator = randomGenerator;
            this._playerSnake = new Snake();
            this.Status = GameStatus.ReadyToStart;
            this._emptyField = new List<Point>();
            this.Head = _playerSnake.Body[0];
            this._count = 25;         
        }

        #endregion

        #region Public Methods

        public void Start()
        {
            #region Validation

            if (this.Status != GameStatus.ReadyToStart)
            {
                throw new InvalidOperationException("Only game with status 'ReadyToStart' can be started");
            }

            #endregion

            this.Status = GameStatus.InProgress;
            GenerateFood();
        }
        public void Stop()
        {
            #region Validation

            if (this.Status != GameStatus.InProgress)
            {
                throw new InvalidOperationException("Only game with status 'InProgress' can be stopped");
            }

            #endregion

            this.Status = GameStatus.Completed;
        }
        public void Move()
        {
            #region Validation

            if (this.Status != GameStatus.InProgress)
            {
                throw new InvalidOperationException("Only game with status 'InProgress' can invoke Move()");
            }

            #endregion

            this._emptyField.Add(this._playerSnake.Body[_playerSnake.Body.Count - 1]);
            Tail = this._playerSnake.Body[this._playerSnake.Body.Count - 1];
            
            this._playerSnake.Body.RemoveAt(this._playerSnake.Body.Count - 1);
            
            if (this._gameSettings.GameMoveDirection == Direction.Left)
            {
                this.Head = new Point(this.Head.X - 1, this.Head.Y);
            }
            if (this._gameSettings.GameMoveDirection == Direction.Right)
            {
                this.Head = new Point(this.Head.X + 1, this.Head.Y);
            }
            if (this._gameSettings.GameMoveDirection == Direction.Up)
            {
                this.Head = new Point(this.Head.X, this.Head.Y - 1);
            }
            if (this._gameSettings.GameMoveDirection == Direction.Down)
            {
                this.Head = new Point(this.Head.X, this.Head.Y + 1);
            }
           
            this._playerSnake.Body.Insert(0, this.Head);
            MoveCheck();
            Eat();
        }                       

        #endregion

        #region Private Methods

        private void MoveCheck()
        {
            // Detect collisions with game's borders
            if (this.Head.X < 0 || this.Head.Y < 0 
                || this.Head.X >= this._gameSettings.GameBoardWidth 
                || this.Head.Y >= this._gameSettings.GameBoardHeight)
            {
                Stop();
            }

            // Detect colissions with Body
            for (var i = 1; i < this._playerSnake.Body.Count; i++)
            {
                if (this.Head.X == this._playerSnake.Body[i].X
                    && this.Head.Y == this._playerSnake.Body[i].Y)
                {
                    Stop();
                }
            }

            // Detect collision with empty field
            if (this._emptyField.Count(point => this.Head.X == point.X && this.Head.Y == point.Y) != 0)
            {
                Stop();
            }
        }
        private void Eat()
        {
            if (this.Head.X == this.Food.X && this.Head.Y == this.Food.Y)
            {
                this._playerSnake.Body.Add(new Point(this._playerSnake.Body[this._playerSnake.Body.Count - 1].X,
                    this._playerSnake.Body[this._playerSnake.Body.Count - 1].Y));

                // Update Score
                this._gameSettings.GameScore += this._gameSettings.GamePoints;
                GenerateFood();
            }
            else
            {
                this._gameSettings.GameScore += 0.2;
            }
            if (this._gameSettings.GameScore > this._count)
            {
                this._count += 25;
                if (this._gameSettings.GameSpeed >= 50)
                {
                    this._gameSettings.GameSpeed -= 45;
                }
            }
        }
        private void GenerateFood()
        {          
            Point genPoint;
            while (true)
            {
                genPoint = _randomGenerator.Generate();
                if (_emptyField.Count(point => point.X == genPoint.X && 
                                              point.Y == genPoint.Y) == 0)
                {
                    if (_playerSnake.Body.Count(point => point.X == genPoint.X && 
                                                        point.Y == genPoint.Y) == 0)
                    {
                        Food = genPoint;
                        return;
                    }
                }

            }
        }  

        #endregion
    }
}
