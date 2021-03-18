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
    public partial class CharacterCreation : Form
    {
        MainVariables mainVariables;
        MainMethods mainMethods;

        public CharacterCreation()
        {
            InitializeComponent();
            mainVariables = new MainVariables();
            mainMethods = new MainMethods();

            mainMethods.Fill_PictureBox(picBCCStrPlus, mainVariables.CharacterCreation_AttributeUp);
            mainMethods.Fill_PictureBox(picBCCAgiPlus, mainVariables.CharacterCreation_AttributeUp);
            mainMethods.Fill_PictureBox(picBCCIntPlus, mainVariables.CharacterCreation_AttributeUp);
            mainMethods.Fill_PictureBox(picBCCStrMinus, mainVariables.CharacterCreation_AttributeDown);
            mainMethods.Fill_PictureBox(picBCCAgiMinus, mainVariables.CharacterCreation_AttributeDown);
            mainMethods.Fill_PictureBox(picBCCIntMinus, mainVariables.CharacterCreation_AttributeDown);
            mainMethods.Fill_PictureBox(picBCCSend, mainVariables.CharacterCreation_Start);
            mainMethods.Fill_PictureBox(picBCCBack, mainVariables.CharacterCreation_Cancel);
            mainMethods.Fill_PictureBox(picBCCCharPrevious, mainVariables.CharacterCreation_PicPrevious);
            mainMethods.Fill_PictureBox(picBCCCharNext, mainVariables.CharacterCreation_PicNext);
            mainMethods.Fill_PictureBox(picBCharacterCreation, mainVariables.MainCharacter_OnePic);

            mainMethods.Form_Background_Change(this, mainVariables.CharacterCreation_Background);
        }

        private void picBCCBack_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void picBCCSend_Click(object sender, EventArgs e)
        {

        }

        private void picBCCCharPrevious_Click(object sender, EventArgs e)
        {

        }

        private void picBCCCharNext_Click(object sender, EventArgs e)
        {

        }

        private void picBCCStrPlus_Click(object sender, EventArgs e)
        {

        }

        private void picBCCStrMinus_Click(object sender, EventArgs e)
        {

        }

        private void picBCCIntPlus_Click(object sender, EventArgs e)
        {

        }

        private void picBCCIntMinus_Click(object sender, EventArgs e)
        {

        }

        private void picBCCAgiPlus_Click(object sender, EventArgs e)
        {

        }

        private void picBCCAgiMinus_Click(object sender, EventArgs e)
        {

        }
    }
}
