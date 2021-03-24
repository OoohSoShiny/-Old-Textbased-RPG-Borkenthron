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
    public partial class Main_Dialog : Form
    {
        MainVariables mainVariables;
        MainMethods mainMethods;
        GameStart gameStart;
        MainFrame mainFrame;

        //Labels and buttons so they can be changed in main methods
        string name;

        public Label Dialogbox_Name
        { get { return lblName; }  set { lblName = value; } }
        public Label Dialogbox_Text
        { get { return lblText; } set { lblText = value; } }
        public Button Dialogbox_ButtonOne
        { get { return btnAnswerOne; } set { btnAnswerOne = value; } }
        public Button Dialogbox_ButtonTwo
        { get { return btnAnswerTwo; } set { btnAnswerTwo = value; } }
        public Button Dialogbox_ButtonThree
        { get { return btnAnswerThree; } set { btnAnswerThree = value; } }
        public Button Dialogbox_ButtonFour
        { get { return btnAnswerFour; } set { btnAnswerFour = value; } }
        public PictureBox Dialogbox_NextTextPicB
        { get { return picBNextDialog; } set { picBNextDialog = value; } }

        
        public Main_Dialog(MainVariables givenMainVariables, MainMethods givenMainMethods, string givenName, GameStart GivenGameStart, MainFrame givenMainFrame)
        {
            InitializeComponent();
            gameStart = GivenGameStart;
            mainFrame = givenMainFrame;

            name = givenName;
            mainVariables = givenMainVariables;
            mainMethods = givenMainMethods;

            mainMethods.Form_Background_Change(this, mainVariables.UserInterface_DialogboxBackground);
            mainMethods.Fill_PictureBox(picBNextDialog, mainVariables.UserInterface_DialogForward);
            mainMethods.Dialog_Progression(name, 0, this, gameStart, mainFrame);
        }
        public Main_Dialog(MainVariables givenMainVariables, MainMethods givenMainMethods, string givenName, GameStart GivenGameStart, MainFrame givenMainFrame, int optionCall)
        {
            InitializeComponent();
            gameStart = GivenGameStart;
            mainFrame = givenMainFrame;

            name = givenName;
            mainVariables = givenMainVariables;
            mainMethods = givenMainMethods;

            mainMethods.Form_Background_Change(this, mainVariables.UserInterface_DialogboxBackground);
            mainMethods.Fill_PictureBox(picBNextDialog, mainVariables.UserInterface_DialogForward);
            mainMethods.Dialog_Progression(name, optionCall, this, gameStart, mainFrame);
        }

        //Buttons zum antworten in dialog trees
        private void btnAnswerOne_Click(object sender, EventArgs e)
        { mainMethods.Dialog_Progression(name, 1, this, gameStart, mainFrame); }

        private void btnAnswerTwo_Click(object sender, EventArgs e)
        { mainMethods.Dialog_Progression(name, 2, this, gameStart, mainFrame); }

        private void btnAnswerThree_Click(object sender, EventArgs e)
        { mainMethods.Dialog_Progression(name, 3, this, gameStart, mainFrame); }

        private void btnAnswerFour_Click(object sender, EventArgs e)
        { mainMethods.Dialog_Progression(name, 4, this, gameStart, mainFrame); }

        private void picBNextDialog_Click(object sender, EventArgs e)
        { mainMethods.Dialog_Progression(name, 5, this, gameStart, mainFrame); }
    }
}
