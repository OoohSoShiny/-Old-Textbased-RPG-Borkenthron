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
    public partial class Inventory : Form
    {
        MainMethods mainMethods;
        MainVariables mainVariables;
        GameStart gameStart;
        PictureBox[] inventoryPicbArray; //Size of item pics: 26;25
        List<string> inventoryNameList;

        //Creating necessary PictureBox array and the inventory list for creating Inventory
        public Inventory(MainMethods givenMainMethod, MainVariables givenMainVariables, GameStart givenGameStart)
        {
            InitializeComponent();
            inventoryPicbArray = new PictureBox[]  {picBItemOne, picBItemTwo, picBItemThree, picBItemFour, picBItemFive, picBItemSix, picBItemSeven, picBItemEight, 
                                                    picBItemNine, picBItemTen, picBItemEleven, picBItemTwelve, picBItemThirteen, picBItemFourteen, picBItemFifteen, picBItemSixteen};
            inventoryNameList = new List<string>();
            
            mainMethods = givenMainMethod;
            mainVariables = givenMainVariables;
            gameStart = givenGameStart;

            mainMethods.Fill_PictureBox(picBInventoryClose, mainVariables.UserInterface_InventoryClose);
            mainMethods.Form_Background_Change(this, mainVariables.UserInterface_InventoryBackground);

            //Filling the inventory slots by going through each item possible, checking if the countvalue is above 0, inventory name list is necessary for the on click
            //event of each picture box, item count not used yet but if i want to but a label or something on health potions, this might come in handy
            int picBWalker = 0;
            for(int i = 0; i < mainVariables.Items_List.Count; i++)
            {
                string[] stringBreaker = mainVariables.Items_List[i].Split('_');
                if(mainMethods.Check_Item_Above_0(i))
                {
                    int itemcount = Int32.Parse(stringBreaker[1]);
                    mainMethods.Fill_PictureBox(inventoryPicbArray[picBWalker], mainVariables.Items_Bitmap_List[i]);
                    inventoryNameList.Add(stringBreaker[0]);
                    picBWalker++;
                }
            }
        }

        //Inventar schließen
        private void picBInventoryClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //When the itemslots are clicked
        private void picBItemOne_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[0], picBItemOne, 0);    }

        private void picBItemTwo_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[1], picBItemTwo, 1);    }

        private void picBItemThree_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[2], picBItemThree, 2);  }

        private void picBItemFour_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[3], picBItemFour, 3);   }

        private void picBItemFive_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[4], picBItemFive, 4);   }

        private void picBItemSix_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[5], picBItemSix, 5);    }

        private void picBItemSeven_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[6], picBItemSeven, 6);  }

        private void picBItemEight_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[7], picBItemEight, 7);  }

        private void picBItemNine_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[8], picBItemNine, 8);   }

        private void picBItemTen_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[9], picBItemTen, 9);    }

        private void picBItemEleven_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[10], picBItemEleven, 10);   }

        private void picBItemTwelve_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[11], picBItemTwelve, 11);   }

        private void picBItemThirteen_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[12], picBItemThirteen, 12); }

        private void picBItemFourteen_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[13], picBItemFourteen, 13); }

        private void picBItemFifteen_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[14], picBItemFifteen, 14);  }

        private void picBItemSixteen_Click(object sender, EventArgs e)
        {   mainMethods.Inventory_ItemClicked(inventoryNameList[15], picBItemSixteen, 15);  }

        private void Inventory_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
