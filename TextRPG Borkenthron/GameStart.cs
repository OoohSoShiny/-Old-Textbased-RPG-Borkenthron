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
    public partial class GameStart : Form
    {
        MainMethods mainMethods;
        MainVariables mainVariables;
        MainFrame mainFrame;
        Inventory inventory;
        IngameMenu inGameMenu;
        Main_Dialog main_Dialog;

        public PictureBox Characters_KittenPictureBox
        { get { return picBKitten; } set { picBKitten = value; } }
        public PictureBox Characters_StuckKitten
        { get { return picBStuckKitten; } set { picBStuckKitten = value; } }
        public PictureBox Characters_ArenaEnemy
        { get { return picBArenaEnemy; } set { picBArenaEnemy = value; } }
        public PictureBox Items_Rope
        { get { return picBVendorRope; } set { picBVendorRope = value; } }
        public PictureBox Items_FinishedList
        { get { return picBVendorTest; } set { picBVendorTest = value; } }

        public Label UI_Health_Label
        { get { return lblUiHealth; } set { lblUiHealth = value; } }
        public Label UI_Crystal_Label
        { get { return lblUiMana; } set { lblUiMana = value; } }


        //default start when game is loaded via start new game
        public GameStart(MainMethods givenMainMethods, MainVariables givenMainVariables, MainFrame givenMainFrame)
        {
            InitializeComponent();
            Initializing_Gamestart(givenMainMethods, givenMainVariables, givenMainFrame);
        }

        private void Initializing_Gamestart(MainMethods givenMainMethods, MainVariables givenMainVariables, MainFrame givenMainFrame)
        {
            mainMethods = givenMainMethods;
            mainVariables = givenMainVariables;
            mainFrame = givenMainFrame;
            inGameMenu = new IngameMenu(mainVariables, mainMethods, this, mainFrame);
            oneSecondTimer = new Timer();
            lblUiMana.Text = mainVariables.Character_Crystals.ToString();

            try
            { mainVariables.Music_Soundplayer.Stop(); }
            catch(Exception ex) { }

            //What is loaded depends on the place, case 1 is starting area
            switch(mainVariables.StoryLine_Progress)
            {
                case 1:
                    mainMethods.Form_Background_Change(this, mainVariables.FirstScreen_Background);
                    mainMethods.Character_PictureBox(mainVariables.Character_Picture, picBMainHero);
                    mainMethods.Fill_PictureBox(picBSideCharOne, mainVariables.Characters_Maria_Bitmap); picBSideCharOne.Visible = true;
                    if (mainVariables.Characters_Maria_Progression != 10)
                    {
                        mainMethods.Fill_PictureBox(PicBGoFront, mainVariables.UserInterface_TowardsForest);
                        mainMethods.Fill_PictureBox(PicBFlower1, mainVariables.Items_SingleFlowerBM); PicBFlower1.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower2, mainVariables.Items_SingleFlowerBM); PicBFlower2.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower3, mainVariables.Items_SingleFlowerBM); PicBFlower3.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower4, mainVariables.Items_SingleFlowerBM); PicBFlower4.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower5, mainVariables.Items_SingleFlowerBM); PicBFlower5.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower6, mainVariables.Items_SingleFlowerBM); PicBFlower6.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower7, mainVariables.Items_SingleFlowerBM); PicBFlower7.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower8, mainVariables.Items_SingleFlowerBM); PicBFlower8.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower9, mainVariables.Items_SingleFlowerBM); PicBFlower9.Visible = true;
                        mainMethods.Fill_PictureBox(PicBFlower10, mainVariables.Items_SingleFlowerBM); PicBFlower10.Visible = true;
                    }
                    break;
            
            //case 2 is forest
                case 2:
                    mainVariables.UserInterface_DialogboxActive = true;
                    mainMethods.Form_Background_Change(this, mainVariables.Background_Forest);
                    mainMethods.Fill_PictureBox(picBGoblin, mainVariables.Characters_GoblinBM); picBGoblin.Visible = true;
                    main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Goblin", this, mainFrame);
                    main_Dialog.Show();
                    break;
            
            //case 3 is village
                case 3:
                    mainMethods.Form_Background_Change(this, mainVariables.Background_City);
                    mainMethods.Fill_PictureBox(picBJack, mainVariables.Characters_JackBM);
                    if (!mainVariables.Characters_KittenClicked)
                    { mainMethods.Fill_PictureBox(picBKitten, mainVariables.Characters_KittenBM); }
                    if (!mainVariables.Characters_JacksKittenSaved)
                    { mainMethods.Fill_PictureBox(picBStuckKitten, mainVariables.Characters_StuckKittenBM); }
                    mainMethods.Fill_PictureBox(picBJorn, mainVariables.Characters_JornBM);
                    picBJorn.Location = new Point(438,263);
                    picBJack.Location = new Point(88, 175);
                    mainMethods.Fill_PictureBox(PicBLea, mainVariables.Characters_LeaBM);
                    mainMethods.Fill_PictureBox(picBLeaWood, mainVariables.Characters_Lea_Wood);
                    if(!mainVariables.Characters_Vendor_TestBought)
                    { mainMethods.Fill_PictureBox(picBVendorTest, mainVariables.Items_FinishedTestBM); }
                    if(!mainVariables.Characters_Vendor_RopeBought)
                    { mainMethods.Fill_PictureBox(picBVendorRope, mainVariables.Items_FinishedTestBM); }
                    mainMethods.Fill_PictureBox(picBValeria, mainVariables.Characters_Valeria);

                    break;
            }
            mainMethods.Character_PictureBox(mainVariables.Character_Picture, picBMainHero);
            mainMethods.Fill_PictureBox(picBHealth, mainVariables.UserInterface_Heart);
            mainMethods.Fill_PictureBox(PicBMana, mainVariables.UserInterface_Crystal);
            mainMethods.Fill_PictureBox(picBInventory, mainVariables.UserInterface_Inventory);
            mainMethods.Fill_PictureBox(picBMenu, mainVariables.UserInterface_Menu);

            lblUiHealth.Text = mainVariables.Character_Health.ToString();
            lblUiMana.Text = mainVariables.Character_Crystals.ToString();
            // 0) Flowercircle 1) Health potion 2) Sword 3) Finished test 4) Rope 5) Super axe 6) Chicken leg 7) Mirror 8) Giant nut 9) Single flower

            //Adding items to the itemlist and adding bitmaps for those item in a second List
            mainVariables.Items_List.Add(mainVariables.Items_FlowerCircle); mainVariables.Items_List.Add(mainVariables.Items_HealthPotion); mainVariables.Items_List.Add(mainVariables.Items_Sword);
            mainVariables.Items_List.Add(mainVariables.Items_FinishedTest); mainVariables.Items_List.Add(mainVariables.Items_Rope); mainVariables.Items_List.Add(mainVariables.Items_SuperAxe);
            mainVariables.Items_List.Add(mainVariables.Items_ChickenLeg); mainVariables.Items_List.Add(mainVariables.Items_Mirror); mainVariables.Items_List.Add(mainVariables.Items_GiantNut);
            mainVariables.Items_List.Add(mainVariables.Items_SingleFlower);
            //--            
            mainVariables.Items_Bitmap_List.Add(mainVariables.Items_FlowerCircleBM); mainVariables.Items_Bitmap_List.Add(mainVariables.Items_HealthPotionBM); mainVariables.Items_Bitmap_List.Add(mainVariables.Items_SwordBM);
            mainVariables.Items_Bitmap_List.Add(mainVariables.Items_FinishedTestBM); mainVariables.Items_Bitmap_List.Add(mainVariables.Items_RopeBM); mainVariables.Items_Bitmap_List.Add(mainVariables.Items_SuperAxeBM);
            mainVariables.Items_Bitmap_List.Add(mainVariables.Items_ChickenLegBM); mainVariables.Items_Bitmap_List.Add(mainVariables.Items_MirrorBM); mainVariables.Items_Bitmap_List.Add(mainVariables.Items_GiantNutBm);
            mainVariables.Items_Bitmap_List.Add(mainVariables.Items_SingleFlowerBM);
        }
        
        //Opens a new inventory up
        private void picBInventory_Click(object sender, EventArgs e)
        {
            inventory = new Inventory(mainMethods, mainVariables, this);
            inventory.Show();
            mainVariables.UserInterface_InventoryActive = true;
        }
        
        //puts other windows in front if user tries to activate main window while other window is open
        private void GameStart_Activated(object sender, EventArgs e)
        {            
            if(mainVariables.UserInterface_InventoryActive)
            { inventory.Activate(); }
            else if(mainVariables.UserInterface_IngameMenuActive)
            { inGameMenu.Activate(); }
            else if(mainVariables.UserInterface_DialogboxActive)
            { main_Dialog.Activate(); }
        }

        //one second timer, no of use yet
        private void oneSecondTimer_Tick(object sender, EventArgs e)
        {
            mainVariables.Tutorial_TimeCounter++;
            if(mainVariables.Tutorial_TimeCounter >=10)
            {

            }
        }

        //opens ingame menu
        private void picBMenu_Click(object sender, EventArgs e)
        {
            inGameMenu.Show();
            mainVariables.UserInterface_IngameMenuActive = true;
        }

        //Hidden object: Click on health gives all items once 
        private void picBHealth_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            { mainMethods.Change_Item_Count(i, 1, '+'); }
        }

        //Clicking on Marie
        private void picBSideCharOne_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Marie", this, mainFrame);
            main_Dialog.Show();
            mainVariables.UserInterface_DialogboxActive = true;
        }

        //Flowers that are collectable
        #region flowers
        private void PicBFlower1_Click(object sender, EventArgs e)
        {
            if(mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower1.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower2_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower2.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower3_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower3.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower4_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower4.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower5_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower5.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower6_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower6.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower7_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower7.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower8_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower8.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower9_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower9.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }

        private void PicBFlower10_Click(object sender, EventArgs e)
        {
            if (mainVariables.FirstScene_CollectFlower)
            {
                PicBFlower10.Visible = false;
                mainMethods.Change_Item_Count(9, 1, '+');
            }
        }
        #endregion

        //Clicking on the Goblin
        private void picBGoblin_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Goblin", this, mainFrame);
            main_Dialog.Show();
            mainVariables.UserInterface_DialogboxActive = true;
        }

        //Going to the forest
        private void PicBGoFront_Click(object sender, EventArgs e)
        { 
            switch (mainVariables.StoryLine_Progress)
            {
                case 1:
                mainVariables.StoryLine_Progress++;
                GameStart gameStart = new GameStart(mainMethods, mainVariables, mainFrame);
                gameStart.Show();
                this.Close();
                    break;
            }
        }
        //The amazing flying kitty
        private void picBKitten_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Kitten", this, mainFrame);
            main_Dialog.Show();
        }
        //Jack the kittenless
        private void picBJack_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Jack", this, mainFrame);
            main_Dialog.Show();
        }
        //stuck kitten
        private void picBStuckKitten_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "StuckKitten", this, mainFrame);
            main_Dialog.Show();
        }

        private void picBJorn_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Jorn", this, mainFrame);
            main_Dialog.Show();
        }

        private void PicBLea_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Lea", this, mainFrame);
            main_Dialog.Show();
        }

        private void picBLeaWood_Click(object sender, EventArgs e)
        {
            if (mainVariables.Characters_Lea_WoodAllowed)
            {
                mainVariables.Characters_Lea_ChopCount++;
                if (mainVariables.Characters_Lea_ChopCount >= 10)
                {
                    mainVariables.Characters_Lea_ChopCount = 0;
                    main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Lea", this, mainFrame, 3);
                    main_Dialog.Show();
                    lblUiMana.Text = mainVariables.Character_Crystals.ToString();
                }
            }
        }

        private void picBVendor_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Vendor", this, mainFrame);
            main_Dialog.Show();
        }

        private void picBValeria_Click(object sender, EventArgs e)
        {
            main_Dialog = new Main_Dialog(mainVariables, mainMethods, "Valeria", this, mainFrame);
            main_Dialog.Show();
        }
    }
}
