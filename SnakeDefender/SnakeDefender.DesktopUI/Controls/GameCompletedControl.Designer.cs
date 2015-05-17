using System.Windows.Forms;
using SnakeDefender.GameEngine.GameObject;

namespace SnakeDefender.DesktopUI.Controls
{
    partial class GameCompletedControl
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
            this.lblScore = new System.Windows.Forms.Label();
            this.pnlRecord = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.btnRetry = new System.Windows.Forms.PictureBox();
            this.imgScore = new System.Windows.Forms.PictureBox();
            this.imgGameOver = new System.Windows.Forms.PictureBox();
            this.pnlRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGameOver)).BeginInit();
            this.SuspendLayout();
            // 
            // lblScore
            // 
            this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblScore.ForeColor = System.Drawing.Color.Lime;
            this.lblScore.Location = new System.Drawing.Point(130, 130);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(55, 39);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "25";
            // 
            // pnlRecord
            // 
            this.pnlRecord.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlRecord.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlRecord.Controls.Add(this.pictureBox1);
            this.pnlRecord.Controls.Add(this.btnOk);
            this.pnlRecord.Controls.Add(this.tbName);
            this.pnlRecord.Location = new System.Drawing.Point(20, 191);
            this.pnlRecord.Name = "pnlRecord";
            this.pnlRecord.Size = new System.Drawing.Size(290, 152);
            this.pnlRecord.TabIndex = 6;
            this.pnlRecord.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SnakeDefender.DesktopUI.Properties.Resources.RecordTitle;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 68);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Lime;
            this.btnOk.Location = new System.Drawing.Point(107, 117);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(92, 91);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(105, 20);
            this.tbName.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnMenu.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Menu1;
            this.btnMenu.Location = new System.Drawing.Point(114, 412);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(90, 43);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            this.btnMenu.MouseEnter += new System.EventHandler(this.btnMenu_MouseEnter);
            this.btnMenu.MouseLeave += new System.EventHandler(this.btnMenu_MouseLeave);
            // 
            // btnRetry
            // 
            this.btnRetry.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRetry.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Retry1;
            this.btnRetry.Location = new System.Drawing.Point(110, 360);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(100, 37);
            this.btnRetry.TabIndex = 4;
            this.btnRetry.TabStop = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            this.btnRetry.MouseEnter += new System.EventHandler(this.btnRetry_MouseEnter);
            this.btnRetry.MouseLeave += new System.EventHandler(this.btnRetry_MouseLeave);
            // 
            // imgScore
            // 
            this.imgScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgScore.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Score_title;
            this.imgScore.Location = new System.Drawing.Point(50, 64);
            this.imgScore.Name = "imgScore";
            this.imgScore.Size = new System.Drawing.Size(229, 50);
            this.imgScore.TabIndex = 3;
            this.imgScore.TabStop = false;
            // 
            // imgGameOver
            // 
            this.imgGameOver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imgGameOver.Image = global::SnakeDefender.DesktopUI.Properties.Resources.Game_over;
            this.imgGameOver.Location = new System.Drawing.Point(20, 8);
            this.imgGameOver.Name = "imgGameOver";
            this.imgGameOver.Size = new System.Drawing.Size(290, 50);
            this.imgGameOver.TabIndex = 2;
            this.imgGameOver.TabStop = false;
            // 
            // GameCompletedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlRecord);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.imgScore);
            this.Controls.Add(this.imgGameOver);
            this.Controls.Add(this.lblScore);
            this.Name = "GameCompletedControl";
            this.Size = new System.Drawing.Size(335, 487);
            this.Load += new System.EventHandler(this.GameCompletedControl_Load);
            this.pnlRecord.ResumeLayout(false);
            this.pnlRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgGameOver)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox imgGameOver;
        private System.Windows.Forms.PictureBox imgScore;
        private System.Windows.Forms.PictureBox btnRetry;
        private System.Windows.Forms.PictureBox btnMenu;
        private System.Windows.Forms.Panel pnlRecord;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbName;

        private Form _parentForm;        
    }
}
