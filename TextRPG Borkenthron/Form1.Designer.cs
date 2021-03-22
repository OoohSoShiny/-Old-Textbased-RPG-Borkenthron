
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
            this.picBLoadGame = new System.Windows.Forms.PictureBox();
            this.picBLeaveGame = new System.Windows.Forms.PictureBox();
            this.picBStartGame = new System.Windows.Forms.PictureBox();
            this.picBNamePlate = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBLoadGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLeaveGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBStartGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBNamePlate)).BeginInit();
            this.SuspendLayout();
            // 
            // picBLoadGame
            // 
            this.picBLoadGame.Location = new System.Drawing.Point(9, 139);
            this.picBLoadGame.Name = "picBLoadGame";
            this.picBLoadGame.Size = new System.Drawing.Size(259, 50);
            this.picBLoadGame.TabIndex = 0;
            this.picBLoadGame.TabStop = false;
            this.picBLoadGame.Click += new System.EventHandler(this.picBLoadGame_Click);
            // 
            // picBLeaveGame
            // 
            this.picBLeaveGame.Location = new System.Drawing.Point(9, 210);
            this.picBLeaveGame.Name = "picBLeaveGame";
            this.picBLeaveGame.Size = new System.Drawing.Size(259, 45);
            this.picBLeaveGame.TabIndex = 1;
            this.picBLeaveGame.TabStop = false;
            this.picBLeaveGame.Click += new System.EventHandler(this.picBLeaveGame_Click);
            // 
            // picBStartGame
            // 
            this.picBStartGame.Location = new System.Drawing.Point(9, 73);
            this.picBStartGame.Name = "picBStartGame";
            this.picBStartGame.Size = new System.Drawing.Size(259, 50);
            this.picBStartGame.TabIndex = 3;
            this.picBStartGame.TabStop = false;
            this.picBStartGame.Click += new System.EventHandler(this.picBNewGame_Click);
            // 
            // picBNamePlate
            // 
            this.picBNamePlate.Location = new System.Drawing.Point(9, 8);
            this.picBNamePlate.Name = "picBNamePlate";
            this.picBNamePlate.Size = new System.Drawing.Size(259, 50);
            this.picBNamePlate.TabIndex = 4;
            this.picBNamePlate.TabStop = false;
            // 
            // MainFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 280);
            this.ControlBox = false;
            this.Controls.Add(this.picBNamePlate);
            this.Controls.Add(this.picBStartGame);
            this.Controls.Add(this.picBLeaveGame);
            this.Controls.Add(this.picBLoadGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menü";
            ((System.ComponentModel.ISupportInitialize)(this.picBLoadGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLeaveGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBStartGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBNamePlate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBLoadGame;
        private System.Windows.Forms.PictureBox picBLeaveGame;
        private System.Windows.Forms.PictureBox picBStartGame;
        private System.Windows.Forms.PictureBox picBNamePlate;
    }
}

