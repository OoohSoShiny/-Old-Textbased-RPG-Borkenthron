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
    public class MainMethods
    {
        //Fills a given picturebox with a given picture
        MainVariables mainVariables = new MainVariables();
        public void Fill_PictureBox(PictureBox pictureBox, Bitmap bitmap)
        { pictureBox.Image = bitmap;}

        //Changes the Background of given form with given bitmap
        public void Form_Background_Change(Form form ,Bitmap background)
        {form.BackgroundImage = background;}

        //Method for switching the MainCharacter in the picturebox
        public void Character_PictureBox(int index, PictureBox picture)
        {
            switch (index)
            {
                case 1:
                    Fill_PictureBox(picture, mainVariables.MainCharacter_OnePic);
                    break;
                case 2:
                    Fill_PictureBox(picture, mainVariables.MainCharacter_TwoPic);
                    break;
                case 3:
                    Fill_PictureBox(picture, mainVariables.MainCharacter_ThreePic);
                    break;
            }
        }
        //Changing stats
        public int Change_Stats(int mainstat, int modifier, char upOrDown)
        {
            if(upOrDown == '+')
            {mainstat += modifier; Globals.characterAgi--; }
            else
            {mainstat -= modifier; Globals.characterAgi++; }
            return mainstat;
        }
        public int Change_Stats(int mainstat, int modifier, char upOrDown, Label label)
        {
            if (upOrDown == '+')
            { mainstat += modifier; Globals.characterAP--; }
            else
            { mainstat -= modifier; Globals.characterAP++; }

            label.Text = mainstat.ToString();
            return mainstat;
        }
        public int Change_Stats(int mainstat, int modifier, char upOrDown, Label label, Label labelPoints)
        {
            if (upOrDown == '+')
            { mainstat += modifier; Globals.characterAP--; }
            else
            { mainstat -= modifier; Globals.characterAP++; }

            labelPoints.Text = Globals.characterAP.ToString();
            label.Text = mainstat.ToString();
            return mainstat;
        }
    }
}