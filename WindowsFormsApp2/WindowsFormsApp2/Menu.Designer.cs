namespace WindowsFormsApp2
{
    partial class Menu
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
            this.btnProgress = new System.Windows.Forms.Button();
            this.btnGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProgress
            // 
            this.btnProgress.Location = new System.Drawing.Point(208, 169);
            this.btnProgress.Name = "btnProgress";
            this.btnProgress.Size = new System.Drawing.Size(145, 118);
            this.btnProgress.TabIndex = 0;
            this.btnProgress.Text = "PROGRESO";
            this.btnProgress.UseVisualStyleBackColor = true;
            this.btnProgress.Click += new System.EventHandler(this.BtnProgress_Click);
            // 
            // btnGame
            // 
            this.btnGame.Location = new System.Drawing.Point(449, 169);
            this.btnGame.Name = "btnGame";
            this.btnGame.Size = new System.Drawing.Size(145, 118);
            this.btnGame.TabIndex = 1;
            this.btnGame.Text = "JUEGO";
            this.btnGame.UseVisualStyleBackColor = true;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGame);
            this.Controls.Add(this.btnProgress);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProgress;
        private System.Windows.Forms.Button btnGame;
    }
}