
namespace Pacman_Real
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.lblScore = new System.Windows.Forms.Label();
            this.numScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TimeGameLoop
            // 
            this.TimeGameLoop.Enabled = true;
            this.TimeGameLoop.Interval = 90;
            this.TimeGameLoop.Tick += new System.EventHandler(this.TimeGameLoop_Tick);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblScore.Location = new System.Drawing.Point(34, 591);
            this.lblScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(125, 57);
            this.lblScore.TabIndex = 0;
            this.lblScore.Text = "Score: ";
            // 
            // numScore
            // 
            this.numScore.AutoSize = true;
            this.numScore.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numScore.ForeColor = System.Drawing.SystemColors.Control;
            this.numScore.Location = new System.Drawing.Point(136, 591);
            this.numScore.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.numScore.Name = "numScore";
            this.numScore.Size = new System.Drawing.Size(0, 57);
            this.numScore.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1350, 677);
            this.Controls.Add(this.numScore);
            this.Controls.Add(this.lblScore);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TimeGameLoop;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label numScore;
    }
}

