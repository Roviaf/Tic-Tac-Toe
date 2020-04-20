using System.Collections;
using UnityEngine;

public class Achievements : MonoBehaviour
{
    public GameObject[] achievementsImages;
    private static Achievements playerInstance;
    GameObject currentSaveFile;
    
    
    int[] arrayAchievement = {10, 60, 15, 40, 5, 20, 10, 7};

    private void Start()
    {
        currentSaveFile = GameObject.Find("CurrentSaveFile");
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null){playerInstance = this;} 
        else{Object.Destroy(gameObject);}
    }

    public void AchievementCheck()
    {
        for (int i = 0; i < arrayAchievement.Length; i++)
        {LoopAchievement(arrayAchievement[i], i);}
    }

    private void LoopAchievement(int number, int i)
    {
        int[] dataValues = {CoinAndGamesData.MostCoins, CoinAndGamesData.MostCoins, CoinAndGamesData.CoinsSpent, CoinAndGamesData.CoinsSpent, CoinAndGamesData.GamesPlayed, CoinAndGamesData.GamesPlayed, CoinAndGamesData.GamesWon, CoinAndGamesData.HiddenAchievement};
        bool[] dataAchievedCheck = {CoinAndGamesData.FirstAchievement, CoinAndGamesData.SecondAchievement, CoinAndGamesData.ThirdAchievement, CoinAndGamesData.FourthAchievement, CoinAndGamesData.FifthAchievement, CoinAndGamesData.SixthAchievement, CoinAndGamesData.SeventhAchievement, CoinAndGamesData.EighthAchievement};
        if (dataValues[i] >= number && dataAchievedCheck[i] == false)
        {
            StartCoroutine(ActivatingImageAchievement(i));
            dataAchievedCheck[i] = true;
            CoinAndGamesData.HiddenAchievement++;
            GivingDataValues(i);
            if (currentSaveFile.GetComponent<CurrentSaveFile>().savefile == 1) SaveSystem.SaveSlot1();
            if (currentSaveFile.GetComponent<CurrentSaveFile>().savefile == 2) SaveSystem.SaveSlot2();
            if (currentSaveFile.GetComponent<CurrentSaveFile>().savefile == 3) SaveSystem.SaveSlot3();
        }
    }

    private static void GivingDataValues(int i)
    {
        if (i == 0) {CoinAndGamesData.FirstAchievement = true;}
        if (i == 1) CoinAndGamesData.SecondAchievement = true;
        if (i == 2) CoinAndGamesData.ThirdAchievement = true;
        if (i == 3) CoinAndGamesData.FourthAchievement = true;
        if (i == 4) CoinAndGamesData.FifthAchievement = true;
        if (i == 5) CoinAndGamesData.SixthAchievement = true;
        if (i == 6) CoinAndGamesData.SeventhAchievement = true;
        if (i == 7) CoinAndGamesData.EighthAchievement = true;
    }

    IEnumerator ActivatingImageAchievement(int i)
    {
        achievementsImages[i].SetActive(true);
        yield return new WaitForSeconds(5f);
        achievementsImages[i].SetActive(false);
    }
}