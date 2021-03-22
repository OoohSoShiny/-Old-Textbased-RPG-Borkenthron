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
        Dialogbox dialogBox;

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

            switch(mainVariables.StoryLine_Progress)
            {
                case 1:
                    mainMethods.Form_Background_Change(this, mainVariables.FirstScreen_Background);
                    mainMethods.Character_PictureBox(mainVariables.Character_Picture, picBMainHero);
                    mainMethods.Fill_PictureBox(PicBFlower1, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower2, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower3, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower4, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower5, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower6, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower7, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower8, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower9, mainVariables.Items_SingleFlowerBM);
                    mainMethods.Fill_PictureBox(PicBFlower10, mainVariables.Items_SingleFlowerBM);
                    break;
            }            
            mainMethods.Fill_PictureBox(picBHealth, mainVariables.UserInterface_Heart);
            mainMethods.Fill_PictureBox(PicBMana, mainVariables.UserInterface_Crystal);
            mainMethods.Fill_PictureBox(picBInventory, mainVariables.UserInterface_Inventory);
            mainMethods.Fill_PictureBox(picBMenu, mainVariables.UserInterface_Menu);
            mainMethods.Fill_PictureBox(picBSideCharOne, mainVariables.Characters_Maria_Bitmap);

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

        private void picBInventory_Click(object sender, EventArgs e)
        {
            inventory = new Inventory(mainMethods, mainVariables, this);
            inventory.Show();
            mainVariables.UserInterface_InventoryActive = true;
        }
        
        private void GameStart_Activated(object sender, EventArgs e)
        {
            
            if(mainVariables.UserInterface_InventoryActive)
            {
                inventory.Activate();
            }
            else if(mainVariables.UserInterface_IngameMenuActive)
            {
                inGameMenu.Activate();
            }
            else if(mainVariables.UserInterface_DialogboxActive)
            {
                dialogBox.Activate();
            }
        }

        private void oneSecondTimer_Tick(object sender, EventArgs e)
        {
            mainVariables.Tutorial_TimeCounter++;
            if(mainVariables.Tutorial_TimeCounter >=10)
            {

            }
        }

        private void picBMenu_Click(object sender, EventArgs e)
        {
            inGameMenu.Show();
            mainVariables.UserInterface_IngameMenuActive = true;
        }

        private void picBHealth_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            { mainMethods.Change_Item_Count(i, 1, '+'); }
        }

        private void PicBMana_Click(object sender, EventArgs e)
        {
            mainMethods.Change_Item_Count(1, 1, '+');
        }

        private void picBSideCharOne_Click(object sender, EventArgs e)
        {
            mainVariables.UserInterface_DialogboxActive = true;
            dialogBox = new Dialogbox(mainVariables, mainMethods, "Marie");
            dialogBox.Show();
        }

        //Flowers that are collectiable
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
    }
}
