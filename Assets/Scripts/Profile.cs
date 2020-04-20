using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public GameObject[] textObjects;
    public GameObject imageHolder;
    public Button[] buttons;
    public Text[] textButtons;
    public GameObject[] opacity;
    GameObject currentSkin;
    GameObject currentSaveFile;
    public GameObject[] achievementsImage;

    public void LoadProfile()
    {
        textObjects[0].GetComponent<Text>().text = CoinAndGamesData.GamesPlayed.ToString();
        textObjects[1].GetComponent<Text>().text = CoinAndGamesData.GamesWon.ToString();
        textObjects[2].GetComponent<Text>().text = CoinAndGamesData.GamesLost.ToString();
        textObjects[3].GetComponent<Text>().text = CoinAndGamesData.MostCoins.ToString();
        textObjects[4].GetComponent<Text>().text = CoinAndGamesData.PlayerCoins.ToString();
        textObjects[5].GetComponent<Text>().text = CoinAndGamesData.CurrentSkinsUnlocked.ToString();

        CheckingItemUnlocked(false, true);
        CheckingItemUnlocked(true, false);
        
        currentSkin = GameObject.Find("CurrentSkin");
        currentSkin.GetComponent<CurrentSkin>().FindingGameObject();

        for (int i = 0; i < 7; i++)
        {
            var name = buttons[i].ToString();
            name = name.Replace(" (UnityEngine.UI.Button)", "");
            if (CoinAndGamesData.CurrentSpriteEquippedX == name) { buttons[i].interactable = false; textButtons[i].text = "Equipped"; }
        }
    }

    private void CheckingItemUnlocked(bool unlockedValue, bool opacityValue)
    {
        if (CoinAndGamesData.FirstItem == unlockedValue) { buttons[1].interactable = unlockedValue; opacity[0].SetActive(opacityValue); }
        if (CoinAndGamesData.SecondItem == unlockedValue) { buttons[2].interactable = unlockedValue; opacity[1].SetActive(opacityValue); }
        if (CoinAndGamesData.ThirdItem == unlockedValue) { buttons[3].interactable = unlockedValue; opacity[2].SetActive(opacityValue); }
        if (CoinAndGamesData.FourthItem == unlockedValue) { buttons[4].interactable = unlockedValue; opacity[3].SetActive(opacityValue); }
        if (CoinAndGamesData.FifthItem == unlockedValue) { buttons[5].interactable = unlockedValue; opacity[4].SetActive(opacityValue); }
        if (CoinAndGamesData.SixthItem == unlockedValue) { buttons[6].interactable = unlockedValue; opacity[5].SetActive(opacityValue); }
    }

    public void Slider_Changed(float newValue)
    {
        Vector3 pos = imageHolder.transform.position;
        pos.x = newValue;
        pos.x = -pos.x;
        imageHolder.transform.position = pos;
    }

    public void AchievementHolder()
    {

    }
}