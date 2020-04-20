using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject[] opacityText;
    public GameObject[] textForCoins;
    public GameObject coins;
    public GameObject notEnoughCoins;
    GameObject achievements;
    public bool isBought = false;

    public void LoadingCoinsAndLayout()
    {
        coins.GetComponent<Text>().text = CoinAndGamesData.PlayerCoins.ToString()+ " :";
        if (CoinAndGamesData.FirstItem == true){opacityText[0].SetActive(true); textForCoins[0].SetActive(false); isBought = false;}
        if (CoinAndGamesData.SecondItem == true){opacityText[1].SetActive(true); textForCoins[1].SetActive(false); isBought = false;}
        if (CoinAndGamesData.ThirdItem == true){opacityText[2].SetActive(true); textForCoins[2].SetActive(false); isBought = false;}
        if (CoinAndGamesData.FourthItem == true){opacityText[3].SetActive(true); textForCoins[3].SetActive(false); isBought = false;}
        if (CoinAndGamesData.FifthItem == true){opacityText[4].SetActive(true); textForCoins[4].SetActive(false); isBought = false;}
        if (CoinAndGamesData.SixthItem == true){opacityText[5].SetActive(true); textForCoins[5].SetActive(false); isBought = false;}
    }
    IEnumerator NoCoins(){notEnoughCoins.SetActive(true); yield return new WaitForSeconds(1.7f);notEnoughCoins.SetActive(false);}
    public void UpdatingCoins(int valueCoin)
    {
        if(CoinAndGamesData.PlayerCoins - valueCoin >= 0)
        {
            CoinAndGamesData.PlayerCoins -= valueCoin;
            isBought = true;
            CoinAndGamesData.CurrentSkinsUnlocked++;
            CoinAndGamesData.CoinsSpent+= valueCoin;
            achievements = GameObject.Find("Achievements");
            achievements.GetComponent<Achievements>().AchievementCheck();
        }
    }

    public void Buying3GoldOne()
    {
        UpdatingCoins(3);
        if(isBought==true)
        {
            if(MainMenu.loadNumber == 1)
            {LoadingCoinsAndLayout();opacityText[0].SetActive(true); textForCoins[0].SetActive(false); isBought = false;CoinAndGamesData.FirstItem = true;SaveSystem.SaveSlot1();}
            if(MainMenu.loadNumber == 2)
            {LoadingCoinsAndLayout();opacityText[0].SetActive(true); textForCoins[0].SetActive(false); isBought = false;CoinAndGamesData.FirstItem = true;SaveSystem.SaveSlot2();}
            if(MainMenu.loadNumber == 3)
            {LoadingCoinsAndLayout();opacityText[0].SetActive(true); textForCoins[0].SetActive(false); isBought = false;CoinAndGamesData.FirstItem = true;SaveSystem.SaveSlot3();}
        }
        else
        {StartCoroutine(NoCoins());}
    }
    
    public void Buying5GoldOne()
    {
        UpdatingCoins(5);
        if(isBought == true)
        {
            if(MainMenu.loadNumber == 1)
            {LoadingCoinsAndLayout();opacityText[1].SetActive(true); textForCoins[1].SetActive(false); isBought = false;CoinAndGamesData.SecondItem = true;SaveSystem.SaveSlot1();}
            if(MainMenu.loadNumber == 2)
            {LoadingCoinsAndLayout();opacityText[1].SetActive(true); textForCoins[1].SetActive(false); isBought = false;CoinAndGamesData.SecondItem = true;SaveSystem.SaveSlot2();}
            if(MainMenu.loadNumber == 3)
            {LoadingCoinsAndLayout();opacityText[1].SetActive(true); textForCoins[1].SetActive(false); isBought = false;CoinAndGamesData.SecondItem = true;SaveSystem.SaveSlot3();}
        }
        else
        {StartCoroutine(NoCoins());}
    }

    public void Buying7GoldOne()
    {
        UpdatingCoins(7);
        if(isBought == true)
        {
            if(MainMenu.loadNumber == 1)
            {LoadingCoinsAndLayout();opacityText[2].SetActive(true); textForCoins[2].SetActive(false); isBought = false;CoinAndGamesData.ThirdItem = true;SaveSystem.SaveSlot1();}
            if(MainMenu.loadNumber == 2)
            {LoadingCoinsAndLayout();opacityText[2].SetActive(true); textForCoins[2].SetActive(false); isBought = false;CoinAndGamesData.ThirdItem = true;SaveSystem.SaveSlot2();}
            if(MainMenu.loadNumber == 3)
            {LoadingCoinsAndLayout();opacityText[2].SetActive(true); textForCoins[2].SetActive(false); isBought = false;CoinAndGamesData.ThirdItem = true;SaveSystem.SaveSlot3();}
        }
        else
        {StartCoroutine(NoCoins());}
    }

    public void Buying10GoldOne()
    {
        UpdatingCoins(10);
        if(isBought == true)
        {
            if(MainMenu.loadNumber == 1)
            {LoadingCoinsAndLayout();opacityText[3].SetActive(true); textForCoins[3].SetActive(false); isBought = false;CoinAndGamesData.FourthItem = true;SaveSystem.SaveSlot1();}
            if(MainMenu.loadNumber == 2)
            {LoadingCoinsAndLayout();opacityText[3].SetActive(true); textForCoins[3].SetActive(false); isBought = false;CoinAndGamesData.FourthItem = true;SaveSystem.SaveSlot2();}
            if(MainMenu.loadNumber == 3)
            {LoadingCoinsAndLayout();opacityText[3].SetActive(true); textForCoins[3].SetActive(false); isBought = false;CoinAndGamesData.FourthItem = true;SaveSystem.SaveSlot3();}
        }
        else
        {StartCoroutine(NoCoins());}
    }

    public void Buying15GoldOne()
    {
        UpdatingCoins(15);
        if(isBought == true)
        {
            if(MainMenu.loadNumber == 1)
            {LoadingCoinsAndLayout();opacityText[4].SetActive(true); textForCoins[4].SetActive(false); isBought = false;CoinAndGamesData.FifthItem = true;SaveSystem.SaveSlot1();}
            if(MainMenu.loadNumber == 2)
            {LoadingCoinsAndLayout();opacityText[4].SetActive(true); textForCoins[4].SetActive(false); isBought = false;CoinAndGamesData.FifthItem = true;SaveSystem.SaveSlot2();}
            if(MainMenu.loadNumber == 3)
            {LoadingCoinsAndLayout();opacityText[4].SetActive(true); textForCoins[4].SetActive(false); isBought = false;CoinAndGamesData.FifthItem = true;SaveSystem.SaveSlot3();}
        }
        else
        {StartCoroutine(NoCoins());}
    }

    public void Buying20GoldOne()
    {
        UpdatingCoins(20);
        if(isBought == true)
        {
            if(MainMenu.loadNumber == 1)
            {LoadingCoinsAndLayout();opacityText[5].SetActive(true); textForCoins[5].SetActive(false); isBought = false;CoinAndGamesData.SixthItem = true;SaveSystem.SaveSlot1();}
            if(MainMenu.loadNumber == 2)
            {LoadingCoinsAndLayout();opacityText[5].SetActive(true); textForCoins[5].SetActive(false); isBought = false;CoinAndGamesData.SixthItem = true;SaveSystem.SaveSlot2();}
            if(MainMenu.loadNumber == 3)
            {LoadingCoinsAndLayout();opacityText[5].SetActive(true); textForCoins[5].SetActive(false); isBought = false;CoinAndGamesData.SixthItem = true;SaveSystem.SaveSlot3();}
        }
        else
        {StartCoroutine(NoCoins());}
    }
}