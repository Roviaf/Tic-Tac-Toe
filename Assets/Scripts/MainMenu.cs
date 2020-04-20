using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{    
#region VARS

    // VARS WITH CANVAS
    public GameObject[] textSlot;
    public GameObject[] loadSlot;
    public GameObject[] loadSlotText;
    public GameObject[] loadSlotShop;
    public GameObject[] loadSlotAchievement;
    public GameObject[] loadSlotAchievementText;
    public GameObject[] loadSlotProfile;
    public GameObject[] loadSlotTextShop;
    public GameObject[] loadSlotTextProfile;
    public GameObject[] overWrite;
    public GameObject[] certainCanvas;

    // VAR FOR DIFFICULTY AND SAVEFILE
    GameObject aiDifficulty;
    GameObject currentSaveFile;
    public static int loadNumber = 0;

    // VAR FOR SPRITE
    GameObject currentSkin;

    // VAR FOR OVERWRITE
    bool overWriteCondition = false;

#endregion

    private void Start() 
    {
        aiDifficulty = GameObject.Find("AIDifficulty");
        currentSkin = GameObject.Find("CurrentSkin");
        currentSaveFile = GameObject.Find("CurrentSaveFile");
        CheckingSlots();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quitting() { Application.Quit(); }

    // AI DIFFICULTY
    public void EasyDifficulty(){aiDifficulty.GetComponent<AiDifficulty>().EasyDifficulty();}
    public void MediumDifficulty(){aiDifficulty.GetComponent<AiDifficulty>().MediumDifficulty();}
    public void HardDifficulty(){aiDifficulty.GetComponent<AiDifficulty>().HardDifficulty();}
    public void CouchPlayer(){aiDifficulty.GetComponent<AiDifficulty>().CouchPlayer();}

    // SAVING SYSTEM

    public void SaveSlot1()
    {
        if(MainMenuSaving.LoadSlot1() == false)
        { ResetData();DefaultSprites(); SaveSystem.SaveSlot1();SettingCanvasActive();currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(1);}
        else {overWrite[0].SetActive(true);}

        if (overWriteCondition == true)
        { ResetData();DefaultSprites(); SaveSystem.SaveSlot1(); SettingCanvasActive();overWriteCondition = false;currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(1);}
    }
    public void SaveSlot2()
    {
        if (MainMenuSaving.LoadSlot2() == false) 
        { ResetData();DefaultSprites(); SaveSystem.SaveSlot2(); SettingCanvasActive();currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(2);}
        else { overWrite[1].SetActive(true);}

        if (overWriteCondition == true)
        {ResetData();DefaultSprites(); SaveSystem.SaveSlot2(); SettingCanvasActive();overWriteCondition = false;currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(2);}
    }
    public void SaveSlot3()
    {
        if (MainMenuSaving.LoadSlot3() == false) 
        { ResetData();DefaultSprites(); SaveSystem.SaveSlot3(); SettingCanvasActive();currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(3);}
        else { overWrite[2].SetActive(true);}

        if (overWriteCondition == true)
        {ResetData();DefaultSprites(); SaveSystem.SaveSlot3(); SettingCanvasActive();overWriteCondition = false;currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(3);}
    }

    // METHODS WITHIN SAVING AND LOADING

    private void DefaultSprites()
    {
        CoinAndGamesData.CurrentSpriteEquippedX = "DefaultX"; CoinAndGamesData.CurrentSpriteEquippedO = "DefaultO";
        currentSkin.GetComponent<CurrentSkin>().spriteX = Resources.Load<Sprite>(CoinAndGamesData.CurrentSpriteEquippedX);
        currentSkin.GetComponent<CurrentSkin>().spriteO = Resources.Load<Sprite>(CoinAndGamesData.CurrentSpriteEquippedO);
    }

    public void DeEquipIt()
    {
        currentSkin.GetComponent<CurrentSkin>().DeEquipIt();
    }

    public void EquipSprite()
    {
        currentSkin.GetComponent<CurrentSkin>().EquipSprite();
    }

    public void ResetData()
    {
        CoinAndGamesData.CoinsSpent = 0;
        CoinAndGamesData.CurrentSkinsUnlocked = 0;
        CoinAndGamesData.CurrentSpriteEquippedO = null;
        CoinAndGamesData.CurrentSpriteEquippedX = null;
        CoinAndGamesData.EighthAchievement = false;
        CoinAndGamesData.FifthAchievement = false;
        CoinAndGamesData.FifthItem = false;
        CoinAndGamesData.FirstAchievement = false;
        CoinAndGamesData.FirstItem = false;
        CoinAndGamesData.FourthAchievement = false;
        CoinAndGamesData.FourthItem = false;
        CoinAndGamesData.GamesLost = 0;
        CoinAndGamesData.GamesPlayed = 0;
        CoinAndGamesData.GamesWon = 0;
        CoinAndGamesData.HiddenAchievement = 0;
        CoinAndGamesData.MostCoins = 0;
        CoinAndGamesData.PlayerCoins = 0;
        CoinAndGamesData.SecondAchievement = false;
        CoinAndGamesData.SecondItem = false;
        CoinAndGamesData.SeventhAchievement = false;
        CoinAndGamesData.SixthAchievement = false;
        CoinAndGamesData.SixthItem = false;
        CoinAndGamesData.ThirdAchievement = false;
        CoinAndGamesData.ThirdItem = false;
    }

    public void OverWriteCondition(){overWriteCondition = true;}

    private void SettingCanvasActive(){certainCanvas[0].SetActive(false); certainCanvas[1].SetActive(true);}

    private void SettingSpritesOnLoad()
    {
        try
        {
            CoinAndGamesData.CurrentSpriteEquippedX = CoinAndGamesData.CurrentSpriteEquippedX.Replace(" (UnityEngine.Sprite)", "");
            CoinAndGamesData.CurrentSpriteEquippedO = CoinAndGamesData.CurrentSpriteEquippedO.Replace(" (UnityEngine.Sprite)", "");
        }catch{}

        currentSkin.GetComponent<CurrentSkin>().spriteX = Resources.Load<Sprite>(CoinAndGamesData.CurrentSpriteEquippedX);
        currentSkin.GetComponent<CurrentSkin>().spriteO = Resources.Load<Sprite>(CoinAndGamesData.CurrentSpriteEquippedO);
    }

    // LOADING SYSTEM

    public void LoadSlot1()
    {
        PlayerData data1 = SaveSystem.LoadSlot1();

        CoinAndGamesData.GamesPlayed = data1.gamesPlayed;
        CoinAndGamesData.GamesWon = data1.gamesWon;
        CoinAndGamesData.GamesLost = data1.gamesLost;

        CoinAndGamesData.CurrentSpriteEquippedO = data1.currentSpriteO;
        CoinAndGamesData.CurrentSpriteEquippedX = data1.currentSpriteX;

        CoinAndGamesData.PlayerCoins = data1.coins;
        CoinAndGamesData.MostCoins = data1.mostCoins;

        CoinAndGamesData.CurrentSkinsUnlocked = data1.skinsUnlocked;

        CoinAndGamesData.FirstItem = data1.itemOne;
        CoinAndGamesData.SecondItem = data1.itemTwo;
        CoinAndGamesData.ThirdItem = data1.itemThree;
        CoinAndGamesData.FourthItem = data1.itemFour;
        CoinAndGamesData.FifthItem = data1.itemFive;
        CoinAndGamesData.SixthItem = data1.itemSix;

        CoinAndGamesData.FirstAchievement = data1.achivOne;
        CoinAndGamesData.SecondAchievement = data1.achivTwo;
        CoinAndGamesData.ThirdAchievement = data1.achivThree;
        CoinAndGamesData.FourthAchievement = data1.achivFour;
        CoinAndGamesData.FifthAchievement = data1.achivFive;
        CoinAndGamesData.SixthAchievement = data1.achivSix;
        CoinAndGamesData.SeventhAchievement = data1.achivSeven;
        CoinAndGamesData.HiddenAchievement = data1.hiddenAchiv;

        SettingSpritesOnLoad();
        loadNumber = 1;
        currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(loadNumber);
    }

    public void LoadSlot2()
    {
        PlayerData data2 = SaveSystem.LoadSlot2(); 
        CoinAndGamesData.GamesPlayed = data2.gamesPlayed;
        CoinAndGamesData.GamesWon = data2.gamesWon;
        CoinAndGamesData.GamesLost = data2.gamesLost;

        CoinAndGamesData.CurrentSpriteEquippedO = data2.currentSpriteO;
        CoinAndGamesData.CurrentSpriteEquippedX = data2.currentSpriteX;

        CoinAndGamesData.PlayerCoins = data2.coins; 
        CoinAndGamesData.MostCoins = data2.mostCoins; 

        CoinAndGamesData.CurrentSkinsUnlocked = data2.skinsUnlocked;

        CoinAndGamesData.FirstItem = data2.itemOne; 
        CoinAndGamesData.SecondItem = data2.itemTwo;
        CoinAndGamesData.ThirdItem = data2.itemThree;
        CoinAndGamesData.FourthItem = data2.itemFour;
        CoinAndGamesData.FifthItem = data2.itemFive;
        CoinAndGamesData.SixthItem = data2.itemSix;

        CoinAndGamesData.FirstAchievement = data2.achivOne;
        CoinAndGamesData.SecondAchievement = data2.achivTwo;
        CoinAndGamesData.ThirdAchievement = data2.achivThree;
        CoinAndGamesData.FourthAchievement = data2.achivFour;
        CoinAndGamesData.FifthAchievement = data2.achivFive;
        CoinAndGamesData.SixthAchievement = data2.achivSix;
        CoinAndGamesData.SeventhAchievement = data2.achivSeven;
        CoinAndGamesData.HiddenAchievement = data2.hiddenAchiv;

        SettingSpritesOnLoad();
        loadNumber = 2;
        currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(loadNumber);
    }

    public void LoadSlot3()
    {
        PlayerData data3 = SaveSystem.LoadSlot3(); 
        
        CoinAndGamesData.GamesPlayed = data3.gamesPlayed;
        CoinAndGamesData.GamesWon = data3.gamesWon;
        CoinAndGamesData.GamesLost = data3.gamesLost;

        CoinAndGamesData.CurrentSpriteEquippedO = data3.currentSpriteO;
        CoinAndGamesData.CurrentSpriteEquippedX = data3.currentSpriteX;

        CoinAndGamesData.PlayerCoins = data3.coins; 
        CoinAndGamesData.MostCoins = data3.mostCoins; 

        CoinAndGamesData.CurrentSkinsUnlocked = data3.skinsUnlocked;

        CoinAndGamesData.FirstItem = data3.itemOne; 
        CoinAndGamesData.SecondItem = data3.itemTwo;
        CoinAndGamesData.ThirdItem = data3.itemThree;
        CoinAndGamesData.FourthItem = data3.itemFour;
        CoinAndGamesData.FifthItem = data3.itemFive;
        CoinAndGamesData.SixthItem = data3.itemSix;

        CoinAndGamesData.FirstAchievement = data3.achivOne;
        CoinAndGamesData.SecondAchievement = data3.achivTwo;
        CoinAndGamesData.ThirdAchievement = data3.achivThree;
        CoinAndGamesData.FourthAchievement = data3.achivFour;
        CoinAndGamesData.FifthAchievement = data3.achivFive;
        CoinAndGamesData.SixthAchievement = data3.achivSix;
        CoinAndGamesData.SeventhAchievement = data3.achivSeven;
        CoinAndGamesData.HiddenAchievement = data3.hiddenAchiv;

        SettingSpritesOnLoad();
        loadNumber = 3;
        currentSaveFile.GetComponent<CurrentSaveFile>().GettingSaveFileNumber(loadNumber);
    }

    // OVERWRITE CHECK
    public void CheckingSlots()
    {
        if(MainMenuSaving.LoadSlot1() == true)
        {
            textSlot[0].GetComponent<Text>().text = "Game Save Number 1";
        }
        else 
        {
            textSlot[0].GetComponent<Text>().text = "Free save slot";
            loadSlotText[0].GetComponent<Text>().text = "No save file found";
            loadSlotTextShop[0].GetComponent<Text>().text = "No save file found";
            loadSlotTextProfile[0].GetComponent<Text>().text = "No save file found";
            loadSlotAchievementText[0].GetComponent<Text>().text = "No save file found";
            loadSlot[0].GetComponent<Button>().interactable = false;
            loadSlotShop[0].GetComponent<Button>().interactable = false;
            loadSlotProfile[0].GetComponent<Button>().interactable = false;
            loadSlotAchievement[0].GetComponent<Button>().interactable = false;
        }
        if (MainMenuSaving.LoadSlot2() == true)
        {
            textSlot[1].GetComponent<Text>().text = "Game Save Number 2";
        }
        else
        {
            textSlot[1].GetComponent<Text>().text = "Free save slot";
            loadSlotText[1].GetComponent<Text>().text = "No save file found";
            loadSlotTextShop[1].GetComponent<Text>().text = "No save file found";
            loadSlotTextProfile[1].GetComponent<Text>().text = "No save file found";
            loadSlotAchievementText[1].GetComponent<Text>().text = "No save file found";
            loadSlot[1].GetComponent<Button>().interactable = false;
            loadSlotShop[1].GetComponent<Button>().interactable = false;
            loadSlotProfile[1].GetComponent<Button>().interactable = false;
            loadSlotAchievement[1].GetComponent<Button>().interactable = false;
        }
        if (MainMenuSaving.LoadSlot3() == true)
        {
            textSlot[2].GetComponent<Text>().text = "Game Save Number 3";
        }
        else
        {
            textSlot[2].GetComponent<Text>().text = "Free save slot";
            loadSlotText[2].GetComponent<Text>().text = "No save file found";
            loadSlotTextShop[2].GetComponent<Text>().text = "No save file found";
            loadSlotTextProfile[2].GetComponent<Text>().text = "No save file found";
            loadSlotAchievementText[2].GetComponent<Text>().text = "No save file found";
            loadSlot[2].GetComponent<Button>().interactable = false;
            loadSlotShop[2].GetComponent<Button>().interactable = false;
            loadSlotProfile[2].GetComponent<Button>().interactable = false;
            loadSlotAchievement[2].GetComponent<Button>().interactable = false;
        }
    }
}