
namespace Space_Shooter
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
            this.pbPlayer = new System.Windows.Forms.PictureBox();
            this.TimeGameLoop = new System.Windows.Forms.Timer(this.components);
            this.pbPlayerHealth = new System.Windows.Forms.ProgressBar();
            this.lblScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // pbPlayer
            // 
            this.pbPlayer.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayer.Image = global::Space_Shooter.Properties.Resources.playerShip1_blue;
            this.pbPlayer.Location = new System.Drawing.Point(335, 314);
            this.pbPlayer.Name = "pbPlayer";
            this.pbPlayer.Size = new System.Drawing.Size(99, 75);
            this.pbPlayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPlayer.TabIndex = 0;
            this.pbPlayer.TabStop = false;
            // 
            // TimeGameLoop
            // 
            this.TimeGameLoop.Enabled = true;
            this.TimeGameLoop.Tick += new System.EventHandler(this.TimeGameLoop_Tick);
            // 
            // pbPlayerHealth
            // 
            this.pbPlayerHealth.Location = new System.Drawing.Point(334, 405);
            this.pbPlayerHealth.Name = "pbPlayerHealth";
            this.pbPlayerHealth.Size = new System.Drawing.Size(100, 10);
            this.pbPlayerHealth.TabIndex = 1;
            this.pbPlayerHealth.Value = 50;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.lblScore.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblScore.Location = new System.Drawing.Point(688, 405);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(81, 29);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Space_Shooter.Properties.Resources.blue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.pbPlayerHealth);
            this.Controls.Add(this.pbPlayer);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPlayer;
        private System.Windows.Forms.Timer TimeGameLoop;
        private System.Windows.Forms.ProgressBar pbPlayerHealth;
        private System.Windows.Forms.Label lblScore;
    }
}

