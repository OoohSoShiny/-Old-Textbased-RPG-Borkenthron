using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRPG_Borkenthron
{
    public partial class IngameMenu : Form
    {
        //Calling other classes used
        MainVariables mainVariables;
        MainMethods mainMethods;
        GameStart gamestart;
        MainFrame mainFrame;

        //Constructor to use the given variables and store the references, filling the pictureboxes etc.
        public IngameMenu(MainVariables givenMainVariables, MainMethods givenMainMethods, GameStart givenGameStart, MainFrame givenMainFrame)
        {   
            //Initializing the ingame Menu
            InitializeComponent();

            mainVariables = givenMainVariables;
            mainMethods = givenMainMethods;
            gamestart = givenGameStart;
            mainFrame = givenMainFrame;

            mainMethods.Fill_PictureBox(picBBackToGame, mainVariables.UserInterface_BackToGame);
            mainMethods.Fill_PictureBox(picBSaveGame, mainVariables.UserInterface_SaveGame);
            mainMethods.Fill_PictureBox(picBLoadGame, mainVariables.MainMenu_LoadGame);
            mainMethods.Fill_PictureBox(picBLeaveGame, mainVariables.UserInterface_BackToMainMenu);
            mainMethods.Form_Background_Change(this, mainVariables.UserInterface_IngameMenuBackground);            
        }

        //Returns to game
        private void picBBackToGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainVariables.UserInterface_IngameMenuActive = false;
        }

        //Exits game
        private void picBLeaveGame_Click(object sender, EventArgs e)
        {
            mainVariables.Music_Soundplayer.Stop();
            MainFrame mainframe = new MainFrame();
            mainFrame.Show();
            gamestart.Close();
            this.Close();
        }
        //Save button
        private void picBSaveGame_Click(object sender, EventArgs e)
        {
            mainMethods.SaveGame();
        }
        //loads game
        private void picBLoadGame_Click(object sender, EventArgs e)
        {
            mainMethods.LoadGame(this, false, mainFrame, gamestart);
            gamestart.Close();
            this.Close();
        }

        private void IngameMenu_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
