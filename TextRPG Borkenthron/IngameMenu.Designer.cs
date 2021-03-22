
namespace TextRPG_Borkenthron
{
    partial class IngameMenu
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
            this.picBSaveGame = new System.Windows.Forms.PictureBox();
            this.picBLoadGame = new System.Windows.Forms.PictureBox();
            this.picBLeaveGame = new System.Windows.Forms.PictureBox();
            this.picBBackToGame = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBSaveGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLoadGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLeaveGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBBackToGame)).BeginInit();
            this.SuspendLayout();
            // 
            // picBSaveGame
            // 
            this.picBSaveGame.Location = new System.Drawing.Point(13, 79);
            this.picBSaveGame.Name = "picBSaveGame";
            this.picBSaveGame.Size = new System.Drawing.Size(259, 50);
            this.picBSaveGame.TabIndex = 1;
            this.picBSaveGame.TabStop = false;
            this.picBSaveGame.Click += new System.EventHandler(this.picBSaveGame_Click);
            // 
            // picBLoadGame
            // 
            this.picBLoadGame.Location = new System.Drawing.Point(12, 147);
            this.picBLoadGame.Name = "picBLoadGame";
            this.picBLoadGame.Size = new System.Drawing.Size(259, 50);
            this.picBLoadGame.TabIndex = 2;
            this.picBLoadGame.TabStop = false;
            this.picBLoadGame.Click += new System.EventHandler(this.picBLoadGame_Click);
            // 
            // picBLeaveGame
            // 
            this.picBLeaveGame.Location = new System.Drawing.Point(13, 214);
            this.picBLeaveGame.Name = "picBLeaveGame";
            this.picBLeaveGame.Size = new System.Drawing.Size(259, 50);
            this.picBLeaveGame.TabIndex = 3;
            this.picBLeaveGame.TabStop = false;
            this.picBLeaveGame.Click += new System.EventHandler(this.picBLeaveGame_Click);
            // 
            // picBBackToGame
            // 
            this.picBBackToGame.Location = new System.Drawing.Point(13, 12);
            this.picBBackToGame.Name = "picBBackToGame";
            this.picBBackToGame.Size = new System.Drawing.Size(259, 50);
            this.picBBackToGame.TabIndex = 4;
            this.picBBackToGame.TabStop = false;
            this.picBBackToGame.Click += new System.EventHandler(this.picBBackToGame_Click);
            // 
            // IngameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 280);
            this.Controls.Add(this.picBBackToGame);
            this.Controls.Add(this.picBLeaveGame);
            this.Controls.Add(this.picBLoadGame);
            this.Controls.Add(this.picBSaveGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "IngameMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IngameMenu";
            this.Deactivate += new System.EventHandler(this.IngameMenu_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.picBSaveGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLoadGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBLeaveGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBBackToGame)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBSaveGame;
        private System.Windows.Forms.PictureBox picBLoadGame;
        private System.Windows.Forms.PictureBox picBLeaveGame;
        private System.Windows.Forms.PictureBox picBBackToGame;
    }
}