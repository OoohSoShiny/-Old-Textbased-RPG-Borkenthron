
namespace TextRPG_Borkenthron
{
    partial class MainFrame
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
            this.picBNewGame = new System.Windows.Forms.PictureBox();
            this.picBLoadGame = new System.Windows.Forms.PictureBox();
            this.picBLeaveGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLoadGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLeaveGame)).BeginInit();
            this.SuspendLayout();
            // 
            // picBNewGame
            // 
            this.picBNewGame.Location = new System.Drawing.Point(13, 13);
            this.picBNewGame.Name = "picBNewGame";
            this.picBNewGame.Size = new System.Drawing.Size(259, 50);
            this.picBNewGame.TabIndex = 0;
            this.picBNewGame.TabStop = false;
            this.picBNewGame.Click += new System.EventHandler(this.picBNewGame_Click);
            // 
            // picBLoadGame
            // 
            this.picBLoadGame.Location = new System.Drawing.Point(13, 84);
            this.picBLoadGame.Name = "picBLoadGame";
            this.picBLoadGame.Size = new System.Drawing.Size(259, 50);
            this.picBLoadGame.TabIndex = 1;
            this.picBLoadGame.TabStop = false;
            // 
            // picBLeaveGame
            // 
            this.picBLeaveGame.Location = new System.Drawing.Point(12, 157);
            this.picBLeaveGame.Name = "picBLeaveGame";
            this.picBLeaveGame.Size = new System.Drawing.Size(259, 50);
            this.picBLeaveGame.TabIndex = 2;
            this.picBLeaveGame.TabStop = false;
            this.picBLeaveGame.Click += new System.EventHandler(this.picBLeaveGame_Click);
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 219);
            this.ControlBox = false;
            this.Controls.Add(this.picBLeaveGame);
            this.Controls.Add(this.picBLoadGame);
            this.Controls.Add(this.picBNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menü";
            ((System.ComponentModel.ISupportInitialize)(this.picBNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLoadGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLeaveGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBNewGame;
        private System.Windows.Forms.PictureBox picBLoadGame;
        private System.Windows.Forms.PictureBox picBLeaveGame;
    }
}

