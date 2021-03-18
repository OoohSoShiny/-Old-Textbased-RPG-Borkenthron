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
    //500; 440
    public partial class GameStart : Form
    {
        MainMethods mainMethods;
        MainVariables mainVariables;

        public GameStart()
        {
            InitializeComponent();
            mainMethods = new MainMethods();
            mainVariables = new MainVariables();

            mainMethods.Form_Background_Change(this, mainVariables.FirstScreen_Background);
            mainMethods.Character_PictureBox(Globals.CharacterPic, picBMainHero);
            mainMethods.Fill_PictureBox(picBHealth, mainVariables.UserInterface_Heart);
            mainMethods.Fill_PictureBox(PicBMana, mainVariables.UserInterface_Crystal);
        }
    }
}
