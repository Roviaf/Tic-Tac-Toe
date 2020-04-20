using UnityEngine;
using UnityEngine.UI;

public class CurrentSkin : MonoBehaviour
{
    private static CurrentSkin playerInstance;
    public Sprite spriteX;
    public Sprite spriteO;
    bool equipped = false;
    int count = 0;

    Button[] buttonSkin;
    Text[] textSkin;

    Image[] skinSprite;
    Text[] textButton;
    Button[] buttonEquip;
    GameObject holdingScripts;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    public void FindingGameObject(){holdingScripts = GameObject.Find("HoldingScripts");}

    public void DeEquipIt()
    {
        buttonSkin = holdingScripts.GetComponent<Profile>().buttons;
        textSkin = holdingScripts.GetComponent<Profile>().textButtons;
        if (count == 0 && CoinAndGamesData.CurrentSkinsUnlocked >= 1)
        {
            for (int i = 0; i < holdingScripts.GetComponent<Profile>().buttons.Length; i++)
            {
                if(textSkin[i].text == "Equipped"){ buttonSkin[i].interactable = true; textSkin[i].text = "Equip";}
            } 
        }
        else
        {
            for (int i = 0; i < holdingScripts.GetComponent<Profile>().buttons.Length; i++)
            {
                if (textSkin[i].text == "Equipped")
                {
                    textSkin[i].text = "Equip";
                    buttonSkin[i].interactable = true;
                    equipped = false;
                }
            }
        }

    }

    public void EquipSprite()
    {
        
        skinSprite = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Image>();
        textButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Text>();
        buttonEquip = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponentsInChildren<Button>();
        count = 1;
        textButton[0].text = "Equipped";
        buttonEquip[0].interactable = false;
        spriteX = skinSprite[1].sprite;
        spriteO = skinSprite[2].sprite;
        CoinAndGamesData.CurrentSpriteEquippedX = spriteX.ToString();
        CoinAndGamesData.CurrentSpriteEquippedO = spriteO.ToString();
        if(MainMenu.loadNumber == 1) SaveSystem.SaveSlot1();
        if (MainMenu.loadNumber == 2) SaveSystem.SaveSlot2();
        if (MainMenu.loadNumber == 3) SaveSystem.SaveSlot3();
    }
    

}