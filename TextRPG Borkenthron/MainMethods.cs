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
    class MainMethods
    {
        MainVariables mainVariables = new MainVariables();
        public void Fill_PictureBox(PictureBox pictureBox, Bitmap bitmap)
        { pictureBox.Image = bitmap;}

        public void Form_Background_Change(Form form ,Bitmap background)
        {form.BackgroundImage = background;}
    }
}