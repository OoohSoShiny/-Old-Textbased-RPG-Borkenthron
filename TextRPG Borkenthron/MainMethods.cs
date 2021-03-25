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
                    stream.WriteLine(mainVariables.FirstScene_CollectFlower.ToString());
                    stream.WriteLine(mainVariables.Items_SingleFlower);                    
                    stream.WriteLine(mainVariables.Characters_Maria_Progression.ToString());
                    stream.WriteLine(mainVariables.Characters_Goblin_Progression.ToString());
                    stream.WriteLine(mainVariables.Characters_JackProgression.ToString());
                    stream.WriteLine(mainVariables.Characters_KittenClicked.ToString());
                    stream.WriteLine(mainVariables.Characters_JacksKittenSaved.ToString());
                    stream.WriteLine(mainVariables.Characters_Lea_CutOnce.ToString());
                    stream.WriteLine(mainVariables.Characters_Lea_ChopCount.ToString());
                    stream.WriteLine(mainVariables.Characters_Jorn_Progression.ToString());
                    stream.WriteLine(mainVariables.Characters_Vendor_RopeBought.ToString());
                    stream.WriteLine(mainVariables.Characters_Vendor_TestBought.ToString());
                    stream.WriteLine(mainVariables.Characters_Lea_WoodAllowed.ToString());
                    stream.WriteLine(mainVariables.Characters_ValeriaHelped.ToString());
                   
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
                    mainVariables.FirstScene_CollectFlower = bool.Parse(stream.ReadLine());
                    mainVariables.Items_SingleFlower = stream.ReadLine();
                    mainVariables.Characters_Maria_Progression = Int32.Parse(stream.ReadLine());
                    mainVariables.Characters_Goblin_Progression  = Int32.Parse(stream.ReadLine());
                    mainVariables.Characters_JackProgression  = Int32.Parse(stream.ReadLine());
                    mainVariables.Characters_KittenClicked = bool.Parse(stream.ReadLine());
                    mainVariables.Characters_JacksKittenSaved = bool.Parse(stream.ReadLine());
                    mainVariables.Characters_Lea_CutOnce = bool.Parse(stream.ReadLine());
                    mainVariables.Characters_Lea_ChopCount = Int32.Parse(stream.ReadLine());
                    mainVariables.Characters_Jorn_Progression = Int32.Parse(stream.ReadLine());
                    mainVariables.Characters_Vendor_RopeBought = bool.Parse(stream.ReadLine());
                    mainVariables.Characters_Vendor_TestBought = bool.Parse(stream.ReadLine());
                    mainVariables.Characters_Lea_WoodAllowed = bool.Parse(stream.ReadLine());
                    mainVariables.Characters_ValeriaHelped = bool.Parse(stream.ReadLine());

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
        //Resetting all values in the Mainvariables which have impact on the storyline
        public void Reset_Story_Variables()
        {
            mainVariables.Character_AbilityPoints = 5;
            mainVariables.StoryLine_Progress = 1;
            mainVariables.Character_Name = "0";
            mainVariables.Character_Intelligence = 3;
            mainVariables.Character_Strength = 3;
            mainVariables.Character_Agility = 3;
            mainVariables.Character_Health = 10;
            mainVariables.Character_Crystals = 10;
            mainVariables.Character_Honor = 0;
            mainVariables.Items_FlowerCircle = "Flower Circle_0_Ein wunderschöner Blumenkranz, einer Göttin würdig.";
            mainVariables.Items_Sword = "Sword_0_Ein etwas stumpfes, aber noch brauchbares Schwert";
            mainVariables.Items_HealthPotion = "Health Potion_0_Heiltrank, heilt um 5 Lebenspunkte";
            mainVariables.Items_FinishedTest = "Finished Test_0_Ein Test, bei dem alle Antworten korrekt ausgefüllt wurden";
            mainVariables.Items_Rope = "Rope_0_Ein festes Seil, das man sehr gut greifen kann";
            mainVariables.Items_SuperAxe = "Superaxe_0_Eine mächtige Axt, die aus Holz... Kleinholz macht";
            mainVariables.Items_ChickenLeg = "Chicken Leg_0_Ein leckerer Hühnchenschenkel";
            mainVariables.Items_Mirror = "Mirror_0_Ein einfacher Handspiegel";
            mainVariables.Items_GiantNut = "Giant Nut_0_Nüffe? Welfe Nüffe?";
            mainVariables.FirstScene_CollectFlower = false;
            mainVariables.Items_SingleFlower = "Single Flower_0_Eine einzelne, hübsche Blume";
            mainVariables.Characters_Maria_Progression = 0;
            mainVariables.Characters_Goblin_Progression = 0;
            mainVariables.Characters_JackProgression = 0;
            mainVariables.Characters_KittenClicked = false;
            mainVariables.Characters_JacksKittenSaved = false;
            mainVariables.Characters_Jorn_Progression = 0;
        }

        //Reading all necessary strings from the textfile and updates the main variables, and goes to GameStart
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
        //Closes window
        private void End_Dialog(Main_Dialog _Dialog)
        {
            mainVariables.UserInterface_DialogboxActive = false;
            _Dialog.Close();
        }

        //This Dialog tree is for Quest / Talk progression. The first switch in each case is for the Character clicked on, the second switch is for the Progression meter, 
        //and the third switch is for choices made / how the interaction started
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
                                " heute in den Waldtempel, um ein Champion der Herrin des Waldes zu werden. Sie nimmt nur ehrenvolle Personen, wenn du möchtest, kann ich dir einen" +
                                " Blumenkranz basteln, vielleicht hilft er dir auf deinem Wege?";
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
                                        GivenDialogbox.Dialogbox_Text.Text = "Ja? Pass auf dich auf.";
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
                                    GivenDialogbox.Dialogbox_Text.Text = "Ja? Pass auf dich auf.";
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
                                    GivenDialogbox.Dialogbox_Text.Text = "Ah! Sehr schön... ich bastel dir einen Blumenkranz. Eine Sache noch... Falls du den Tempel besuchen willst, ich hörte, die Göttin hasst sinnloses Blutvergießen, auch wenn sportliche" +
                                        " Kämpfe offenbar in Ordnung sind. Seltsam, seltsam.";
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
                            GivenDialogbox.Dialogbox_Text.Text = "Ja? Pass auf dich auf.";
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
                            mainVariables.Characters_Goblin_Progression++;
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            switch (option)
                            {
                                case 1: //schleichen
                                    if(Roll_Stat(mainVariables.Character_Agility, 50))
                                    {GivenDialogbox.Dialogbox_Text.Text = "Der Wald bietet Euch viel Deckung, und Ihr wisst sie zu nutzen. Erfolg! Es geht weiter zum Dorf.";}
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Als du stolperst, und neben dem Goblin zu Boden gehst, fallen ein paar Kristalle zu Boden. Der Goblin nimmt sie und rennt weg, Ihr geht seufzend weiter zum Dorf.";
                                        mainVariables.Character_Crystals -= 10;
                                    }
                                    break;
                                case 2: //Ablenken
                                    if(Roll_Stat(mainVariables.Character_Intelligence, 50))
                                    {GivenDialogbox.Dialogbox_Text.Text = "Ihr werft einen Stein in ein Gebüsch auf der gegenüberliegenden Seite, und während der Goblin damit beschäftigt ist, lauft Ihr weiter zum Dorf. Erfolg!";}
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Ihr versucht einen Stein in ein gegenüberliegendes Gebüsch zu werfen, aber trefft den Goblin. Er rennt zu Euch und Ihr spürt, wie Ihr einen Tritt erleidet, bevor der Goblin abhaut.";
                                        mainVariables.Character_Health -= 3;
                                    }
                                    break;
                                case 3: //Angreifen

                                    mainVariables.Character_Honor--;
                                    if(Roll_Stat(mainVariables.Character_Strength, 30))
                                    {GivenDialogbox.Dialogbox_Text.Text = "Während Ihr den Goblin selbst zur Seite werft, ruft er Euch etwas in seiner Sprache zu, das Ihr zum Glück nicht versteht. Ihr habt Erfolg, doch das Licht in euch schwindet.";}
                                    else
                                    {GivenDialogbox.Dialogbox_Text.Text = "Der Goblin tanzt um euch herum, während Ihr versucht ihn zu treffen und zieht beleidigende Grimassen, bevor er lachend verschwindet. Eine Demütigung, doch das Licht in euch schwindet."; }
                                    break;
                                case 4: //Blumenkranz schenken
                                    GivenDialogbox.Dialogbox_Text.Text = " \"Oh, vielen Dank! Hier, Ihr dürft dafür das hier haben!\", spricht der Goblin gut gelaunt, und reicht euch eine riesige Nuss. \"Und ich empfehle euch einen Spiegel mit zu nehmen, falls Ihr in die Arena geht.\" Ihr bedankt euch, und geht weiter Richtung Dorf. Das Licht in euch erstrahlt hell.";
                                    Change_Item_Count(8, 1, '+');
                                    Change_Item_Count(0, 1, '-');
                                    break;
                            }
                            //End of Goblin main Choice
                            break;
                        case 2:
                            mainVariables.StoryLine_Progress++;
                            mainVariables.UserInterface_DialogboxActive = false;
                            GivenGameStart.Close();
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
                            GivenDialogbox.Dialogbox_Text.Text = "Ihr habt das fliegende Kätzchen des Glücks gefunden. Es wirft euch eine Hähnchenkeule zu, und verschwindet dann hinter den Wolken.";
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
                    GivenDialogbox.Dialogbox_Name.Text = "Jack";

                    if (!mainVariables.Characters_JacksKittenSaved)
                    {
                        switch (option)
                        {
                            case 0:
                                if (!mainVariables.Characters_JacksKittenSaved)
                                {
                                    GivenDialogbox.Dialogbox_Text.Text = "Grüße euch, werter Wanderer. Mein Name ist Jack, und wenn ihr mir helfen könntet wäre ich euch sehr dankbar. Im Baum dort oben befindet sich eine Katze - würdet Ihr mir helfen, ihr herunter zu helfen? Ein Seil könnte helfen.";
                                    GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Klar, kein Problem.";
                                    GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Nein, Vielleicht später";
                                }
                                else
                                {
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenDialogbox.Dialogbox_Text.Text = "Vielen Dank, ich weiß es wirklich zu schätzen";
                                }
                                break;
                            case 1:
                                Clear_All_Buttons(btnArray);
                                GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                if (Check_Item_Above_0(4))
                                {
                                    GivenDialogbox.Dialogbox_Text.Text = "Ihr benutzt euer Seil, um das Kätzchen sicher von dem Baum zu holen. Jack sieht euch dankbar an. \"Hier, es ist nicht viel, aber vielleicht hilft es.\" Er gibt euch einen Spiegel, und das Licht erstrahlt heller.";
                                    Change_Item_Count(7, 1, '+');
                                    GivenGameStart.Characters_StuckKitten.Visible = false;
                                    mainVariables.Characters_JacksKittenSaved = true;
                                    mainVariables.Character_Honor++;
                                }
                                else
                                {
                                    if (Roll_Stat(mainVariables.Character_Agility, 60))
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Ihr habt kein Seil, aber geübt klettert ihr auf den Baum, und rettet das Kätzchen.  Jack sieht euch dankbar an. \"Hier, es ist nicht viel, aber vielleicht hilft es.\" Er gibt euch einen Spiegel, und das Licht erstrahlt heller.";
                                        mainVariables.Character_Honor++;
                                        Change_Item_Count(7, 1, '+');
                                        GivenGameStart.Characters_StuckKitten.Visible = false;
                                        mainVariables.Characters_JacksKittenSaved = true;
                                    }
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Ihr versucht auf den Baum zu klettern, doch rutscht euer Fuß mehrmals ab. Schließlich springt die Katze auf euren Kopf, und läuft zu Jack. \"Nun, immerhin ist sie wieder unten.\"";
                                        GivenGameStart.Characters_StuckKitten.Visible = false;
                                        mainVariables.Characters_JacksKittenSaved = true;
                                    }
                                }
                                break;
                            default:
                                End_Dialog(GivenDialogbox);
                                break;
                        }
                        break;
                    }
                    else
                    {
                        GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                        GivenDialogbox.Dialogbox_Text.Text = "Grüße euch, " + mainVariables.Character_Name + ".";
                        if(option == 5)
                        {
                            End_Dialog(GivenDialogbox);
                        }
                        break;
                    } //end of jack

                case "StuckKitten":
                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                    GivenDialogbox.Dialogbox_Name.Text = "Kätzchen im Baum";
                    switch (option)
                    {
                        case 0:
                            GivenDialogbox.Dialogbox_Text.Text = "Ihr seht ein Kätzchen oben im Baum. Im Gegensatz zu gewissen anderen Katzen sieht es nicht so aus, als könnte es fliegen.";
                        break;
                        default:
                            End_Dialog(GivenDialogbox);
                            break;
                    }                    
                    break;//end stuck kitten

                case "Jorn":
                    GivenDialogbox.Dialogbox_Name.Text = "Jorn";
                    GivenGameStart.Characters_KittenPictureBox.Visible = false;

                    switch (mainVariables.Characters_Jorn_Progression)
                    {
                        case 0:
                            switch (option)
                            {
                                case 0:
                                    Clear_All_Buttons(btnArray);
                                    GivenDialogbox.Dialogbox_Text.Text = "Grüße, ich hab schon von Euch gehört, " + mainVariables.Character_Name + ". Dies ist die Arena, drei Kämpfe, verlierst du fliegst du raus. " +
                                        "Du entscheidest, was mit deinem Gegner passiert, wenn du gewinnst. Der erste Kampf ist ein Wolf. Einmal angefangen musst du alle Kämpfe führen, also sei gut vorbereitet. Machst du mit?";
                                    GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Ich brauche noch etwas Vorbereitung.";
                                    GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Ich bin dabei.";
                                    break;
                                case 1:
                                    End_Dialog(GivenDialogbox);
                                    break;
                                case 2:
                                    GivenGameStart.Characters_Vendor.Visible = false;
                                    GivenGameStart.Characters_Jorn.Visible = false;
                                    GivenGameStart.Characters_KittenPictureBox.Visible = false;
                                    GivenGameStart.BackgroundImage = mainVariables.Backgrounds_Arena;
                                    GivenGameStart.UI_GoSomewhere.Visible = false;
                                    Fill_PictureBox(GivenGameStart.Characters_ArenaEnemy, mainVariables.Characters_ArenaWolf);
                                    Clear_All_Buttons(btnArray);
                                    GivenDialogbox.Dialogbox_Name.Text = "Wolf";
                                    if(Check_Item_Above_0(6))
                                    {
                                        Change_Item_Count(6, 1, '-');
                                        GivenDialogbox.Dialogbox_Text.Text = "Der Wolf sah hungrig aus, doch Ihr konntet ihm ein Hühnchenschenkel zuwerfen. Nun tollt er spielend um euch herum. Die Menge schreit, Ihr sollt dem Wolf ein Ende machen, oder wollt Ihr Gnade walten lassen?";
                                        GivenDialogbox.Dialogbox_ButtonThree.Visible = true; GivenDialogbox.Dialogbox_ButtonThree.Text = "Gnade walten lassen.";
                                        GivenDialogbox.Dialogbox_ButtonFour.Visible = true; GivenDialogbox.Dialogbox_ButtonFour.Text = "Den Zuschauern geben, was sie wollen.";
                                    }
                                    else if(Roll_Stat(mainVariables.Character_Strength, 80))
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Der Wolf war hungrig, und eure Stärke ohnesgleichen. Nun liegt der Wolf am Boden, und die Menge schreit, Ihr sollt dem Wolf ein Ende machen. Doch der Wolf am Boden berührt Euer Herz.";
                                        GivenDialogbox.Dialogbox_ButtonThree.Visible = true; GivenDialogbox.Dialogbox_ButtonThree.Text = "Gnade walten lassen.";
                                        GivenDialogbox.Dialogbox_ButtonFour.Visible = true; GivenDialogbox.Dialogbox_ButtonFour.Text = "Den Zuschauern geben, was sie wollen.";
                                    }
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                        GivenDialogbox.Dialogbox_Text.Text = "Die Stärke und der Hunger des Wolfes ist zuviel für euch. Ihr werdet verletzt, und rennt aus der Arena davon.";
                                        mainVariables.Character_Health -= 5;
                                    }
                                    break;
                                case 3:
                                    Clear_All_Buttons(btnArray);
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    mainVariables.Characters_Jorn_Progression++;
                                    GivenDialogbox.Dialogbox_Text.Text = "Ihr meint Dankbarkeit in den Augen des davonlaufenden Wolfes zu sehen, als Ihr Euch weigert, ihm den Rest zu geben. Die Menge buht, doch das Licht in euch wird stärker. Ihr" +
                                        " bereitet euch auf den zweiten Kampf vor, einen Magier.";
                                    mainVariables.Character_Honor++;
                                    break;
                                case 4:
                                    Clear_All_Buttons(btnArray);
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    mainVariables.Characters_Jorn_Progression++;
                                    GivenDialogbox.Dialogbox_Text.Text = "Ihr hebt eure Hände, nachdem Ihr mit Eurer Tat fertig seid, und die Massen jubeln. Und trotzdem... Das Licht in Euch schwindet. Ihr bereitet euch auf den" +
                                        " zweiten Kampf vor, einen Magier.";
                                    mainVariables.Character_Honor--;
                                    break;
                                case 5:
                                    if(!mainVariables.Characters_JacksKittenSaved)
                                    { GivenGameStart.Characters_KittenPictureBox.Visible = true; }
                                    Form_Background_Change(GivenGameStart, mainVariables.Background_City);
                                    GivenGameStart.Characters_ArenaEnemy.Visible = false;
                                    End_Dialog(GivenDialogbox);
                                    break;
                            }
                            break; //END FIRST ENCOUNTER ARENA
                        
                        case 1://START SECOND ENCOUNTER
                            Fill_PictureBox(GivenGameStart.Characters_ArenaEnemy, mainVariables.Characters_ArenaMage);
                            Clear_All_Buttons(btnArray);
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = false;
                            GivenDialogbox.Dialogbox_Name.Text = "Magier";
                            switch (option)
                            {
                                case 5:
                                    if(Check_Item_Above_0(7))
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Die Augen des Magiers glühen, und sehen euch voller Verachtung an. Gerade noch rechtzeitig haltet Ihr den Spiegel in die Höhe, um den paralysierenden Blick des" +
                                            "Magiers abzuwehren. Der Spiegel zerbricht, doch der Magier fällt zu Boden, und erneut ruft die Menge, es zu beenden.";
                                        GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Gnade walten lassen";
                                        GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Es beenden.";
                                    }
                                    else if(Roll_Stat(mainVariables.Character_Intelligence, 80))
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Der Magier wirkt einen Zauber, doch Ihr kennt ihn auch. \"Malphis Blick der Medusa\" - Ihr flüstert die Gegenworte, und der paralysierende Zauber des Magiers wird auf ihn zurück geworfen." +
                                            "Erneut ruft die Menge danach, es zu beenden.";
                                        GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Gnade walten lassen.";
                                        GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Es beenden.";
                                    }
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Der Magier spricht einen Zauberspruch, dessen Worte Ihr nicht versteht, und ihm nächsten Moment fallt Ihr" +
                                            "wie versteinert zu Boden. Ihr seht das Grinsen auf seinem Gesicht, doch winkt er ab, und lässt euch ziehen, mit den Worten \"Meiner nicht würdig.\"";
                                        GivenDialogbox.Dialogbox_ButtonThree.Visible = true; GivenDialogbox.Dialogbox_ButtonThree.Text = "Gehen.";
                                    }
                                    break;
                                
                                case 1:
                                    GivenDialogbox.Dialogbox_Text.Text = "Ihr ignoriert die buhende Menge, und lasst den Magier von dannen ziehen. Er wird wahrscheinlich niemals Euer bester Freund, doch das Licht in euch wird stärker. Der letzte Gegner ist ein... Riesiges Eichhörnchen?";
                                    mainVariables.Character_Honor++;
                                    mainVariables.Characters_Jorn_Progression++;
                                    GivenDialogbox.Dialogbox_ButtonFour.Visible = true; GivenDialogbox.Dialogbox_ButtonFour.Text = "Zum letzten Kampf.";
                                    break;
                                case 2:
                                    GivenDialogbox.Dialogbox_Text.Text = "Der arrogante Magier hat bekommen, was er verdient, und erneut jubelt euch die Menge zu, und einzelne Blumen werden in eure Richtung geworfen. Die Sonne strahlt hell, doch das Licht in euch schwindet. Der nächste Kampf ist ein..." +
                                        "riesiges Eichhörnchen?";
                                    mainVariables.Character_Honor--;
                                    mainVariables.Characters_Jorn_Progression++;
                                    GivenDialogbox.Dialogbox_ButtonFour.Visible = true; GivenDialogbox.Dialogbox_ButtonFour.Text = "Zum letzten Kampf.";
                                    break;
                                case 3:
                                    if (!mainVariables.Characters_JacksKittenSaved)
                                    { GivenGameStart.Characters_KittenPictureBox.Visible = true; }
                                    Form_Background_Change(GivenGameStart, mainVariables.Background_City);
                                    GivenGameStart.Characters_ArenaEnemy.Visible = false;
                                    End_Dialog(GivenDialogbox);
                                    break;
                            }
                            break;//END SECOND ENCOUNTER
                        case 2://START THIRD ENCOUNTER
                            Fill_PictureBox(GivenGameStart.Characters_ArenaEnemy, mainVariables.Characters_ArenaMage);
                            Clear_All_Buttons(btnArray);
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = false;
                            GivenDialogbox.Dialogbox_Name.Text = "Riesiges Eichhörnchen";
                            GivenGameStart.Characters_ArenaEnemy.Image = mainVariables.Characters_ArenaSquirrel;
                            switch (option)
                            {
                                case 4:
                                    if(Check_Item_Above_0(8))
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Auch wenn das Eichhörnchen zuerst verwirrt ist, zieht Ihr eine gewaltige Nuss aus Eurer Tasche, und legt sie auf den Boden. Das Eichhörnchen beginnt sofort daran zu knabbern, und ist sichtlich" +
                                            " abgelenkt. Die Menge schreit danach, es zu beenden. Sie wollen Eichhörnchenblut.";
                                        GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Gnade walten lassen.";
                                        GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Es beenden.";
                                    }
                                    else if(Roll_Stat(mainVariables.Character_Agility, 80))
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Auch wenn das Eichhörnchen versucht euch anzuknabbern, eure agilen Bewegungen weichen Allem aus, und schließlich landet Ihr unbehelligt auf" +
                                            " dem Rücken des riesigen Nagetiers. Die Menge schreit danach, es zu beenden. Sie wollen Eichhörnchenblut.";
                                        GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Gnade walten lassen.";
                                        GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Es beenden.";
                                    }
                                    else
                                    {
                                        GivenDialogbox.Dialogbox_Text.Text = "Das Eichhörnchen ist zu schnell, und ganz auf euch konzentriert. Ihr bemerkt nur noch einen riesigen, wuschigen Schweif, und ihr werdet" +
                                            " davon geschleudert. Eure letzte Möglichkeit bleibt zu fliehen. Gedemütigt von einem Eichhörnchen im letzten Kampf spürt Ihr, wie das Licht in euch schwindet.";
                                        GivenDialogbox.Dialogbox_ButtonThree.Visible = true; GivenDialogbox.Dialogbox_ButtonThree.Text = "Verschwinden";
                                        mainVariables.Character_Honor--;
                                    }
                                    break;
                                case 1:
                                    GivenDialogbox.Dialogbox_Text.Text = "Ihr streichelt das Eichhörnchen nochmal, bevor Ihr erhobenen Hauptes die Arena verlasst. Ihr habt Niemandem etwas zu beweisen, und das Licht" +
                                        " in euch wird stärker.";
                                    mainVariables.Character_Honor++;
                                    GivenGameStart.Characters_ArenaEnemy.Visible = false;
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenGameStart.Characters_Vendor.Visible = true;
                                    GivenGameStart.Characters_Jorn.Visible = true;
                                    if (!mainVariables.Characters_KittenClicked)
                                    { GivenGameStart.Characters_KittenPictureBox.Visible = false; }
                                    GivenGameStart.UI_GoSomewhere.Visible = true;
                                    break;
                                case 2:
                                    GivenDialogbox.Dialogbox_Text.Text = "Ihr gebt der Menge, was sie wünscht. Sie jubeln, und sie feiern, und Ihr verbeugt euch, während das Licht in euch schwindet. Es ist Zeit zu gehen.";
                                    mainVariables.Character_Honor--;
                                    GivenGameStart.Characters_ArenaEnemy.Visible = false;
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenGameStart.Characters_Vendor.Visible = true;
                                    GivenGameStart.Characters_Jorn.Visible = true;
                                    if (!mainVariables.Characters_KittenClicked)
                                    { GivenGameStart.Characters_KittenPictureBox.Visible = false; }
                                    GivenGameStart.UI_GoSomewhere.Visible = true;
                                    break;
                                case 3:
                                case 5:
                                    mainVariables.Characters_Jorn_Progression++;
                                    if (!mainVariables.Characters_JacksKittenSaved)
                                    { GivenGameStart.Characters_KittenPictureBox.Visible = true; }
                                    Form_Background_Change(GivenGameStart, mainVariables.Background_City);
                                    GivenGameStart.Characters_ArenaEnemy.Visible = false;
                                    End_Dialog(GivenDialogbox);
                                    break;
                            }
                            break; //END THIRD ENCOUNTER
                        case 3:
                            switch(option)
                            {
                                case 0:
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenDialogbox.Dialogbox_Text.Text = "Mhh Mhh. Es ist wie es ist, Wanderer. Lebt wohl.";
                                    break;
                                case 5:
                                    End_Dialog(GivenDialogbox);
                                    break;
                            }
                            break;
                    }
                    break; //END JORN/ARENA

                case "Lea":
                    Clear_All_Buttons(btnArray);
                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = false;
                    GivenDialogbox.Dialogbox_Name.Text = "Lea";
                    switch(option)
                    {
                        case 0:
                                if (!mainVariables.Characters_Lea_WoodAllowed)
                                {
                                    GivenDialogbox.Dialogbox_Text.Text = "Grüße, Fremder. Mein Name ist Lea, ich bin die Holzfällerin in der Gegend. Falls Ihr Interesse habt könnt ihr mir helfen ein wenig Holz zu hacken, ich bezahle auch dafür.";
                                    GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Klar, warum nicht?";
                                    GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Gerade nicht.";
                                }
                                else
                                {
                                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                    GivenDialogbox.Dialogbox_Text.Text = "Danke nochmal für die Hilfe. Bearbeitet einfach das Holz hier, und ich gebe euch eine angemessene Bezahlung.";
                                }

                            break;
                        case 1:
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            GivenDialogbox.Dialogbox_Text.Text = "Vielen Dank! Hier, nehmt diese Axt und fang an den Stapel zu bearbeiten. Sobald Ihr etwas erledigt hat, gebe ich Euch die Kristalle.";
                            mainVariables.Characters_Lea_WoodAllowed = true;
                            break;
                        case 3:
                            if(!mainVariables.Characters_Lea_CutOnce)
                            {
                                mainVariables.Characters_Lea_CutOnce = true;
                                GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                GivenDialogbox.Dialogbox_Text.Text = "\"Hier sind die Kristalle\", Lea legt euch einige Kristalle in eure Hand. \"Ich kann gern weitere Hilfe gebrauchen, ich zahl auch weiter\"." +
                                    " Euch durchströmt das gute Gefühl harter, ehrlicher Arbeit, und das Licht in euch strahlt heller.\"Übrigens soll heute in der Arena ein hungriger Wolf sein. Ich frage mich" +
                                    "ob ein Stück Fleisch hilft?\"";
                                mainVariables.Character_Crystals += 5;
                                mainVariables.Character_Honor++;
                            }
                            else
                            {
                                GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                GivenDialogbox.Dialogbox_Text.Text = "\"Hier sind die Kristalle\", Lea legt euch einige Kristalle in eure Hand. \"Ich kann gern weitere Hilfe gebrauchen, ich zahl auch weiter\".";
                                mainVariables.Character_Crystals += 5;
                            }
                            break;                        
                        case 2:
                        case 5:
                            End_Dialog(GivenDialogbox);
                            break;
                    }
                    break; //End Lea

                case "Vendor":
                    Clear_All_Buttons(btnArray);
                    GivenDialogbox.Dialogbox_Name.Text = "Ladeninhober";
                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                    if (!mainVariables.Characters_Vendor_RopeBought)
                    {GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Seil kaufen (15 Kristalle)"; }
                    if (!mainVariables.Characters_Vendor_TestBought)
                    {GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Trainingstest kaufen (10 Kristalle)";}

                    switch(option)
                    {
                        case 0:
                            if(!mainVariables.Characters_Vendor_TestBought || !mainVariables.Characters_Vendor_RopeBought)
                            GivenDialogbox.Dialogbox_Text.Text = "Hohoho, holt euch Seile und Übungstests für Knappen, für die richtige Menge an Kristallen, versteht sich.";
                            else
                            { GivenDialogbox.Dialogbox_Text.Text = "Hohoho, leider ausverkauft, vielen Dank für Eure treue Kundschaft."; }
                            break;
                        case 1:
                            if(mainVariables.Character_Crystals >= 15)
                            {
                                GivenDialogbox.Dialogbox_ButtonOne.Visible = false;
                                GivenDialogbox.Dialogbox_Text.Text = "Hohoho, viel Spaß mit dem Seil!";
                                Change_Item_Count(4, 1, '+');
                                mainVariables.Characters_Vendor_RopeBought = true;
                                GivenGameStart.Items_Rope.Visible = false;
                                mainVariables.Character_Crystals -= 15;
                                GivenGameStart.UI_Crystal_Label.Text = mainVariables.Character_Crystals.ToString();
                            }
                            else
                            {
                                GivenDialogbox.Dialogbox_Text.Text = "Hohoho, nicht genug Kristalle. Zu schade.";
                            }
                            break;
                        case 2:
                            if (mainVariables.Character_Crystals >= 10)
                            {
                                GivenDialogbox.Dialogbox_ButtonTwo.Visible = false;
                                GivenDialogbox.Dialogbox_Text.Text = "Hohoho, viel Spaß mit dem Test!";
                                Change_Item_Count(3, 1, '+');
                                mainVariables.Characters_Vendor_TestBought = true;
                                GivenGameStart.Items_FinishedList.Visible = false;
                                mainVariables.Character_Crystals -= 10;
                                GivenGameStart.UI_Crystal_Label.Text = mainVariables.Character_Crystals.ToString();
                            }
                            else
                            {
                                GivenDialogbox.Dialogbox_Text.Text = "Hohoho, nicht genug Kristalle. Zu schade.";
                            }
                            break;
                        default:
                            End_Dialog(GivenDialogbox);
                            break;
                    }
                    break; //End VENDOR
                case "Valeria":
                    Clear_All_Buttons(btnArray);
                    GivenDialogbox.Dialogbox_Name.Text = "Valeria";
                    GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                    
                    switch (option)
                    {
                        case 0:
                            if(!mainVariables.Characters_ValeriaHelped)
                            {
                                GivenDialogbox.Dialogbox_Text.Text = "Ihr müsst mir dabei helfen für den Knappentest zu lernen. Ich lasse euch keine Wahl! " +
                                    "Ich würde mir ja den Übungsbogen beim Händler holen, aber ich habe keine Kristalle...";
                                GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Klar, warum nicht?";
                                GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Gerade nicht.";
                            }
                            else
                            {GivenDialogbox.Dialogbox_Text.Text = "Danke für Eure Hilfe! Ich bin mir sicher, nun kann ich es schaffen.";}
                            break;
                        case 1:
                            if(Check_Item_Above_0(3))
                            {
                                Change_Item_Count(3, 1, '-');
                                GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                GivenDialogbox.Dialogbox_Text.Text = "Mit dem Testzettel seid Ihr ohne weiteres in Lage, für den Knappentest mit Valeria zu üben. Hey, vielleicht solltet " +
                                    "Ihr auch zum Knappen werden? Das Licht in euch wird stärker!";
                                mainVariables.Character_Honor++;
                                mainVariables.Characters_ValeriaHelped = true;
                            }
                            else if(Roll_Stat(mainVariables.Character_Intelligence, 80))
                            {
                                GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                GivenDialogbox.Dialogbox_Text.Text = "Ihr erinnert euch daran, in eurer Freizeit mal für diesen Test gelernt zu haben. Ihr konntet Valeria dabei helfen, und das Licht" +
                                    " in euch wird stärker!";
                                mainVariables.Character_Honor++;
                                mainVariables.Characters_ValeriaHelped = true;
                            }
                            else
                            {
                                GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                                GivenDialogbox.Dialogbox_Text.Text = "Ihr habt zwar keine Ahnung und keinen Plan, doch redet Ihr vor euch hin. Ihr seid euch recht sicher, " +
                                    "dass Valeria nun durchfallen wird, aber dies ist nicht mehr Euer Problem. Das Licht in euch wird schwächer.";
                                mainVariables.Character_Honor--;
                                mainVariables.Characters_ValeriaHelped = true;
                            }
                            break;
                        default:
                            End_Dialog(GivenDialogbox);
                            break;
                    }
                    break;
                case "Goddess":
                    Clear_All_Buttons(btnArray);
                    GivenDialogbox.Dialogbox_Name.Text = "Göttin des Waldes";
                    switch (option)
                    {
                        case 11:
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            GivenDialogbox.Dialogbox_Text.Text = "Ihr habt mich enttäuscht, " + mainVariables.Character_Name + ". Ich habe gehofft ihr wäret zu größerem Berufen," +
                                " doch eure Selbstsucht, oder euer Wunsch, alles so schnell wie möglich zu beenden, verheißen Euch eine dunkle Zukunft. Ich bin die Schützerin des" +
                                " Waldes und werde dies nicht zulassen. Fortan lebt Ihr als eine Kreatur des Waldes. Lebt wohl.";
                            break;
                        case 12:
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            GivenDialogbox.Dialogbox_Text.Text = mainVariables.Character_Name + ", Ihr habt euch Mühe gegeben, doch vielleicht war Euch das Glück heute nicht holt." +
                                " Ich hoffe, dass Ihr nächstes Mal wieder versucht, zu mir zu kommen. Wisset, nichts was Ihr heute erlebt habt war wirklich vom Glück abhängig.";
                            break;
                        case 13:
                            GivenDialogbox.Dialogbox_Text.Text = mainVariables.Character_Name + ", Ihr habt heute viel Gutes getan, und Euch nicht der Dunkelhein anheim fallen lassen." +
                                " Ich möchte Euch anbieten an meiner statt zu herrschen, und meinen Thron aus Rinde und Borke in Besitz zu nehmen. Aber nur, falls Ihr glaubt, " +
                                "es mehr zu beherrschen als... Ich.";
                            GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Natürlich.";
                            GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Nein, Göttin des Waldes.";
                            break;
                        case 1:
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            GivenDialogbox.Dialogbox_Text.Text = "Ihr habt mich enttäuscht, " + mainVariables.Character_Name + ". So nah am Ziel, und doch beschließt Ihr, auf den letzten Metern" +
                                " der Dunkelheit anheim zu fallen. Geht, und kehrt nie wieder zurück.";
                            break;
                        case 2:
                            GivenDialogbox.Dialogbox_NextTextPicB.Visible = true;
                            GivenDialogbox.Dialogbox_Text.Text = "Und so, selbst im Angesicht der letzten Versuchung, bleibt Ihr stark." + mainVariables.Character_Name + ", Ich " +
                                "erhebe euch zu einem Champion des Waldes und der Menschen, möget Ihr in meinem Willen der Welt betreten, und sie beschützen. Euer Abendteuer... fängt" +
                                " hier erst an.";
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                    break; //End Goddess
                case "Ending":
                        switch(option)
                    {
                        case 0:
                            GivenDialogbox.Dialogbox_Text.Text = "Ihr seht in der Ferne den Dunklen Eingang des Waldtempels. Ihr wisst, dass die Herrin des Waldes über eure Seele richten wird, " +
                                "eher sie entscheidet, ob Ihr würdig seid. Fühlt Ihr euch bereit, den Tempel zu betreten?";
                            GivenDialogbox.Dialogbox_ButtonOne.Visible = true; GivenDialogbox.Dialogbox_ButtonOne.Text = "Ich bin bereit.";
                            GivenDialogbox.Dialogbox_ButtonTwo.Visible = true; GivenDialogbox.Dialogbox_ButtonTwo.Text = "Ich brauche noch mehr Zeit.";
                            break;
                        case 1:
                            mainVariables.StoryLine_Progress++;
                            GameStart gameStart2 = new GameStart(this, mainVariables, givenMainFrame);
                            gameStart2.Show();
                            GivenGameStart.Close(); ;                            
                            End_Dialog(GivenDialogbox);
                            break;
                        case 2:
                            End_Dialog(GivenDialogbox);
                            break;
                    }
                    break;

            }//end of the NAME switch statement
        }
    }
}