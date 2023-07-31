
namespace Space_Shooter
{
    partial class frmGameEnd
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdRestart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ravie", 38.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(205, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over";
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.Color.Black;
            this.cmdExit.Font = new System.Drawing.Font("Ravie", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdExit.Location = new System.Drawing.Point(112, 268);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmdExit.Size = new System.Drawing.Size(147, 67);
            this.cmdExit.TabIndex = 1;
            this.cmdExit.Text = "Exit";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdRestart
            // 
            this.cmdRestart.BackColor = System.Drawing.Color.Black;
            this.cmdRestart.Font = new System.Drawing.Font("Ravie", 20.25F);
            this.cmdRestart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdRestart.Location = new System.Drawing.Point(516, 268);
            this.cmdRestart.Name = "cmdRestart";
            this.cmdRestart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmdRestart.Size = new System.Drawing.Size(183, 67);
            this.cmdRestart.TabIndex = 2;
            this.cmdRestart.Text = "Restart";
            this.cmdRestart.UseVisualStyleBackColor = false;
            this.cmdRestart.Click += new System.EventHandler(this.cmdRestart_Click);
            // 
            // frmGameEnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Space_Shooter.Properties.Resources.blue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmdRestart);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.label1);
            this.Name = "frmGameEnd";
            this.Text = "frmGameEnd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdRestart;
    }
}