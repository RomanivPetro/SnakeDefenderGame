using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnakeDefender.Helpers;

namespace SnakeDefender.DesktopUI.Controls
{
    public partial class ResultsControl : UserControl
    {
        private int _counter;
        private Form _parentForm;
        private ListView _lwTable;
   
        public ResultsControl( Form parentForm)
        {           
            InitializeComponent();
            _parentForm = parentForm;
            _lwTable = new ListView();
            _counter = 0;
            ShowBestResults();
        }

        private void InitListView()
        {          
            _lwTable.Bounds = new Rectangle(new Point(120, 150), new Size(300, 200));
            _lwTable.LabelEdit = false;
            _lwTable.AllowColumnReorder = false;                      
            _lwTable.View = View.Details;
            _lwTable.GridLines = true;
            _lwTable.FullRowSelect = true;
            _lwTable.Columns.Add("№", -2, HorizontalAlignment.Left);       
            _lwTable.Columns.Add("Name", -2, HorizontalAlignment.Left);
            _lwTable.Columns.Add("Result", -2, HorizontalAlignment.Left);
            this.Controls.Add(_lwTable);                                                   
        }

        private void ShowBestResults()
        {
            InitListView();
            var resultAnalisis = new ResultAnalysis(MainForm.gameSettings);
            resultAnalisis.RaiseMyEvent += Show;
            resultAnalisis.CheckResult(0);
            resultAnalisis.ShowResults();
        }

        public void Show(object sender, ResultsHolder e)
        {
            _counter++;
            _lwTable.Items.Add(new ListViewItem(new[] {_counter.ToString(), e.Name, e.Score.ToString()}));
        }

        private void pctMenu_MouseEnter(object sender, EventArgs e)
        {
            this.pctMenu.Image = Properties.Resources.Menu2;
        }

        private void pctMenu_MouseLeave(object sender, EventArgs e)
        {
            this.pctMenu.Image = Properties.Resources.Menu1;
        }

        private void pctMenu_Click(object sender, EventArgs e)
        {
            this._parentForm.Controls.Clear();
            this._parentForm.Controls.Add(new MenuControl(_parentForm));    
        }
    }
}
