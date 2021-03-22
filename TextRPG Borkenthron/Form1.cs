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
    public partial class MainFrame : Form
    {
        //Calling the main classes
        MainVariables mainVariables;
        MainMethods mainMethods;
        CharacterCreation characterCreation;
        
        //Initializing mainframe, depending on whether it was called before or not
        public MainFrame()
        {
            InitializeComponent();
            mainVariables = new MainVariables();
            mainMethods = new MainMethods(mainVariables);
            mainVariables.Music_Soundplayer.Play();

            Initialize_MainMenu();
        }

        //Filling the pictures of the main menu
        private void Initialize_MainMenu()
        {
            mainMethods.Form_Background_Change(this, mainVariables.MainMenu_Background);
            mainMethods.Fill_PictureBox(picBStartGame, mainVariables.MainMenu_NewGameIcon);
            mainMethods.Fill_PictureBox(picBLoadGame, mainVariables.MainMenu_LoadGame);
            mainMethods.Fill_PictureBox(picBLeaveGame, mainVariables.MainMenu_ExitGame);
            mainMethods.Fill_PictureBox(picBNamePlate, mainVariables.MainMenu_NamePlate);
        }
        
        // "Leave Game" button
        private void picBLeaveGame_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        //Goes to the CharacterCreator
        private void picBNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            characterCreation = new CharacterCreation(this, mainMethods, mainVariables);
            characterCreation.Show();
        }
        
        //Load button
        private void picBLoadGame_Click(object sender, EventArgs e)
        {
            mainMethods.LoadGame(this, true, this);
        }
    }
}
