using System.Windows.Forms;
using SnakeDefender.GameEngine;
using SnakeDefender.GameEngine.GameObject;
using SnakeDefender.Helpers;

namespace SnakeDefender.DesktopUI.Controls
{
    partial class GameplayControl
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
            this.gamefield = new System.Windows.Forms.PictureBox();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamefield)).BeginInit();
            this.SuspendLayout();
            // 
            // gamefield
            // 
            this.gamefield.BackColor = System.Drawing.Color.Gray;
            this.gamefield.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gamefield.Location = new System.Drawing.Point(12, 106);
            this.gamefield.Name = "gamefield";
            this.gamefield.Size = new System.Drawing.Size(665, 485);
            this.gamefield.TabIndex = 0;
            this.gamefield.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblScore.Location = new System.Drawing.Point(551, 57);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(126, 46);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "Score";
            // 
            // GameplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.gamefield);
            this.Name = "GameplayControl";
            this.Size = new System.Drawing.Size(690, 690);
            this.Load += new System.EventHandler(this.GameplayControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gamefield)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamefield;
        private System.Windows.Forms.Label lblScore;
        private Game _game;
        private Timer _gameTimer;                
        private Form _parentForm;


    }
}
