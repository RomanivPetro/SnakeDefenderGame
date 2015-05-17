using System;
using System.Windows.Forms;

namespace SnakeDefender.DesktopUI.Controls
{
    public partial class MenuControl : UserControl
    {
                
        public MenuControl(Form parent)
        {
            InitializeComponent();
            this._parentForm = parent;           
        }
       
        #region Events

        private void play_but_MouseEnter(object sender, EventArgs e)
        {
            this.play_but.Image = Properties.Resources.play_2;
        }

        private void instruct_but_MouseEnter(object sender, EventArgs e)
        {
            this.instruct_but.Image = Properties.Resources.How_to_play_2;
        }

        private void results_but_MouseEnter(object sender, EventArgs e)
        {
            this.results_but.Image = Properties.Resources.Hisgh_scores_2;
        }

        private void exit_but_MouseEnter(object sender, EventArgs e)
        {
            this.exit_but.Image = Properties.Resources.Exit_2;
        }

        private void play_but_MouseLeave(object sender, EventArgs e)
        {
            this.play_but.Image = Properties.Resources.play_1;
        }

        private void instruct_but_MouseLeave(object sender, EventArgs e)
        {
            this.instruct_but.Image = Properties.Resources.How_to_play_1;
        }

        private void results_but_MouseLeave(object sender, EventArgs e)
        {
            this.results_but.Image = Properties.Resources.Hisgh_scores_1;
        }

        private void exit_but_MouseLeave(object sender, EventArgs e)
        {
            this.exit_but.Image = Properties.Resources.Exit_1;
        }

        private void exit_but_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }       

        private void play_but_Click(object sender, EventArgs e)
        {
            ChangeControl(new GameplayControl(_parentForm)); ;                                 
        }

        private void instruct_but_Click(object sender, EventArgs e)
        {
            ChangeControl(new RulesControl(_parentForm));         
        }

        private void results_but_Click(object sender, EventArgs e)
        {
            ChangeControl(new ResultsControl(_parentForm));          
        }

    #endregion

        private void ChangeControl(Control control)
        {
            _parentForm.Controls.Clear();
            _parentForm.Controls.Add((control));            
        }

        private void MenuControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }
    }
}
