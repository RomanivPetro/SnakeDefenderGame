using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeDefender.GameEngine;
using SnakeDefender.DesktopUI.Controls;
using SnakeDefender.GameEngine.GameObject;
using SnakeDefender.Helpers;
using Point = System.Drawing.Point;


namespace SnakeDefender.DesktopUI.Controls
{
    public partial class GameplayControl : UserControl
    {
        public GameplayControl(Form parent)
        {
            InitializeComponent();
            _parentForm = parent;
            _parentForm.KeyPreview = true;
            this._game = new Game(MainForm.gameSettings, MainForm.randomGenerator);           
            Drawing.InitDrawing(gamefield, MainForm.gameSettings);                     
        }

        private void GameplayControl_Load(object sender, EventArgs e)
        {
            InitKeyPress(sender,e);
            gamefield.Paint += DrawField;
            gamefield.Paint += DrawGame;
            this._game.Start();
            this._gameTimer = new Timer();
            this._gameTimer.Interval = this._game.Speed;
            this._gameTimer.Tick += RunningGame;
            this._gameTimer.Start();          
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Drawing.DrawGame(_game, sender, e);
        }

        protected void DrawField(object sender, PaintEventArgs e)
        {
            Drawing.DrawField(_game, e);
            gamefield.Paint -= DrawField;
        }

        private void GameplayControlKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.S:
                    MoveDown();
                    break;
                case Keys.W:
                    MoveUp();
                    break;
                case Keys.A:
                    MoveLeft();
                    break;
                case Keys.D:
                    MoveRight();
                    break;
                default:
                    break;
            }
        }

        private void InitKeyPress(object sender, EventArgs e)
        {
            _parentForm.KeyPreview = true;
            _parentForm.KeyDown += GameplayControlKeyDown;            
        }

        private void RunningGame(object sender, EventArgs e)
        {
            if (this._game.Status != GameStatus.Completed)
            {
                this._game.Move();
                RefreshMap();
           // }
           // if (this._game.Status != GameStatus.Completed)
           // {
               // RefreshMap();
                this._gameTimer.Interval = this._game.Speed;
            }
            else
            {
                GameCompleted();               
                _gameTimer.Stop();
                _gameTimer.Dispose();
            }
        }

        private void MoveDown()
        {
            if (this._game.MoveDirection != Direction.Up)
            {
                this._game.MoveDirection = Direction.Down;
            }
        }

        private void MoveUp()
        {
            if (this._game.MoveDirection != Direction.Down)
            {
                this._game.MoveDirection = Direction.Up;
            }
        }

        private void MoveLeft()
        {
            if (this._game.MoveDirection != Direction.Right)
            {
                this._game.MoveDirection = Direction.Left;
            }
        }

        private void MoveRight()
        {
            if (this._game.MoveDirection != Direction.Left)
            {
                this._game.MoveDirection = Direction.Right;
            }
        }

        private void RefreshMap()
        {
            lblScore.Text = ((int)_game.Score).ToString(); 
            gamefield.Invalidate(Drawing.DrawingRectangle(_game.Head));
            gamefield.Invalidate(Drawing.DrawingRectangle(_game.Tail));          
            gamefield.Invalidate(Drawing.DrawingRectangle(_game.Food));           
        }

        private void GameCompleted()
        {
            _parentForm.Controls.Clear();
            //_parentForm.Controls.Add(new MenuControl(_parentForm));            
            _parentForm.Controls.Add(new GameCompletedControl(_parentForm, (int)_game.Score));                       
        }
       
    }
}
