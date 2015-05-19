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
            this.pbTitle = new System.Windows.Forms.PictureBox();
            this.lblPause = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gamefield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // gamefield
            // 
            this.gamefield.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gamefield.BackColor = System.Drawing.Color.White;
            this.gamefield.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gamefield.Location = new System.Drawing.Point(12, 61);
            this.gamefield.Name = "gamefield";
            this.gamefield.Size = new System.Drawing.Size(665, 485);
            this.gamefield.TabIndex = 0;
            this.gamefield.TabStop = false;
            // 
            // lblScore
            // 
            this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.White;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblScore.Location = new System.Drawing.Point(615, 15);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 46);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "S";
            // 
            // pbTitle
            // 
            this.pbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbTitle.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Title;
            this.pbTitle.Location = new System.Drawing.Point(5, 2);
            this.pbTitle.Name = "pbTitle";
            this.pbTitle.Size = new System.Drawing.Size(523, 59);
            this.pbTitle.TabIndex = 2;
            this.pbTitle.TabStop = false;
            // 
            // lblPause
            // 
            this.lblPause.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPause.AutoSize = true;
            this.lblPause.BackColor = System.Drawing.Color.White;
            this.lblPause.CausesValidation = false;
            this.lblPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblPause.Location = new System.Drawing.Point(534, 12);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(162, 46);
            this.lblPause.TabIndex = 3;
            this.lblPause.Text = "PAUSE";
            this.lblPause.Visible = false;
            // 
            // GameplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPause);
            this.Controls.Add(this.pbTitle);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.gamefield);
            this.Name = "GameplayControl";
            this.Size = new System.Drawing.Size(690, 573);
            this.Load += new System.EventHandler(this.GameplayControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gamefield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTitle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox gamefield;
        private System.Windows.Forms.Label lblScore;
        private Game _game;
        private Timer _gameTimer;                
        private Form _parentForm;
        private bool _pause;
        private PictureBox pbTitle;
        private Label lblPause;
        private Direction _gameDirection;


    }
}
