using UnityEngine;
using UnityEngine.UI;

public class AchievementMenuManagement : MonoBehaviour
{
    public GameObject[] opacity;
    public GameObject hiddenAchievement;
    
    public void SettingOpacityOnAchievements()
    {
        if (CoinAndGamesData.FirstAchievement == true)opacity[0].GetComponent<Image>().color = Color.black;
        if (CoinAndGamesData.SecondAchievement == true)opacity[1].GetComponent<Image>().color = Color.black;
        if (CoinAndGamesData.ThirdAchievement == true)opacity[2].GetComponent<Image>().color = Color.black;
        if (CoinAndGamesData.FourthAchievement == true)opacity[3].GetComponent<Image>().color = Color.black;
        if (CoinAndGamesData.FifthAchievement == true)opacity[4].GetComponent<Image>().color = Color.black;
        if (CoinAndGamesData.SixthAchievement == true)opacity[5].GetComponent<Image>().color = Color.black;
        if (CoinAndGamesData.SeventhAchievement == true)opacity[6].GetComponent<Image>().color = Color.black;
        if (CoinAndGamesData.EighthAchievement == true){opacity[7].GetComponent<Image>().color = Color.black;hiddenAchievement.GetComponent<Text>().text = "Finish all achievements without dying";}
    }
}