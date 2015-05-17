using System.Windows.Forms;
using SnakeDefender.GameEngine.GameObject;
using SnakeDefender.Helpers;

namespace SnakeDefender.DesktopUI.Controls
{
    partial class MenuControl
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
            this.exit_but = new System.Windows.Forms.PictureBox();
            this.results_but = new System.Windows.Forms.PictureBox();
            this.instruct_but = new System.Windows.Forms.PictureBox();
            this.play_but = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exit_but)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.results_but)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.instruct_but)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.play_but)).BeginInit();
            this.SuspendLayout();
            // 
            // exit_but
            // 
            this.exit_but.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exit_but.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Exit_1;
            this.exit_but.Location = new System.Drawing.Point(217, 262);
            this.exit_but.Name = "exit_but";
            this.exit_but.Size = new System.Drawing.Size(89, 41);
            this.exit_but.TabIndex = 4;
            this.exit_but.TabStop = false;
            this.exit_but.Click += new System.EventHandler(this.exit_but_Click);
            this.exit_but.MouseEnter += new System.EventHandler(this.exit_but_MouseEnter);
            this.exit_but.MouseLeave += new System.EventHandler(this.exit_but_MouseLeave);
            // 
            // results_but
            // 
            this.results_but.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.results_but.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Hisgh_scores_1;
            this.results_but.Location = new System.Drawing.Point(212, 203);
            this.results_but.Name = "results_but";
            this.results_but.Size = new System.Drawing.Size(275, 41);
            this.results_but.TabIndex = 3;
            this.results_but.TabStop = false;
            this.results_but.Click += new System.EventHandler(this.results_but_Click);
            this.results_but.MouseEnter += new System.EventHandler(this.results_but_MouseEnter);
            this.results_but.MouseLeave += new System.EventHandler(this.results_but_MouseLeave);
            // 
            // instruct_but
            // 
            this.instruct_but.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.instruct_but.Image = global::SnakeDefender.DesktopUI.Properties.Resources.How_to_play_1;
            this.instruct_but.Location = new System.Drawing.Point(212, 143);
            this.instruct_but.Name = "instruct_but";
            this.instruct_but.Size = new System.Drawing.Size(282, 44);
            this.instruct_but.TabIndex = 2;
            this.instruct_but.TabStop = false;
            this.instruct_but.Click += new System.EventHandler(this.instruct_but_Click);
            this.instruct_but.MouseEnter += new System.EventHandler(this.instruct_but_MouseEnter);
            this.instruct_but.MouseLeave += new System.EventHandler(this.instruct_but_MouseLeave);
            // 
            // play_but
            // 
            this.play_but.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.play_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.play_but.Image = global::SnakeDefender.DesktopUI.Properties.Resources.play_1;
            this.play_but.Location = new System.Drawing.Point(217, 82);
            this.play_but.Name = "play_but";
            this.play_but.Size = new System.Drawing.Size(104, 43);
            this.play_but.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.play_but.TabIndex = 1;
            this.play_but.TabStop = false;
            this.play_but.Click += new System.EventHandler(this.play_but_Click);
            this.play_but.MouseEnter += new System.EventHandler(this.play_but_MouseEnter);
            this.play_but.MouseLeave += new System.EventHandler(this.play_but_MouseLeave);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SnakeDefender.DesktopUI.Properties.Resources.snake;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.exit_but);
            this.Controls.Add(this.results_but);
            this.Controls.Add(this.instruct_but);
            this.Controls.Add(this.play_but);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(500, 500);
            this.Load += new System.EventHandler(this.MenuControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.exit_but)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.results_but)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.instruct_but)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.play_but)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox play_but;
        private System.Windows.Forms.PictureBox instruct_but;
        private System.Windows.Forms.PictureBox results_but;
        private System.Windows.Forms.PictureBox exit_but;
        private Form _parentForm;
    }
}
