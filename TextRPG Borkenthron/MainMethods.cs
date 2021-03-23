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
            { oldValue += addAmount; }
            else
            { oldValue -= addAmount; }
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
                    stream.WriteLine(mainVariables.Items_SingleFlower);

                    MessageBox.Show("Speichern Erfolgreich", "Erfolg");
                    stream.Close();
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
                    mainVariables.Items_SingleFlower = stream.ReadLine();

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
        //Takes a button array and makes em invisible
        public void Clear_All_Buttons(Button[] btnArray)
        {
            foreach(Button button in btnArray)
            {button.Visible = false;}
        }
        //takes the given stat & goal and returns of roll was success or not
        public bool Roll_Stat(int stat, int goal)
        {
            int valuestat = stat;
            valuestat *= 10;
            valuestat += mainVariables.Random_Number.Next(1, 101);
            if(valuestat >= goal)
            { return true; }
            else 
            { return false; }
            
        }
        private void End_Dialog(Main_Dialog _Dialog)
        {
            mainVariables.UserInterface_DialogboxActive = false;
            _Dialog.Close();
        }



        public void Dialog_Progression(string name, int option, Main_Dialog GivenDialogbox, GameStart GivenGameStart, MainFrame givenMainFrame)
        {
            Button[] btnArray = new Button[] { GivenDialogbox.Dialogbox_ButtonOne, GivenDialogbox.Dialogbox_ButtonTwo, GivenDialogbox.Dialogbox_ButtonThree, GivenDialogbox.Dialogbox_ButtonFour };
            GivenDialogbox.Dialogbox_NextTextPicB.Visible = false;
            switch (name)   // Switch which name is used
            {   
                //Maries Dialog tree
                case "Marie":
                    
                GivenDialogbox.Dialogbox_Name.Text = "Marie";                    
                switch(mainVariables.Characters_Maria_Progression)
                {   //First talk
                    case 0: //<== Check for progression meter
                            GivenDialogbox.Dialogbox_Text.Text = "Hallo " + mainVariables.Character_Name + ", wir haben uns lange nicht gesehen. Ich habe gehört du gehst" +
                                " heute in den Waldtempel. Wenn du willst könnte ich dir helfen, eine Opfergabe zu basteln.";
                            GivenDialogbox.Dialogbox_ButtonOne.Visible = true;
                            GivenDialogbox.Dialogbox_ButtonOne.Text = "Ja, das wäre sehr freundlich.";
                            GivenDialogbox.Dialogbox_ButtonTwo.Visible = true;
                            GivenDialogbox.Dialogbox_ButtonTwo.Text = "Nein danke, ich komme zurecht.";
                            mainVariables.Characters_Maria_Progression++;
                    break;
                        
                    case 1:
                            switch (option)     //<== Check which button was pressed
                            {
                                    case 0:
                                        GivenDialogbox.Dialogbox_Text.Text = "Ja?";
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    break;
                            case 1:
                                    Clear_All_Buttons(btnArray);
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenDialogbox.Dialogbox_Text.Text = "Du findest hier einige Blumen, wenn du sie mir bringst kann ich dir einen Blumenkranz basteln. Wenn du 10 gesammelt hast reicht es.";
                                    mainVariables.FirstScene_CollectFlower = true;
                                    mainVariables.Characters_Maria_Progression++;
                            break;

                            case 2:
                                    Clear_All_Buttons(btnArray);
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenDialogbox.Dialogbox_Text.Text = "Wie du wünschst, ich hoffe, du hast einen schönen Tag vor dir.";
                                    mainVariables.Characters_Maria_Progression = 10;
                            break;
                                default:
                                    End_Dialog(GivenDialogbox);
                                    break;
                            }
                    break;

                    case 2:
                        switch(option)
                        {
                            case 0:
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenDialogbox.Dialogbox_Text.Text = "Ja?";
                                    string[] breakUpString = mainVariables.Items_List[9].Split('_');
                                    int currentValue = Int32.Parse(breakUpString[1]);
                                    if(currentValue >= 10)
                                    {
                                        GivenDialogbox.Dialogbox_ButtonOne.Visible = true;
                                        GivenDialogbox.Dialogbox_ButtonOne.Text = "Ich habe die Blumen gefunden.";
                                    }
                            break;

                            case 1:
                                    Clear_All_Buttons(btnArray);
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenDialogbox.Dialogbox_Text.Text = "Ah! Sehr schön... ich bastel dir einen Blumenkranz. Eine Sache noch... Falls du den Tempel besuchen willst, ich hörte, die Göttin hasst sinnloses Blutvergießen.";
                                    mainVariables.Characters_Maria_Progression = 10;
                                    Change_Item_Count(0, 1, '+');
                                    Change_Item_Count(9, 10, '-');
                            break;

                            default:
                                    End_Dialog(GivenDialogbox);
                                    break;
                        }    
                    break;
                        case 10:
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            GivenDialogbox.Dialogbox_Text.Text = "Ja?";
                            switch(option)
                            {
                                case 5:
                                    End_Dialog(GivenDialogbox);
                                    break;                                    
                            }
                            break;                        
                    default:
                            End_Dialog(GivenDialogbox);
                            break;
                }
                break;

                //Goblin
                case "Goblin":
                    GivenDialogbox.Dialogbox_Name.Text = "Goblin";
                    switch (mainVariables.Characters_Goblin_Progression)
                    {
                        case 0:
                            GivenDialogbox.Dialogbox_Text.Text = "Ihr seht einen Goblin vor euch. Er hastet auf und ab und wirkt irgendwie traurig, aber es ist immernoch ein gefährlicher Goblin...";
                            GivenDialogbox.Dialogbox_ButtonOne.Visible = true;   GivenDialogbox.Dialogbox_ButtonOne.Text = "Vorbeischleichen";
                            GivenDialogbox.Dialogbox_ButtonTwo.Visible = true;   GivenDialogbox.Dialogbox_ButtonTwo.Text = "Ablenken";
                            GivenDialogbox.Dialogbox_ButtonThree.Visible = true; GivenDialogbox.Dialogbox_ButtonThree.Text = "Angreifen!";

                            if(Check_Item_Above_0(0))
                            { GivenDialogbox.Dialogbox_ButtonFour.Visible = true; GivenDialogbox.Dialogbox_ButtonFour.Text = "Blumenkranz schenken"; }
                            mainVariables.Characters_Goblin_Progression++;
                            break;
                        //Main Decision in the Goblin tree
                        case 1:
                            Clear_All_Buttons(btnArray);
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            mainVariables.Characters_Goblin_Progression++;
                            switch(option)
                            {
                                case 0: //Auf den Goblin klicken(?)
                                    break;
                                case 1: //schleichen
                                    if(Roll_Stat(mainVariables.Character_Agility, 50))
                                    {GivenDialogbox.Dialogbox_Text.Text = "Der Wald bietet Euch viel Deckung, und Ihr wisst sie zu nutzen. Erfolg! Es geht weiter zur Stadt.";}
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Als du stolperst, und neben dem Goblin zu Boden gehst, fallen ein paar Kristalle zu Boden. Der Goblin nimmt sie und rennt weg, Ihr geht seufzend weiter zur Stadt.";
                                        mainVariables.Character_Crystals -= 10;
                                    }
                                    break;
                                case 2: //Ablenken
                                    if(Roll_Stat(mainVariables.Character_Intelligence, 50))
                                    {GivenDialogbox.Dialogbox_Text.Text = "Ihr werft einen Stein in ein Gebüsch auf der gegenüberliegenden Seite, und während der Goblin damit beschäftigt ist, lauft Ihr weiter zur Stadt. Erfolg!";}
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Ihr versucht einen Stein in ein gegenüberliegendes Gebüsch zu werfen, aber trefft den Goblin. Er rennt zu Euch und Ihr spürt, wie Ihr einen Tritt erleidet, bevor der Goblin abhaut.";
                                        mainVariables.Character_Health -= 3;
                                    }
                                    break;
                                case 3: //Angreifen
                                    mainVariables.Character_Honor--;
                                    if(Roll_Stat(mainVariables.Character_Strength, 30))
                                    {GivenDialogbox.Dialogbox_Text.Text = "Während Ihr den Goblin selbst zur Seite werft, ruft er Euch etwas in seiner Sprache zu, das Ihr zum Glück nicht versteht. Die Schatten werden dunkler.";}
                                    else
                                    {GivenDialogbox.Dialogbox_Text.Text = "Der Goblin tanzt um euch herum, während Ihr versucht ihn zu treffen und zieht beleidigende Grimassen, bevor er lachend verschwindet. Eine Demütigung, und die Schatten werden dunkler.";}
                                    break;
                                case 4: //Blumenkranz schenken
                                    GivenDialogbox.Dialogbox_Text.Text = " \"Oh, vielen Dank! Hier, Ihr dürft dafür das hier haben.\", spricht der Goblin gut gelaunt, und reicht euch eine riesige Nuss. Ihr bedankt euch, und geht weiter Richtung Stadt.";
                                    Change_Item_Count(8, 1, '+');
                                    break;
                            }
                            //End of Goblin main Choice
                            break;
                        case 2:
                            mainVariables.StoryLine_Progress++;
                            mainVariables.UserInterface_DialogboxActive = false;
                            GivenGameStart = new GameStart(this, mainVariables, givenMainFrame);
                            GivenGameStart.Show();                            
                            End_Dialog(GivenDialogbox);
                            break;
                    }
                    //end goblin case
                    break;
                case "Kitten":
                    GivenDialogbox.Dialogbox_Name.Text = "Kitten";
                    switch(option)
                    {
                        case 0:
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            GivenDialogbox.Dialogbox_Text.Text = "Ihr habt das fliegende Kätzchen des Glücks gefunden. Es wirft euch eine Hähnchenkeule zu, und verschwinden dann hinter den Wolken";
                            Change_Item_Count(6, 1, '+');
                            mainVariables.Characters_KittenClicked = true;
                            break;
                        case 5:
                            GivenGameStart.Characters_KittenPictureBox.Visible = false;
                            End_Dialog(GivenDialogbox);
                            break;
                    }
                    //end of the KITTEN statement
                    break;
                
                //start of Jack
                case "Jack":

                    break;
                
            //end of the NAME switch statement
            }
        }
    }
}