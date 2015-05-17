namespace SnakeDefender.DesktopUI.Controls
{
    partial class ResultsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pctMenu = new System.Windows.Forms.PictureBox();
            this.pbTopTitle = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbTitle.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Title;
            this.pbTitle.Location = new System.Drawing.Point(14, 16);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(520, 64);
            this.pbTitle.TabIndex = 1;
            this.pbTitle.TabStop = false;
            // 
            // pctMenu
            // 
            this.pctMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pctMenu.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Menu1;
            this.pctMenu.Location = new System.Drawing.Point(217, 445);
            this.pctMenu.Name = "pctMenu";
            this.pctMenu.Size = new System.Drawing.Size(86, 35);
            this.pctMenu.TabIndex = 0;
            this.pctMenu.TabStop = false;
            this.pctMenu.Click += new System.EventHandler(this.pctMenu_Click);
            this.pctMenu.MouseEnter += new System.EventHandler(this.pctMenu_MouseEnter);
            this.pctMenu.MouseLeave += new System.EventHandler(this.pctMenu_MouseLeave);
            // 
            // pbTopTitle
            // 
            this.pbTopTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbTopTitle.Image = global::SnakeDefender.DesktopUI.Properties.Resources.TopScores;
            this.pbTopTitle.Location = new System.Drawing.Point(69, 86);
            this.pbTopTitle.Name = "pbTopTitle";
            this.pbTopTitle.Size = new System.Drawing.Size(398, 56);
            this.pbTopTitle.TabIndex = 2;
            this.pbTopTitle.TabStop = false;
            // 
            // ResultsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbTopTitle);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.pctMenu);
            this.Name = "ResultsControl";
            this.Size = new System.Drawing.Size(550, 550);
            this.Load += new System.EventHandler(this.ResultsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTopTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctMenu;
        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.PictureBox pbTopTitle;



    }
}
