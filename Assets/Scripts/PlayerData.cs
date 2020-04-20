[System.Serializable]
public class PlayerData
{
    public int coins, gamesLost, gamesWon, gamesPlayed, skinsUnlocked, mostCoins, coinsSpent, hiddenAchiv;
    public string currentSpriteX, currentSpriteO;
    public bool achivOne, achivTwo, achivThree, achivFour, achivFive, achivSix, achivSeven, achivEigth;
    public bool itemOne, itemTwo, itemThree, itemFour, itemFive, itemSix;
    public PlayerData()
    {
        coins = CoinAndGamesData.PlayerCoins;
        mostCoins = CoinAndGamesData.MostCoins;
        coinsSpent = CoinAndGamesData.CoinsSpent;
        hiddenAchiv = CoinAndGamesData.HiddenAchievement;

        currentSpriteX = CoinAndGamesData.CurrentSpriteEquippedX;
        currentSpriteO = CoinAndGamesData.CurrentSpriteEquippedO;

        gamesLost = CoinAndGamesData.GamesLost;
        gamesWon = CoinAndGamesData.GamesWon;
        gamesPlayed = CoinAndGamesData.GamesPlayed;

        skinsUnlocked = CoinAndGamesData.CurrentSkinsUnlocked;

        achivOne = CoinAndGamesData.FirstAchievement;
        achivTwo = CoinAndGamesData.SecondAchievement;
        achivThree = CoinAndGamesData.ThirdAchievement;
        achivFour = CoinAndGamesData.FourthAchievement;
        achivFive = CoinAndGamesData.FifthAchievement;
        achivSix = CoinAndGamesData.SixthAchievement;
        achivSeven = CoinAndGamesData.SeventhAchievement;
        achivEigth = CoinAndGamesData.EighthAchievement;

        itemOne = CoinAndGamesData.FirstItem;
        itemTwo = CoinAndGamesData.SecondItem;
        itemThree = CoinAndGamesData.ThirdItem;
        itemFour = CoinAndGamesData.FourthItem;
        itemFive = CoinAndGamesData.FifthItem;
        itemSix = CoinAndGamesData.SixthItem;
    }
}
