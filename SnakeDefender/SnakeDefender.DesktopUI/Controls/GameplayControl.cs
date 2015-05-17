using System;
using System.Windows.Forms;
using SnakeDefender.GameEngine;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.DesktopUI.Controls
{
    public partial class GameplayControl : UserControl
    {
        public GameplayControl(Form parent)
        {
            InitializeComponent();            
            this._pause = new bool();
            _parentForm = parent;
            _parentForm.KeyPreview = true;
            this._game = new Game(MainForm.gameSettings, MainForm.randomGenerator);
            this._gameDirection = MainForm.gameSettings.GameMoveDirection;
            Drawing.InitDrawing(gamefield, MainForm.gameSettings);                     
        }

        private void GameplayControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
            InitKeyPress(sender,e);           
            gamefield.Paint += DrawGame;
            this._game.Start();
            this._gameTimer = new Timer();
            this._gameTimer.Interval = this._game.Speed;
            this._gameTimer.Tick += RunningGame;
            this._gameTimer.Start();
            this.gamefield.Focus();
        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Drawing.DrawGame(_game, sender, e);
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
                case Keys.P:
                    Pause();
                    break;
                default:
                    break;
            }
        }

        private void Pause()
        {
            if (_pause)
            {
                this._gameTimer.Start();
                this._pause = false;
                this.lblPause.Visible = false;
            }
            else
            {
                this._gameTimer.Stop();               
                this._pause = true;
                this.lblPause.Visible = true;
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
                this._game.MoveDirection = _gameDirection;
                this._game.Move();
                RefreshMap();          
                this._gameTimer.Interval = this._game.Speed;
            }
            else
            {
                _gameTimer.Stop();
                _gameTimer.Dispose();
                GameCompleted();                              
            }
        }

        private void MoveDown()
        {
            if (this._game.MoveDirection != Direction.Up)
            {               
                this._gameDirection = Direction.Down;
            }
        }

        private void MoveUp()
        {
            if (this._game.MoveDirection != Direction.Down)
            {               
                this._gameDirection = Direction.Up;
            }
        }

        private void MoveLeft()
        {
            if (this._game.MoveDirection != Direction.Right)
            {              
                this._gameDirection = Direction.Left;
            }
        }

        private void MoveRight()
        {
            if (this._game.MoveDirection != Direction.Left)
            {               
                this._gameDirection = Direction.Right;
            }
        }

        private void RefreshMap()
        {
            lblScore.Text = ((int)_game.Score).ToString(); 
            Refresh();                    
        }

        private void GameCompleted()
        {
            _parentForm.Controls.Clear();                              
            _parentForm.Controls.Add(new GameCompletedControl(_parentForm, (int)_game.Score));
            _parentForm.KeyDown -= GameplayControlKeyDown;           
        }
       
    }
}
