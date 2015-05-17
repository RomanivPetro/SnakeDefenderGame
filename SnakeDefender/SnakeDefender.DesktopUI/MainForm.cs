using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeDefender.DesktopUI.Controls;
using SnakeDefender.Helpers;

namespace SnakeDefender.DesktopUI
{
    public partial class MainForm : Form
    {
        #region Constructors

        public MainForm()
        {
            InitializeComponent();
            
        }

        static MainForm()
        {
            gameSettings = new GameSettings();
            gameSettings.ReadFromConfig();
            randomGenerator = new RandomGenerator(gameSettings.GameBoardWidth, gameSettings.GameBoardHeight);
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
           ShowMenuControl();         
        }

        public void ShowMenuControl()
        {           
            var menuControl = new MenuControl(this);            
            this.Controls.Add(menuControl);            
        }
           
    }
}
