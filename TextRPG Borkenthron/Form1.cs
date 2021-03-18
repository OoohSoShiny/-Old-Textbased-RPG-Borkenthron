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
        MainVariables mainVariables;
        MainMethods mainMethods;
        CharacterCreation characterCreation;
        public MainFrame()
        {
            InitializeComponent();
            mainVariables = new MainVariables();
            mainMethods = new MainMethods();
            characterCreation = new CharacterCreation();

            Initialize_MainMenu();
        }

        private void picBLeaveGame_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Initialize_MainMenu()
        {
            mainMethods.Form_Background_Change(this, mainVariables.MainMenu_Background);
            mainMethods.Fill_PictureBox(picBNewGame, mainVariables.MainMenu_NewGameIcon);
            mainMethods.Fill_PictureBox(picBLoadGame, mainVariables.MainMenu_LoadGame);
            mainMethods.Fill_PictureBox(picBLeaveGame, mainVariables.MainMenu_ExitGame);
        }

        private void picBNewGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            characterCreation.Show();
        }
    }
}
