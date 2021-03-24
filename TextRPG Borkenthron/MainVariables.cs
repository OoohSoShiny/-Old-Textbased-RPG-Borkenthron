using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextRPG_Borkenthron
{
    public class MainVariables
    {   
        //Allround variables
        Random randomizer = new Random();
        
        SoundPlayer musicSoundPlayer = new SoundPlayer(@"Soundfiles\Warm_Light.wav");
        public SoundPlayer Music_Soundplayer
        { get { return musicSoundPlayer; } set { musicSoundPlayer = value; } }
        public Random Random_Number
        { get { return randomizer; } set { randomizer = value; } }
        bool focusInventory = false;
        bool focusDialog = false;
        bool focusIngameMenu = false;
        public bool UserInterface_InventoryActive
        { get { return focusInventory; } set { focusInventory = value; } }
        public bool UserInterface_IngameMenuActive
        { get { return focusIngameMenu; } set { focusIngameMenu = value; } }
        public bool UserInterface_DialogboxActive
        { get { return focusDialog; } set { focusDialog = value; } }

        //The integer to progress in the storyline
        int storyLineProgressor = 1;
        public int StoryLine_Progress
        { get { return storyLineProgressor; } set { storyLineProgressor = value; } }


        #region Bitmaps
        //Main Menu pictures, font used: LittleLordFontleroy
        readonly Bitmap mainMenuBackground = new Bitmap(@"Backgrounds\MenuBackground300200.jpg");
        readonly Bitmap mainMenuNewGame = new Bitmap(@"Icons\mainMenuNewGame.png");
        readonly Bitmap mainMenuLoadGame = new Bitmap(@"Icons\mainMenuLoadGame.png");
        readonly Bitmap mainMenuExitGame = new Bitmap(@"Icons\mainMenuExitGame.png");
        readonly Bitmap mainMenuNamePlate = new Bitmap(@"Icons\mainMenuGameName.png");

        public Bitmap MainMenu_NamePlate
        { get { return mainMenuNamePlate; } }
        public Bitmap MainMenu_Background //284; 219
        { get { return mainMenuBackground; } }
        public Bitmap MainMenu_NewGameIcon //259; 50
        { get { return mainMenuNewGame; } }
        public Bitmap MainMenu_LoadGame
        { get { return mainMenuLoadGame; } }
        public Bitmap MainMenu_ExitGame
        { get { return mainMenuExitGame; } }

        //Main Character Pictures 100; 124
        readonly Bitmap mainCharacterOne = new Bitmap(@"Characters\MainCharOne.png");
        readonly Bitmap mainCharacterTwo = new Bitmap(@"Characters\MainHeroTwo.png");
        readonly Bitmap mainCharacterThree = new Bitmap(@"Characters\MainHeroThree.png");

        public Bitmap MainCharacter_OnePic
        { get { return mainCharacterOne; } }
        public Bitmap MainCharacter_TwoPic
        { get { return mainCharacterTwo; } }
        public Bitmap MainCharacter_ThreePic
        { get { return mainCharacterThree; } }

        //Character Creation Pictures
        readonly Bitmap ccPicNext = new Bitmap(@"Icons\CCNext.png");
        readonly Bitmap ccPicPrevious = new Bitmap(@"Icons\CCPrevious.png");
        readonly Bitmap ccAttributeUp = new Bitmap(@"Icons\CCPlus.png");
        readonly Bitmap ccAttributeMinus = new Bitmap(@"Icons\CCMinus.png");
        readonly Bitmap ccStartAdventure = new Bitmap(@"Icons\CCSend.png");
        readonly Bitmap ccCancelAdventure = new Bitmap(@"Icons\CCBack.png");

        public Bitmap CharacterCreation_PicNext
        { get { return ccPicNext; } }
        public Bitmap CharacterCreation_PicPrevious
        { get { return ccPicPrevious; } }
        public Bitmap CharacterCreation_AttributeUp
        { get { return ccAttributeUp; } }
        public Bitmap CharacterCreation_AttributeDown
        { get { return ccAttributeMinus; } }
        public Bitmap CharacterCreation_Start
        { get { return ccStartAdventure; } }
        public Bitmap CharacterCreation_Cancel
        { get { return ccCancelAdventure; } }

        readonly Bitmap ccBackground = new Bitmap(@"Backgrounds\CCBackground.jpg");
        public Bitmap CharacterCreation_Background
        { get { return ccBackground; } }

        //First Screen Pictures
        readonly Bitmap firstScreenBackground = new Bitmap(@"Backgrounds\GrassBackground500440.jpg");
        public Bitmap FirstScreen_Background
        { get { return firstScreenBackground; } }

        //Standard UI
        readonly Bitmap uiheart = new Bitmap(@"Icons\LifeHeart.png");
        readonly Bitmap uiCrystal = new Bitmap(@"Icons\BlueCrystal.png");
        readonly Bitmap uiInventory = new Bitmap(@"Icons\Inventar.png");
        readonly Bitmap uiMenu = new Bitmap(@"Icons\uiIconMenu.png");
        readonly Bitmap uiBackToMain = new Bitmap(@"Icons\ButtonToMainMenu.png");
        readonly Bitmap uiIngameMenuBackground = new Bitmap(@"Backgrounds\IngameMenuBackground.jpg");

        public Bitmap UserInterface_BackToMainMenu
        { get { return uiBackToMain; } }
        public Bitmap UserInterface_Heart
        { get { return uiheart; } }
        public Bitmap UserInterface_Crystal
        { get { return uiCrystal; } }
        public Bitmap UserInterface_Inventory
        { get { return uiInventory; } }
        public Bitmap UserInterface_Menu
        { get { return uiMenu; } }
        public Bitmap UserInterface_IngameMenuBackground
        { get { return uiIngameMenuBackground; } }

        readonly Bitmap inventoryBackground = new Bitmap(@"Backgrounds\inventoryBasicNew.png");
        readonly Bitmap inventoryClose = new Bitmap(@"Icons\InventoryClose.png");
        public Bitmap UserInterface_InventoryBackground
        {get { return inventoryBackground; } }
        public Bitmap UserInterface_InventoryClose
        { get { return inventoryClose; } }


        //IngameMenu
        readonly Bitmap saveGame = new Bitmap(@"Icons\MenuSaveGame.png");
        readonly Bitmap backToGame = new Bitmap(@"Icons\UIBackToGame.png");

        public Bitmap UserInterface_SaveGame
        { get { return saveGame; } }
        public Bitmap UserInterface_BackToGame
        { get { return backToGame; } }

        //Dialogwindow
        readonly Bitmap dialogBoxForward = new Bitmap(@"Icons\DialogForward.png");
        readonly Bitmap dialogBoxBackground = new Bitmap(@"Backgrounds\DialogboxBackground.png");
        public Bitmap UserInterface_DialogboxBackground
        { get { return dialogBoxBackground; } }
        public Bitmap UserInterface_DialogForward
        { get { return dialogBoxForward; } }

        #endregion
        //Bitmaps for Menus and UI ---- Bitmaps for Items and Characters are listed under that specific Item/Character.
        #region Character
        //Maincharacter stats & name
        int honorPoints = 0;
        int characterStr = 3;
        int characterInt = 3;
        int characterAgi = 3;

        int characterAP = 5;

        string characterName;

        public int Character_Honor
        { get { return honorPoints; } set { honorPoints = value; } }
        public int Character_Strength
        { get { return characterStr; } set { characterStr = value; } }
        public int Character_Intelligence
        { get { return characterInt; } set { characterInt = value; } }
        public int Character_Agility
        { get { return characterAgi; } set { characterAgi = value; } }

        public int Character_AbilityPoints
        { get { return characterAP; } set { characterAP = value; } }

        public string Character_Name
        { get { return characterName; } set { characterName = value; } }

        int characterPic = 1;
        public int Character_Picture
        { get { return characterPic; } set { characterPic = value; } }

        private int characterHealth = 10;
        private int characterCrystals = 10;

        public int Character_Health
        { get { return characterHealth; } set { characterHealth = value; } }
        public int Character_Crystals
        { get { return characterCrystals; } set { characterCrystals = value; } }
        #endregion

        #region Items
        //Items (String is Name_Count_Tooltip, and a bitmap for the item)
        List<string> itemList = new List<string>();
        List<Bitmap> itemBitmapList = new List<Bitmap>();
        public List<string> Items_List
        { get { return itemList; } set { itemList = value; } }
        public List<Bitmap> Items_Bitmap_List
        { get { return itemBitmapList; } set { itemBitmapList = value; } }

        //Single Flower
        readonly Bitmap singleFlower = new Bitmap(@"Icons\SingleFlower.png");
        public Bitmap Items_SingleFlowerBM
        { get { return singleFlower; } }

        private string itemSingleFlower = "Single Flower_0_Eine einzelne, hübsche Blume";
        public string Items_SingleFlower
        { get { return itemSingleFlower; } set { itemSingleFlower = value; } }

        //FlowerCircle
        readonly Bitmap itemFlowerCircle = new Bitmap(@"Icons\FlowerCircle.png");
        public Bitmap Items_FlowerCircleBM
        { get { return itemFlowerCircle; } }

        private string flowerCircle = "Flower Circle_0_Ein wunderschöner Blumenkranz, einer Göttin würdig.";
        public string Items_FlowerCircle
        { get { return flowerCircle; } set { flowerCircle = value; } }

        //Sword
        readonly Bitmap itemSword = new Bitmap(@"Icons\sword.png");
        string sword = "Sword_0_Ein etwas stumpfes, aber noch brauchbares Schwert";

        public Bitmap Items_SwordBM
        { get { return itemSword; } }
        public string Items_Sword
        { get { return sword; } set { sword = value; } }

        //Finished Test
        readonly Bitmap itemTest = new Bitmap(@"Icons\finishedTest.png");
        string finishedTest = "Finished Test_0_Ein Test, bei dem alle Antworten korrekt ausgefüllt wurden";

        public Bitmap Items_FinishedTestBM
        { get { return itemTest; } }
        public string Items_FinishedTest
        { get { return finishedTest; } set { finishedTest = value; } }

        //Rope
        readonly Bitmap rope = new Bitmap(@"Icons\rope.png");
        string itemRope = "Rope_0_Ein festes Seil, das man sehr gut greifen kann";

        public Bitmap Items_RopeBM
        { get { return rope; } }
        public string Items_Rope
        { get { return itemRope; } set { itemRope = value; } }

        //Super Axe
        readonly Bitmap superAxe = new Bitmap(@"Icons\superAxe.png");
        string itemSuperAxe = "Superaxe_0_Eine mächtige Axt, die aus Holz... Kleinholz macht";

        public Bitmap Items_SuperAxeBM
        { get { return superAxe; } }
        public string Items_SuperAxe
        { get { return itemSuperAxe; } set { itemSuperAxe = value; } }

        //Chicken leg
        readonly Bitmap chickenLeg = new Bitmap(@"Icons\chickenLeg.png");
        string itemChickenLeg = "Chicken Leg_0_Ein leckerer Hühnchenschenkel";

        public Bitmap Items_ChickenLegBM
        { get { return chickenLeg; } }
        public string Items_ChickenLeg
        { get { return itemChickenLeg; } set { itemChickenLeg = value; } }

        //Mirror
        readonly Bitmap mirror = new Bitmap(@"Icons\mirror.png");
        string itemMirror = "Mirror_0_Ein einfacher Handspiegel";

        public Bitmap Items_MirrorBM
        { get { return mirror; } }
        public string Items_Mirror
        { get { return itemMirror; } set { itemMirror = value; } }

        //Giant Nut
        readonly Bitmap giantNut = new Bitmap(@"Icons\nut.png");
        string itemGiantNut = "Giant Nut_0_Nüffe? Welfe Nüffe?";

        public Bitmap Items_GiantNutBm
        { get { return giantNut; } }
        public string Items_GiantNut
        { get { return itemGiantNut; } set { itemGiantNut = value; } }


        //HealthPotion
        string healthPotions = "Health Potion_0_Heiltrank, heilt um 5 Lebenspunkte";
        readonly Bitmap healthPotionBM = new Bitmap(@"Icons\HealthPotion.png");
        public string Items_HealthPotion
        { get { return healthPotions; } set { healthPotions = value; } }

        public Bitmap Items_HealthPotionBM
        { get { return healthPotionBM; } }
        #endregion
        
        //Characters
        //Marie
        readonly Bitmap mariaBM = new Bitmap(@"Characters\TextRPGMaria.png");
        int mariaProgression = 0;

        public Bitmap Characters_Maria_Bitmap
        { get { return mariaBM; } }
        public int Characters_Maria_Progression
        { get { return mariaProgression; } set { mariaProgression = value; } }

        //Goblin
        readonly Bitmap goblinBM = new Bitmap(@"Characters\goblin.png");
        public Bitmap Characters_GoblinBM
        { get { return goblinBM; } }
        int goblinProgression = 0;
        public int Characters_Goblin_Progression
        { get { return goblinProgression; } set { goblinProgression = value; } }

        //Jack
        readonly Bitmap jackBM = new Bitmap(@"Characters\Jack.png");
        readonly Bitmap stuckKitten = new Bitmap(@"Characters\stuckKitten.png");
        int jackProgression = 0;
        bool savedKitten = false;
        public Bitmap Characters_JackBM
        { get { return jackBM; } }
        public Bitmap Characters_StuckKittenBM
        { get { return stuckKitten; } }
        public int Characters_JackProgression
        { get { return jackProgression; } set { jackProgression = value; } }
        public bool Characters_JacksKittenSaved
        { get { return savedKitten; } set { savedKitten = value; } }

        //Flying Kitten
        readonly Bitmap kittenBM = new Bitmap(@"Characters\Kitten.png");
        bool kittenClicked = false;
        public Bitmap Characters_KittenBM
        { get { return kittenBM; } }
        public bool Characters_KittenClicked
        { get { return kittenClicked; } set { kittenClicked = value; } }

        //Jorn
        readonly Bitmap wolfBM = new Bitmap(@"Characters\ArenaWolf.png");
        readonly Bitmap jornbm = new Bitmap(@"Characters\Jorn.png");
        readonly Bitmap jornArenaWallpaper = new Bitmap(@"Backgrounds\ArenaBackground.png");
        readonly Bitmap evilmageBM = new Bitmap(@"Characters\evilMageArena.png");
        readonly Bitmap squirrelBM = new Bitmap(@"Characters\ArenaSquirrel.png");
        int jornProgression = 0;
        public Bitmap Characters_JornBM
        { get { return jornbm; } }
        public int Characters_Jorn_Progression
        { get { return jornProgression; } set { jornProgression = value; } }
        public Bitmap Characters_ArenaWolf
        { get { return wolfBM; } }
        public Bitmap Backgrounds_Arena
        { get { return jornArenaWallpaper; } }
        public Bitmap Characters_ArenaMage
        { get { return evilmageBM; } }
        public Bitmap Characters_ArenaSquirrel
        { get { return squirrelBM; } }

        //Lea
        readonly Bitmap leaBM = new Bitmap(@"Characters\Lea.png");
        readonly Bitmap leaWoodBM = new Bitmap(@"Icons\LeaWoodPile.png");
        bool leaWoodcutAllowed = false;
        bool leaWoodcutOnceDone = false;
        int leaChopAmount = 0;

        public bool Characters_Lea_WoodAllowed
        { get { return leaWoodcutAllowed; } set { leaWoodcutAllowed = value; } }
        public bool Characters_Lea_CutOnce
        { get { return leaWoodcutOnceDone; } set { leaWoodcutOnceDone = value; } }
        public Bitmap Characters_LeaBM
        { get { return leaBM; } }
        public Bitmap Characters_Lea_Wood
        { get { return leaWoodBM; } }
        public int Characters_Lea_ChopCount
        { get { return leaChopAmount; } set { leaChopAmount = value; } }

        //Vendor
        readonly Bitmap vendorBM = new Bitmap(@"Characters.Vendor.png");
        bool ropeBought = false;
        bool testBought = false;

        public Bitmap Characters_VendorBM
        { get { return vendorBM; } }
        public bool Characters_Vendor_RopeBought
        { get { return ropeBought; } set { ropeBought = value; } }
        public bool Characters_Vendor_TestBought
        { get { return testBought; } set { testBought = value; } }

        //Valeria
        readonly Bitmap valeriabm = new Bitmap(@"Characters\Valeria.png");
        bool valeriaHelped = false;

        public Bitmap Characters_Valeria
        { get { return valeriabm; } }
        public bool Characters_ValeriaHelped
        { get { return valeriaHelped; } set { valeriaHelped = value; } }

        //Variables for Specific scenes
        
        //First Scene
        bool collectFlower = false;
        readonly Bitmap toForest = new Bitmap(@"Icons\ToForest.png");
        public Bitmap UserInterface_TowardsForest
        { get { return toForest; } }
        public bool FirstScene_CollectFlower
        { get { return collectFlower; } set { collectFlower = value; } }
        int collectFlowerCount = 0;
        public int FirstScene_CollectFlowerCount
        { get { return collectFlowerCount; } set { collectFlowerCount = value; } }

        //Forest
        readonly Bitmap forestBackground = new Bitmap(@"Backgrounds\ForestBackground.png");
        public Bitmap Background_Forest
        { get { return forestBackground; } }

        //City, CHARACTER SIZE CITY = 50;70
        readonly Bitmap cityBackground = new Bitmap(@"Backgrounds\villageBackground.png");
        public Bitmap Background_City
        { get { return cityBackground; } }

        //Bool for Tutorial
        bool tutorialbool = true;
        public bool Tutorial_Bool
        { get { return tutorialbool; } set { tutorialbool = value; } }
        int tutorialCounter = 0;
        public int Tutorial_TimeCounter
        { get { return tutorialCounter; } set { tutorialCounter = value; } }
    }
}