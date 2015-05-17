﻿using System;
using System.Collections.Generic;
using System.Linq;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.GameEngine
{ 
    public class Game
    {
        #region GameConstants

        private const int Count = 25;
        private const double Coins = 0.2;
        private const int SpeedLimit = 50;
        private const int SpeedUpper = 45;

        #endregion

        #region Private field

        private int _counter;               
        private Point _point;       
        private Snake _playerSnake;
        private IGameSettings _gameSettings;
        private IRandomGenerator _randomGenerator;

        #endregion

        #region Public Properties

        public Point Head
        {
            get { return this._playerSnake.Head; }
        }
        public Point Tail
        {
            get { return this._playerSnake.Tail; }
        }
        public List<Point> Body
        {
            get { return this._playerSnake.Body; }
        }
        public List<Point> EmptyField { get; private set; }
        public Point Food { get; private set; }                        
        public int Speed { get; private set; }
        public double Score { get; private set; }
        public GameStatus Status { get; private set; }
        public Direction MoveDirection { get; set; }     
        
        #endregion

        #region Constructor

        public Game(IGameSettings gameSettings, IRandomGenerator randomGenerator)
        {       
            this._gameSettings = gameSettings;
            this._randomGenerator = randomGenerator;
            this._playerSnake = new Snake(gameSettings);
            this.Status = GameStatus.ReadyToStart;
            this.Score = gameSettings.GameScore;
            this.Speed = gameSettings.GameSpeed;
            this.MoveDirection = gameSettings.GameMoveDirection;
            this.EmptyField = new List<Point>();                   
            this._point = this._playerSnake.Head;
            this._counter = Count;
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

            this.EmptyField.Add(this._playerSnake.RemoveTail());
           
            if (this.MoveDirection == Direction.Left)
            {
                this._point = new Point(this._point.X - 1, this._point.Y);
            }
            else if (this.MoveDirection == Direction.Right)
            {
                this._point = new Point(this._point.X + 1, this._point.Y);
            }
            else if (this.MoveDirection == Direction.Up)
            {
                this._point = new Point(this._point.X, this._point.Y - 1);
            }
            else if (this.MoveDirection == Direction.Down)
            {
                this._point = new Point(this._point.X, this._point.Y + 1);
            }
           
            this._playerSnake.AddHead(this._point);
            MoveCheck();
            Eat();
        }                       

        #endregion

        #region Private Methods

        private void MoveCheck()
        {
            // Detect collisions with game's borders
            CheckBordersCollisions();
            // Detect colisions with Body
            CheckBodyCollisions();
            // Detect collision with empty field
            CheckEmptyFieldCollisions();
        }

        private void CheckEmptyFieldCollisions()
        {            
            if (this.EmptyField.Count(point => this.Head == point) != 0)
            {
                Stop();
            }
        }

        private void CheckBodyCollisions()
        {
            if (this._playerSnake.CheckingCollisions(this.Head,1))
            {
                Stop();
            }           
        }

        private void CheckBordersCollisions()
        {
            if ((this.Head.X < 0) ||
                (this.Head.Y < 0) ||
                (this.Head.X >= this._gameSettings.GameBoardWidth) ||
                (this.Head.Y >= this._gameSettings.GameBoardHeight))
            {
                Stop();
            }
        }

        private void Eat()
        {
            if (this.Head == this.Food)
            {
                EatBigFood();
            }
            else
            {
                this.Score += Coins;
            }
            UpdateSpeed();
        }

        private void UpdateSpeed()
        {
            if (this.Score > this._counter)
            {
                this._counter += Count;
                if (this.Speed >= SpeedLimit)
                {
                    this.Speed -= SpeedUpper;
                }
            }
        }

        private void EatBigFood()
        {
            this._playerSnake.AddToBody();
            // Update Score
            this.Score += this._gameSettings.GamePoints;
            GenerateFood();
        }

        private void GenerateFood()
        {          
            Point genPoint;
            do
            {
                genPoint = _randomGenerator.Generate();
                if (EmptyField.Count(point => point == genPoint) == 0)
                {
                    if (!_playerSnake.CheckingCollisions(genPoint, 0))
                    {
                        Food = genPoint;
                    }
                }
            } while (Food != genPoint);          
        }  

        #endregion
    }
}
