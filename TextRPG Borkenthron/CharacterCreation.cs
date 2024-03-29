﻿using System;
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
        GameStart firstScreen;
        MainFrame mainFrame;


        //Fills the character Creator with pics and initializes the forms he needs access to
        public CharacterCreation(MainFrame givenMainFrame, MainMethods givenMainMethods, MainVariables givenMainVariabes)  
        {
            InitializeComponent();
            mainVariables = givenMainVariabes;
            mainMethods = givenMainMethods;
            mainFrame = givenMainFrame;

            mainMethods.Reset_Story_Variables();

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

        //From the Character Creation back to the main screen
        private void picBCCBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainFrame.Show();
        }

        //From the Character Creator to actually starting the game
        private void picBCCSend_Click(object sender, EventArgs e)
        {
            if(txtCharacterCreationName.Text == "")
            { 
            
            }
            else
            {
                mainVariables.Character_Name = txtCharacterCreationName.Text;
                firstScreen = new GameStart(mainMethods, mainVariables, mainFrame);
                firstScreen.Show();
                this.Close();
            }
        }
        
        //Changing the picture for the Character (Previous picture)
        private void picBCCCharPrevious_Click(object sender, EventArgs e)
        {
            picBCCCharPrevious.Enabled = true;
            picBCCCharNext.Enabled = true;

            mainVariables.Character_Picture--;
            mainMethods.Character_PictureBox(mainVariables.Character_Picture, picBCharacterCreation);
            if(mainVariables.Character_Picture == 1)
            { picBCCCharPrevious.Enabled = false; }
        }
        
        //Changing the picture for the Character (Next picture)
        private void picBCCCharNext_Click(object sender, EventArgs e)
        {
            picBCCCharPrevious.Enabled = true;
            picBCCCharNext.Enabled = true;

            mainVariables.Character_Picture++;
            mainMethods.Character_PictureBox(mainVariables.Character_Picture, picBCharacterCreation);
            
            if (mainVariables.Character_Picture == 3)
            { picBCCCharNext.Enabled = false; }
        }
        
        //Changing Stas via the +/- buttons in the character creation screen
        private void picBCCStrPlus_Click(object sender, EventArgs e)
        {
            if (mainVariables.Character_AbilityPoints > 0)
            {
                mainVariables.Character_Strength = mainMethods.Change_Stats(mainVariables.Character_Strength, 1, '+', lblCCStatsStrCurrent, lblCCStatsPointLeftCurrent);
            }
        }

        private void picBCCStrMinus_Click(object sender, EventArgs e)
        {
            if (mainVariables.Character_Strength > 1)
            {
                mainVariables.Character_Strength = mainMethods.Change_Stats(mainVariables.Character_Strength, 1, '-', lblCCStatsStrCurrent, lblCCStatsPointLeftCurrent);
            }
        }

        private void picBCCIntPlus_Click(object sender, EventArgs e)
        {
            if (mainVariables.Character_AbilityPoints > 0)
            {
                mainVariables.Character_Intelligence = mainMethods.Change_Stats(mainVariables.Character_Intelligence, 1, '+', lblCCStatsIntCurrent, lblCCStatsPointLeftCurrent);
            }
        }

        private void picBCCIntMinus_Click(object sender, EventArgs e)
        {
            if (mainVariables.Character_Intelligence > 1)
            {
                mainVariables.Character_Intelligence = mainMethods.Change_Stats(mainVariables.Character_Intelligence, 1, '-', lblCCStatsIntCurrent, lblCCStatsPointLeftCurrent);
            }
        }

        private void picBCCAgiPlus_Click(object sender, EventArgs e)
        {
            if (mainVariables.Character_AbilityPoints > 0)
            {
                mainVariables.Character_Agility = mainMethods.Change_Stats(mainVariables.Character_Agility, 1, '+', lblCCStatsAgiCurrent, lblCCStatsPointLeftCurrent);
            }
        }

        private void picBCCAgiMinus_Click(object sender, EventArgs e)
        {
            if (mainVariables.Character_Agility > 1)
            {
                mainVariables.Character_Agility = mainMethods.Change_Stats(mainVariables.Character_Agility, 1, '-', lblCCStatsAgiCurrent, lblCCStatsPointLeftCurrent);
            }
        }
    }
}
