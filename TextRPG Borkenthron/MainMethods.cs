using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRPG_Borkenthron
{
    public class MainMethods
    {
        MainVariables mainVariables;
        
        //Constructor to have access to the MainVariables class
        public MainMethods(MainVariables givenMainVariabes)
        {   mainVariables = givenMainVariabes;  }

        //Fills a given picturebox with a given picture
        public void Fill_PictureBox(PictureBox pictureBox, Bitmap bitmap)
        {
            pictureBox.Enabled = true;
            pictureBox.Visible = true;
            pictureBox.Image = bitmap;
        }

        //Clears a given picturebox
        public void Clear_PictureBox(PictureBox pictureBox)
        {
            pictureBox.Image = null;
            pictureBox.Enabled = false;
            pictureBox.Visible = false;
        }

        //Changes the Background of given form with given bitmap
        public void Form_Background_Change(Form form ,Bitmap background)
        {form.BackgroundImage = background;}

        //Method for switching the MainCharacter in the 3picturebox
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

        //Changing stats without display
        public int Change_Stats(int mainstat, int modifier, char upOrDown)
        {
            if(upOrDown == '+')
            {mainstat += modifier; mainVariables.Character_AbilityPoints--; }
            else
            {mainstat -= modifier; mainVariables.Character_AbilityPoints++; }
            return mainstat;
        }
        //Changes stats, and displays its value in a given label
        public int Change_Stats(int mainstat, int modifier, char upOrDown, Label label)
        {
            if (upOrDown == '+')
            { mainstat += modifier; mainVariables.Character_AbilityPoints--; }
            else
            { mainstat -= modifier; mainVariables.Character_AbilityPoints++; }

            label.Text = mainstat.ToString();
            return mainstat;
        }
        //Add/subtracts ability points, shows one label the current value and one label Ability points left
        public int Change_Stats(int mainstat, int modifier, char upOrDown, Label label, Label labelPoints)
        {
            if (upOrDown == '+')
            { mainstat += modifier; mainVariables.Character_AbilityPoints--; }
            else
            { mainstat -= modifier; mainVariables.Character_AbilityPoints++; }

            labelPoints.Text = mainVariables.Character_AbilityPoints.ToString();
            label.Text = mainstat.ToString();
            return mainstat;
        }
        //Method for adding items
        public void Change_Item_Count(int index, int addAmount, char addOrLose)
        {
            string[] breakUpString = mainVariables.Items_List[index].Split('_');
            int oldValue = Int32.Parse(breakUpString[1]);

            if (addOrLose == '+')
            {
                oldValue += addAmount;
            }
            else
            {
                oldValue -= addAmount;
            }
            mainVariables.Items_List[index] = breakUpString[0] + "_" + oldValue.ToString();
        }
        //Method for checking if the item exists at least once
        public bool Check_Item_Above_0(int index)
        {
            string[] breakUpString = mainVariables.Items_List[index].Split('_');
            int currentValue = Int32.Parse(breakUpString[1]);
            if(currentValue <= 0)
            { return false; }
            else
            { return true; }
        }

        //Method for an item clicked, checks for the name of the item, and if it a consumable it reduces the count by one
        public void Inventory_ItemClicked(string name, PictureBox pictureBox, int index)
        {
            switch(name)
            {
                case "Health Potion":
                    Change_Item_Count(index, 1, '-');
                    if(!Check_Item_Above_0(index))
                    {
                        Clear_PictureBox(pictureBox);
                    }
                    break;
            }
        }

        //Writing all information down via streamwriter that I need
        public void SaveGame()
        {
            try
            {
                using (StreamWriter stream = new StreamWriter(@"Safe_Files\Save01.txt"))
                {
                    stream.WriteLine(mainVariables.StoryLine_Progress.ToString());
                    stream.WriteLine(mainVariables.Character_Name);
                    stream.WriteLine(mainVariables.Character_Intelligence.ToString());
                    stream.WriteLine(mainVariables.Character_Strength.ToString());
                    stream.WriteLine(mainVariables.Character_Agility.ToString());
                    stream.WriteLine(mainVariables.Character_Health.ToString());
                    stream.WriteLine(mainVariables.Character_Crystals.ToString());
                    stream.WriteLine(mainVariables.Character_Honor.ToString());
                    stream.WriteLine(mainVariables.Items_FlowerCircle);
                    stream.WriteLine(mainVariables.Items_Sword);
                    stream.WriteLine(mainVariables.Items_HealthPotion);
                    stream.WriteLine(mainVariables.Items_FinishedTest);
                    stream.WriteLine(mainVariables.Items_Rope);
                    stream.WriteLine(mainVariables.Items_SuperAxe);
                    stream.WriteLine(mainVariables.Items_ChickenLeg);
                    stream.WriteLine(mainVariables.Items_Mirror);
                    stream.WriteLine(mainVariables.Items_GiantNut);

                    MessageBox.Show("Speichern Erfolgreich", "Erfolg");
                    stream.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        //Reading all necessary string from the textfile and updates the main variables, and goes to GameStart
        public void LoadGame(Form form, bool mainFrameBool, MainFrame mainFrame)
        {
            LoadGameBasic(form, mainFrameBool, mainFrame);

            if (mainFrameBool)
            { form.Hide(); }
            else
            { form.Close(); }
        }
        
        //overload needed in case loading is called from ingame menu, and a second window (gamestart) needs to be closed
        public void LoadGame(Form form, bool mainFrameBool, MainFrame mainFrame, GameStart gameStart)
        {
            gameStart.Close();
            LoadGameBasic(form, mainFrameBool, mainFrame);

            if (mainFrameBool)
            { form.Hide(); }
            else
            { form.Close(); }
        }

        //reads all information from the textfile
        public void LoadGameBasic(Form form, bool mainFrameBool, MainFrame mainFrame)
        {
            try
            {
                using (StreamReader stream = new StreamReader(@"Safe_Files\Save01.txt"))
                {
                    mainVariables = new MainVariables();

                    mainVariables.StoryLine_Progress = Int32.Parse(stream.ReadLine());
                    mainVariables.Character_Name = stream.ReadLine();
                    mainVariables.Character_Intelligence = Int32.Parse(stream.ReadLine());
                    mainVariables.Character_Strength = Int32.Parse(stream.ReadLine());
                    mainVariables.Character_Agility = Int32.Parse(stream.ReadLine());
                    mainVariables.Character_Health = Int32.Parse(stream.ReadLine());
                    mainVariables.Character_Crystals = Int32.Parse(stream.ReadLine());
                    mainVariables.Character_Honor = Int32.Parse(stream.ReadLine());
                    mainVariables.Items_FlowerCircle = stream.ReadLine();
                    mainVariables.Items_Sword = stream.ReadLine();
                    mainVariables.Items_HealthPotion = stream.ReadLine();
                    mainVariables.Items_FinishedTest = stream.ReadLine();
                    mainVariables.Items_Rope = stream.ReadLine();
                    mainVariables.Items_SuperAxe = stream.ReadLine();
                    mainVariables.Items_ChickenLeg = stream.ReadLine();
                    mainVariables.Items_Mirror = stream.ReadLine();
                    mainVariables.Items_GiantNut = stream.ReadLine();

                    MessageBox.Show("Laden Erfolgreich", "Erfolg");

                    GameStart game = new GameStart(this, mainVariables, mainFrame);
                    game.Show();
                    stream.Close();
                }
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        //Clearing pictureboxes so they dont overlap with the dialogbox
        public void Clear_All_Pictureboxes(PictureBox[] pictureBoxes)
        {
            foreach(PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Enabled = false;
                pictureBox.Visible = false;
            }
        }
        //Showing them again
        public void Show_All_Pictureboxes(PictureBox[] pictureBoxes)
        {
            foreach (PictureBox pictureBox in pictureBoxes)
            {
                pictureBox.Enabled = true;
                pictureBox.Visible = true;
            }
        }

        public void Clear_All_Buttons(Button[] btnArray)
        {
            foreach(Button button in btnArray)
            {button.Visible = false;}
        }
        #region Storyline
        //The main DialogProgressor, takes charactername
        /*
         dialogbox.Dialogbox_ButtonOne
         dialogbox.Dialogbox_ButtonTwo
         dialogbox.Dialogbox_ButtonThree
         dialogbox.Dialogbox_ButtonFour

         dialogbox.Dialogbox_Text.Text
         */
        public void Dialog_Progression(string name, int option, Dialogbox dialogbox)
        {
            Button[] btnArray = new Button[] { dialogbox.Dialogbox_ButtonOne, dialogbox.Dialogbox_ButtonTwo, dialogbox.Dialogbox_ButtonThree, dialogbox.Dialogbox_ButtonFour };
            
            switch(name)
            {   
                //Maries "Story"
                case "Marie":
                    
                dialogbox.Dialogbox_Name.Text = "Marie";                    
                switch(mainVariables.Characters_Maria_Progression)
                {
                    case 0:
                            dialogbox.Dialogbox_Text.Text = "Hallo " + mainVariables.Character_Name + ", wir haben uns lange nicht gesehen. Ich habe gehört du gehst" +
                                " heute in den Waldtempel. Wenn du willst könnte ich dir helfen, eine Opfergabe zu basteln.";
                            dialogbox.Dialogbox_ButtonOne.Visible = true;
                            dialogbox.Dialogbox_ButtonOne.Text = "Ja, das wäre sehr freundlich.";
                            dialogbox.Dialogbox_ButtonTwo.Visible = true;
                            dialogbox.Dialogbox_ButtonTwo.Text = "Nein danke, ich komme zurecht.";
                            mainVariables.Characters_Maria_Progression++;
                    break;
                        
                    case 1:
                        switch (option)
                        {   
                            case 1:
                                    Clear_All_Buttons(btnArray);
                                    dialogbox.Dialogbox_Text.Text = "Du findest hier einige Blumen, wenn du sie mir bringst kann ich dir einen Blumenkranz basteln. Wenn du 10 gesammelt hast reicht es.";
                                    mainVariables.FirstScene_CollectFlower = true;
                                    mainVariables.Characters_Maria_Progression++;
                            break;

                            case 2:
                                    Clear_All_Buttons(btnArray);
                                    dialogbox.Dialogbox_Text.Text = "Wie du wünschst, ich hoffe, du hast einen schönen Tag vor dir.";
                                    mainVariables.Characters_Maria_Progression = 10;
                            break;
                                default:
                                    dialogbox.Close();
                                    break;
                        }
                    break;
                        case 2:
                            switch(option)
                            {
                                case 1:
                                    break;
                                default:
                                    dialogbox.Close();
                                    break;
                            }    
                            break;
                }
                break;
            }
        }
        #endregion
    }
}