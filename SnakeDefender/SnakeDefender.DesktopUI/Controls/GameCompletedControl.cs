using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeDefender.GameEngine.GameObject;
using SnakeDefender.Helpers;

namespace SnakeDefender.DesktopUI.Controls
{
    public partial class GameCompletedControl : UserControl
    {
        private ResultAnalysis _resultsAnalysis;
        private int _result;
        public GameCompletedControl(Form parentForm, int score)
        {
            InitializeComponent();
            _parentForm = parentForm;            
            _resultsAnalysis = new ResultAnalysis(MainForm.gameSettings);
            _result = score;
        }

        private void GameCompletedControl_Load(object sender, EventArgs e)
        {
            CheckResult(_result);
            lblScore.Text = _result.ToString();
        }

        private void CheckResult(int score)
        {
            if (_resultsAnalysis.CheckResult(score))
            {
                pnlRecord.Visible = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _resultsAnalysis.AddScore(_result, tbName.Text);
            pnlRecord.Visible = false;

        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            this._parentForm.Controls.Clear();
            this._parentForm.Controls.Add(new GameplayControl(_parentForm));
        }

        private void btnRetry_MouseEnter(object sender, EventArgs e)
        {
            this.btnRetry.Image = Properties.Resources.Retry2;
        }

        private void btnRetry_MouseLeave(object sender, EventArgs e)
        {
            this.btnRetry.Image = Properties.Resources.Retry1;
        }

        private void btnMenu_MouseEnter(object sender, EventArgs e)
        {
            this.btnMenu.Image = Properties.Resources.Menu2;
        }

        private void btnMenu_MouseLeave(object sender, EventArgs e)
        {
            this.btnMenu.Image = Properties.Resources.Menu1;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this._parentForm.Controls.Clear();
            this._parentForm.Controls.Add(new MenuControl(_parentForm));           
        }
    }
}
