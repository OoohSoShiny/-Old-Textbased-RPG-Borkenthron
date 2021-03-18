
namespace TextRPG_Borkenthron
{
    partial class GameStart
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
            this.picBMainHero = new System.Windows.Forms.PictureBox();
            this.PicBMana = new System.Windows.Forms.PictureBox();
            this.picBHealth = new System.Windows.Forms.PictureBox();
            this.picBInventory = new System.Windows.Forms.PictureBox();
            this.PicBGoFront = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBMainHero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBMana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBHealth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBGoFront)).BeginInit();
            this.SuspendLayout();
            // 
            // picBMainHero
            // 
            this.picBMainHero.BackColor = System.Drawing.Color.Transparent;
            this.picBMainHero.Location = new System.Drawing.Point(194, 321);
            this.picBMainHero.Name = "picBMainHero";
            this.picBMainHero.Size = new System.Drawing.Size(100, 124);
            this.picBMainHero.TabIndex = 0;
            this.picBMainHero.TabStop = false;
            // 
            // PicBMana
            // 
            this.PicBMana.BackColor = System.Drawing.Color.Transparent;
            this.PicBMana.Location = new System.Drawing.Point(11, 48);
            this.PicBMana.Name = "PicBMana";
            this.PicBMana.Size = new System.Drawing.Size(33, 30);
            this.PicBMana.TabIndex = 1;
            this.PicBMana.TabStop = false;
            // 
            // picBHealth
            // 
            this.picBHealth.BackColor = System.Drawing.Color.Transparent;
            this.picBHealth.Location = new System.Drawing.Point(12, 12);
            this.picBHealth.Name = "picBHealth";
            this.picBHealth.Size = new System.Drawing.Size(32, 30);
            this.picBHealth.TabIndex = 2;
            this.picBHealth.TabStop = false;
            // 
            // picBInventory
            // 
            this.picBInventory.BackColor = System.Drawing.Color.Transparent;
            this.picBInventory.Location = new System.Drawing.Point(12, 402);
            this.picBInventory.Name = "picBInventory";
            this.picBInventory.Size = new System.Drawing.Size(141, 30);
            this.picBInventory.TabIndex = 3;
            this.picBInventory.TabStop = false;
            // 
            // PicBGoFront
            // 
            this.PicBGoFront.BackColor = System.Drawing.Color.Transparent;
            this.PicBGoFront.Location = new System.Drawing.Point(194, 12);
            this.PicBGoFront.Name = "PicBGoFront";
            this.PicBGoFront.Size = new System.Drawing.Size(175, 35);
            this.PicBGoFront.TabIndex = 4;
            this.PicBGoFront.TabStop = false;
            // 
            // GameStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 440);
            this.ControlBox = false;
            this.Controls.Add(this.PicBGoFront);
            this.Controls.Add(this.picBInventory);
            this.Controls.Add(this.picBHealth);
            this.Controls.Add(this.PicBMana);
            this.Controls.Add(this.picBMainHero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GameStart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GameStart";
            ((System.ComponentModel.ISupportInitialize)(this.picBMainHero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBMana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBHealth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicBGoFront)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBMainHero;
        private System.Windows.Forms.PictureBox PicBMana;
        private System.Windows.Forms.PictureBox picBHealth;
        private System.Windows.Forms.PictureBox picBInventory;
        private System.Windows.Forms.PictureBox PicBGoFront;
    }
}