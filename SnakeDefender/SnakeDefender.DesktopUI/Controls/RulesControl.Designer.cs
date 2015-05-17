using System.Windows.Forms;

namespace SnakeDefender.DesktopUI.Controls
{
    partial class RulesControl
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
            this.pbMenu = new System.Windows.Forms.PictureBox();
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.pbRules = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRules)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMenu
            // 
            this.pbMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbMenu.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Menu1;
            this.pbMenu.Location = new System.Drawing.Point(235, 395);
            this.pbMenu.Name = "pbMenu";
            this.pbMenu.Size = new System.Drawing.Size(100, 50);
            this.pbMenu.TabIndex = 1;
            this.pbMenu.TabStop = false;
            this.pbMenu.Click += new System.EventHandler(this.pbMenu_Click);
            this.pbMenu.MouseEnter += new System.EventHandler(this.pbMenu_MouseEnter);
            this.pbMenu.MouseLeave += new System.EventHandler(this.pbMenu_MouseLeave);
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbTitle.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Title;
            this.pbTitle.Location = new System.Drawing.Point(35, 16);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(516, 61);
            this.pbTitle.TabIndex = 0;
            this.pbTitle.TabStop = false;
            // 
            // pbRules
            // 
            this.pbRules.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbRules.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Rules;
            this.pbRules.Location = new System.Drawing.Point(16, 83);
            this.pbRules.Name = "pbRules";
            this.pbRules.Size = new System.Drawing.Size(558, 281);
            this.pbRules.TabIndex = 2;
            this.pbRules.TabStop = false;
            // 
            // RulesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbRules);
            this.Controls.Add(this.pbMenu);
            this.Controls.Add(this.pbTitle);
            this.Name = "RulesControl";
            this.Size = new System.Drawing.Size(589, 448);
            this.Load += new System.EventHandler(this.RulesControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRules)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTitle;
        private System.Windows.Forms.PictureBox pbMenu;
        private Form _parentForm;
        private PictureBox pbRules;
    }
}
