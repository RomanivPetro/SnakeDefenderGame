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
            this.pctMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pctMenu
            // 
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
            // ResultsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pctMenu);
            this.Name = "ResultsControl";
            this.Size = new System.Drawing.Size(550, 550);
            ((System.ComponentModel.ISupportInitialize)(this.pctMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctMenu;



    }
}
