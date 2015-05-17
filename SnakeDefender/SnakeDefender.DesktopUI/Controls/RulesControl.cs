using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeDefender.DesktopUI.Controls
{
    public partial class RulesControl : UserControl
    {
        public RulesControl(Form parent)
        {
            InitializeComponent();
            this._parentForm = parent;
        }

        private void RulesControl_Load(object sender, EventArgs e)
        {
            this.Dock = DockStyle.Fill;
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            this._parentForm.Controls.Clear();
            this._parentForm.Controls.Add(new MenuControl(_parentForm)); 
        }

        private void pbMenu_MouseEnter(object sender, EventArgs e)
        {
            this.pbMenu.Image = Properties.Resources.Menu2;
        }

        private void pbMenu_MouseLeave(object sender, EventArgs e)
        {
            this.pbMenu.Image = Properties.Resources.Menu1;
        }
    }
}
