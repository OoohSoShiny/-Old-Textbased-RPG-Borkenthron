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
    class MainVariables
    {
        #region Bitmaps
        //Main Menu pictures
        readonly Bitmap mainMenuBackground = new Bitmap(@"Backgrounds\MenuBackground300200.jpg");
        readonly Bitmap mainMenuNewGame = new Bitmap(@"Icons\mainMenuNewGame.png");
        readonly Bitmap mainMenuLoadGame = new Bitmap(@"Icons\mainMenuLoadGame.png");
        readonly Bitmap mainMenuExitGame = new Bitmap(@"Icons\mainMenuExitGame.png");

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
        #endregion

        //Character stats

        int characterStr = 3;
        int characterInt = 3;
        int characterAgi = 3;

        string characterName = "";

        public int Character_Strength
        { get { return characterStr; } set { characterStr = value; } }
        public int Character_Intelligence
        { get { return characterInt; } set { characterInt = value; } }
        public int Character_Agility
        { get { return characterAgi; } set { characterAgi = value; } }
    }
}