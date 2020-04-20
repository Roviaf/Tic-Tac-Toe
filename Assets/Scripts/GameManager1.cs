using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{

    #region all variables
    // GAMEMANAGER VARIABLES
    int whoseTurn;
    int oPlayerScore = 0;
    int xPlayerScore = 0;
    int turncount;
    int numberSaved = 0;
    float countingTime = 0;
    int a,b,c;
    int number = 0;
    bool AITurn = true;
    bool winner = false;
    bool draw = false;
    bool gameOver = false;
    System.Random rnd = new System.Random();

    // MINIMAX VARIABLES
    int move = 0;
    bool dig1, dig2 = false;

    // UNITY EDITOR DECLARED
    public GameObject textWinner;
    public Text textOPlayer;
    public Text textXPlayer;
    public GameObject[] turnIcons;
    public GameObject[] winningLine;
    public GameObject stoppingPlayerFromPlaying;
    public Sprite[] playerIcons;
    public Button[] Spaces;
    float[,] markedSpaces = new float[3,3];


    // MAIN MENU VARS
    GameObject aiDifficulty;
    GameObject currentSkin;
    GameObject achievements;
    GameObject achievementCanvas;
    GameObject currentSaveFile;
    public GameObject pauseMenu;
    bool aiEasy = false;
    bool aiMedium = false;
    bool aiHard = false;
    bool isPaused = false;

    // SAVING VARS
    public GameObject coins;
    #endregion

    private void Start()
    {
        aiDifficulty = GameObject.Find("AIDifficulty");
        currentSkin = GameObject.Find("CurrentSkin");
        achievements = GameObject.Find("Achievements");
        currentSaveFile = GameObject.Find("CurrentSaveFile");
        achievementCanvas = GameObject.Find("CanvasAchievement");

        GameObject xIcon = GameObject.Find("XImageIcon");
        GameObject oIcon = GameObject.Find("OImageIcon");

        xIcon.GetComponent<Image>().sprite = currentSkin.GetComponent<CurrentSkin>().spriteX;
        oIcon.GetComponent<Image>().sprite = currentSkin.GetComponent<CurrentSkin>().spriteO;
        playerIcons[0] = currentSkin.GetComponent<CurrentSkin>().spriteO;
        playerIcons[1] = currentSkin.GetComponent<CurrentSkin>().spriteX;

        coins.GetComponent<Text>().text = ": " + CoinAndGamesData.PlayerCoins.ToString();
        

        FindingAndSettingDifficulty();
        GameSetup();

        stoppingPlayerFromPlaying.SetActive(false);
    }

    private void FindingAndSettingDifficulty()
    {
        if (aiDifficulty.GetComponent<AiDifficulty>().couchPlayer == true) { }
        if (aiDifficulty.GetComponent<AiDifficulty>().easy == true) { aiEasy = true; }
        if (aiDifficulty.GetComponent<AiDifficulty>().medium == true) { aiMedium = true; }
        if (aiDifficulty.GetComponent<AiDifficulty>().hard == true) { aiHard = true; }
    }

    private void Update() 
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true){Time.timeScale = 1; pauseMenu.SetActive(false); Invoke("IsPausedDelay",1f);}
        if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false){Time.timeScale = 0; pauseMenu.SetActive(true); isPaused = true;}
        if (gameOver == false && turncount == 9) Draw();
        if (gameOver == false)
        {
            CheckWinner();
            if (AITurn == true)
            {
                if (aiEasy == true){AIEasy();}
                if (aiMedium == true){AIMedium();}
                if (aiHard == true){AIHard();}
            }
        }
    }

    public void IsPausedDelay(){ isPaused = false;}
    public void ResumingTime(){Time.timeScale = 1;}
    public void ReturnToMainMenu()
    {
        for (int i = 0; i < achievementCanvas.transform.childCount; i++)
        {
            achievementCanvas.transform.GetChild(i).gameObject.SetActive(false);
        }
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void ResetGamestyle(){aiDifficulty.GetComponent<AiDifficulty>().ResetGamestyle();}
    public void Quitting(){Application.Quit();}

    void GameSetup()
    {
        stoppingPlayerFromPlaying.SetActive(false);
        gameOver = false;
        turncount = 0;
        textWinner.SetActive(false);

        // SETTING TURN BY RANDOMIZER
        whoseTurn = rnd.Next(0,2);
        if (whoseTurn == 1)
        {
            AITurn = true;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
        if (whoseTurn == 0)
        {
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }   

        // DECLARING EACH BUTTON(Spaces) INTERACTABLE AND HAVE NO IMAGE
        for (int i = 0; i < Spaces.Length; i++)
        {
            Spaces[i].interactable = true;
            Spaces[i].GetComponent<Image>().sprite = null;
        }

        // GIVING A VALUE TO markedSpaces
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                markedSpaces[i, j] = -1000;
            }
        }
    }



    public void tictacSpaces(int WhichNumber)
    {
        AITurn = true;
        // CHANGING BUTTON IMAGE TO X OR O
        Spaces[WhichNumber].image.sprite = playerIcons[whoseTurn];
        
        // SETTING BUTTON TO NOT INTERACTABLE
        Spaces[WhichNumber].interactable = false;

        // SETTING VALUE ON BUTTON PRESSED
        WhichNumberWasPressed(WhichNumber);

        // TURN COUNT
        turncount++;
        WinnerCheck();
        if (turncount == 9 && winner == false)
        {
            Draw();
        }

        // CHECKING WHOSE TURN IT IS
        if (whoseTurn == 0)
        {
            whoseTurn = 1;
            turnIcons[1].SetActive(false);
            turnIcons[0].SetActive(true);
        }
        else
        {
            whoseTurn = 0;
            turnIcons[1].SetActive(true);
            turnIcons[0].SetActive(false);
        }
    }

    private void WhichNumberWasPressed(int WhichNumber)
    {
        if (WhichNumber == 0)
        {
            markedSpaces[0, 0] = whoseTurn + 1;
        }
        else if (WhichNumber == 3)
        {
            markedSpaces[0, 1] = whoseTurn + 1;
        }
        else if (WhichNumber == 6)
        {
            markedSpaces[0, 2] = whoseTurn + 1;
        }
        else if (WhichNumber == 1)
        {
            markedSpaces[1, 0] = whoseTurn + 1;
        }
        else if (WhichNumber == 4)
        {
            markedSpaces[1, 1] = whoseTurn + 1;
        }
        else if (WhichNumber == 7)
        {
            markedSpaces[1, 2] = whoseTurn + 1;
        }
        else if (WhichNumber == 2)
        {
            markedSpaces[2, 0] = whoseTurn + 1;
        }
        else if (WhichNumber == 5)
        {
            markedSpaces[2, 1] = whoseTurn + 1;
        }
        else if (WhichNumber == 8)
        {
            markedSpaces[2, 2] = whoseTurn + 1;
        }
    }

    #region AI SECTION

    public void AIEasy()
    {
        if (whoseTurn == 1)
        {
            stoppingPlayerFromPlaying.SetActive(true);
            countingTime += Time.deltaTime;
            number = rnd.Next(0,9);
            if (Spaces[number].interactable != false)
            {
                if (countingTime > 1f)
                {
                    AITurn = false;
                    turncount++;
                    Spaces[number].image.sprite = playerIcons[whoseTurn];
                    Spaces[number].interactable = false;

                    if (number == 0)
                    {
                        markedSpaces[0, 0] = whoseTurn + 1;
                    }
                    else if (number == 3)
                    {
                        markedSpaces[0, 1] = whoseTurn + 1;
                    }
                    else if (number == 6)
                    {
                        markedSpaces[0, 2] = whoseTurn + 1;
                    }
                    else if (number == 1)
                    {
                        markedSpaces[1, 0] = whoseTurn + 1;
                    }
                    else if (number == 4)
                    {
                        markedSpaces[1, 1] = whoseTurn + 1;
                    }
                    else if (number == 7)
                    {
                        markedSpaces[1, 2] = whoseTurn + 1;
                    }
                    else if (number == 2)
                    {
                        markedSpaces[2, 0] = whoseTurn + 1;
                    }
                    else if (number == 5)
                    {
                        markedSpaces[2, 1] = whoseTurn + 1;
                    }
                    else if (number == 8)
                    {
                        markedSpaces[2, 2] = whoseTurn + 1;
                    }
                    WinnerCheck();
                    whoseTurn = 0;
                    turnIcons[1].SetActive(true);
                    turnIcons[0].SetActive(false);
                    countingTime = 0;
                    stoppingPlayerFromPlaying.SetActive(false);
                }
            }
        }
    }
    
    public void AIMedium()
    {
        AITurn = false;
        if (whoseTurn == 1)
        {
            stoppingPlayerFromPlaying.SetActive(true);
            if (turncount == 2 || turncount == 3 || turncount == 4 || turncount == 7 || turncount == 8) 
            {
                AITurn = true;
                countingTime += Time.deltaTime;
                number = rnd.Next(0, 9);
                if (Spaces[number].interactable != false)
                {
                    if (countingTime > 1f)
                    {
                        AITurn = false;
                        turncount++;
                        Spaces[number].image.sprite = playerIcons[whoseTurn];
                        Spaces[number].interactable = false;

                        if (number == 0)
                        {
                            markedSpaces[0, 0] = whoseTurn + 1;
                        }
                        else if (number == 3)
                        {
                            markedSpaces[0, 1] = whoseTurn + 1;
                        }
                        else if (number == 6)
                        {
                            markedSpaces[0, 2] = whoseTurn + 1;
                        }
                        else if (number == 1)
                        {
                            markedSpaces[1, 0] = whoseTurn + 1;
                        }
                        else if (number == 4)
                        {
                            markedSpaces[1, 1] = whoseTurn + 1;
                        }
                        else if (number == 7)
                        {
                            markedSpaces[1, 2] = whoseTurn + 1;
                        }
                        else if (number == 2)
                        {
                            markedSpaces[2, 0] = whoseTurn + 1;
                        }
                        else if (number == 5)
                        {
                            markedSpaces[2, 1] = whoseTurn + 1;
                        }
                        else if (number == 8)
                        {
                            markedSpaces[2, 2] = whoseTurn + 1;
                        }
                        WinnerCheck();
                        whoseTurn = 0;
                        turnIcons[1].SetActive(true);
                        turnIcons[0].SetActive(false);
                        countingTime = 0;
                        stoppingPlayerFromPlaying.SetActive(false);
                    }
                }
                return;
            }
            var bestScore = -Mathf.Infinity;
            int whichI = 0;
            int whichJ = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (markedSpaces[i, j] == -1000)
                    {
                        markedSpaces[i, j] = 2;
                        var score = minimax(markedSpaces, 0, false);
                        markedSpaces[i, j] = -1000;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            whichI = i;
                            whichJ = j;
                        }
                    }
                }
            }
            if (whichI == 0)
            {
                if (whichJ == 0)
                { move = 0; }
                if (whichJ == 1)
                { move = 3; }
                if (whichJ == 2)
                { move = 6; }
            }
            if (whichI == 1)
            {
                if (whichJ == 0)
                { move = 1; }
                if (whichJ == 1)
                { move = 4; }
                if (whichJ == 2)
                { move = 7; }
            }
            if (whichI == 2)
            {
                if (whichJ == 0)
                { move = 2; }
                if (whichJ == 1)
                { move = 5; }
                if (whichJ == 2)
                { move = 8; }
            }
            if (markedSpaces[whichI, whichJ] == 1) { Draw(); return; }
            StartCoroutine(Hello(whichI, whichJ));
        }
    }

    public void AIHard()
    {
        AITurn = false;
        if (whoseTurn == 1)
        {
            stoppingPlayerFromPlaying.SetActive(true);
            var bestScore = -Mathf.Infinity;
            int whichI = 0;
            int whichJ = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (markedSpaces[i,j] == -1000)
                    {
                        markedSpaces[i,j] = 2;
                        var score = minimax(markedSpaces, 0, false);
                        markedSpaces[i,j] = -1000;
                        if (score > bestScore)
                        {
                            bestScore = score;
                            whichI = i;
                            whichJ = j;
                        }
                    }
                }
            }
            if(whichI == 0)
            { 
                if(whichJ == 0)
                {move = 0;}
                if (whichJ == 1)
                { move = 3;}
                if (whichJ == 2)
                { move = 6;}
            }
            if (whichI == 1)
            {
                if (whichJ == 0)
                { move = 1; }
                if (whichJ == 1)
                { move = 4; }
                if (whichJ == 2)
                { move = 7; }
            }
            if (whichI == 2)
            {
                if (whichJ == 0)
                { move = 2; }
                if (whichJ == 1)
                { move = 5; }
                if (whichJ == 2)
                { move = 8; }
            }
            if(markedSpaces[whichI, whichJ] == 1) {Draw(); return;}
            StartCoroutine(Hello(whichI, whichJ));

        }   
    }

    IEnumerator Hello(int whichI, int whichJ)
    {
        yield return new WaitForSeconds(1f);
        markedSpaces[whichI, whichJ] = 2;
        Spaces[move].image.sprite = playerIcons[whoseTurn];
        Spaces[move].interactable = false;
        turnIcons[0].SetActive(false);
        turnIcons[1].SetActive(true);
        whoseTurn = 0;
        turncount++;
        stoppingPlayerFromPlaying.SetActive(false);
        countingTime = 0;
    }

    float minimax(float[,] markedSpaces, float depth, bool isMax)
    {
        float result = WinnerCheck();
        if (result != 0)
        {
            if (result == 2)return 10;
            if (result == 1)return -10;
            if (result == 6)return 0;
        }
        if (isMax)
        {
            float bestScore = -Mathf.Infinity;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (markedSpaces[i,j] == -1000)
                    {
                        markedSpaces[i,j] = 2;
                        float score = minimax(markedSpaces, depth + 1, false);
                        markedSpaces[i,j] = -1000;
                        bestScore = Mathf.Max(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
        else
        {
            float bestScore = Mathf.Infinity;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (markedSpaces[i,j] == -1000)
                    {
                        markedSpaces[i,j] = 1;
                        float score = minimax(markedSpaces, depth + 1, true);
                        markedSpaces[i,j] = -1000;
                        bestScore = Mathf.Min(score, bestScore);
                    }
                }
            }
            return bestScore;
        }
    }

    #endregion
    
    #region Winner Related

    bool equals3(float a, float b, float c)
    {
        return a == b && b == c && a != 0;
    }

    float WinnerCheck()
    {
        float winner = 0;
        dig1 = false; 
        dig2 = false;
        //horizontal
        for (int i = 0; i < 3; i++)
        {
            if (equals3(markedSpaces[0, i], markedSpaces[1, i], markedSpaces[2, i]))
            {
                winner = markedSpaces[0, i];
            }
        }

        //vertical
        for (int i = 0; i < 3; i++)
        {
            if (equals3(markedSpaces[i, 0], markedSpaces[i, 1], markedSpaces[i, 2]))
            {
                winner = markedSpaces[i, 0];
            }
        }


        //diagonal
        if (equals3(markedSpaces[0, 0], markedSpaces[1, 1], markedSpaces[2, 2]))
        {
            winner = markedSpaces[0, 0];
            dig1 = true;
        }
        if (equals3(markedSpaces[0, 2], markedSpaces[1, 1], markedSpaces[2, 0]))
        {
            winner = markedSpaces[0, 2];
            dig2 = true;
        }

        int openSpots = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (markedSpaces[i, j] == -1000)
                {
                    openSpots++;
                }
            }
        }

        if (winner == 0 && openSpots == 0)
        {
            return 6; // TIE
        }
        else
        {

            return winner; // winner 1 = O  // winner 2 = X
        }
    }

        void CheckWinner()
        {
            // Vertical
            float s1 = markedSpaces[0,0] + markedSpaces[0,1] + markedSpaces[0,2];
            float s2 = markedSpaces[0,1] + markedSpaces[1,1] + markedSpaces[2,1];
            float s3 = markedSpaces[0,2] + markedSpaces[1,2] + markedSpaces[2,2];
            if (s1 == 6 || s1 == 3){WinnerDisplay(3);}
            if (s2 == 6 || s2 == 3){WinnerDisplay(1);}
            if (s3 == 6 || s3 == 3){WinnerDisplay(2);}

            // Horizontal 
            float s4 = markedSpaces[0,0] + markedSpaces[1,0] + markedSpaces[2,0];
            float s5 = markedSpaces[1,0] + markedSpaces[1,1] + markedSpaces[1,2];
            float s6 = markedSpaces[2,0] + markedSpaces[2,1] + markedSpaces[2,2];
            if (s4 == 6 || s4 == 3){WinnerDisplay(0);}
            if (s5 == 6 || s5 == 3){WinnerDisplay(4);}
            if (s6 == 6 || s6 == 3){WinnerDisplay(5);}

            // DIAGONAL
            float s7 = markedSpaces[0,0] + markedSpaces[1,1] + markedSpaces[2,2];
            float s8 = markedSpaces[0,2] + markedSpaces[1,1] + markedSpaces[2,0];
            if (s7 == 6 || s7 == 3){WinnerDisplay(6);}
            if (s8 == 6 || s8 == 3){WinnerDisplay(7);}
        }

    void WinnerDisplay(int indexIn)
    {
        gameOver = true;
        if (aiEasy == true || aiMedium == true || aiHard == true)
        {
            if (whoseTurn == 0)
            {
                CoinAndGamesData.PlayerCoins++;
                CoinAndGamesData.GamesLost++;
                CoinAndGamesData.HiddenAchievement--;
                CoinAndGamesData.GamesPlayed++;
                xPlayerScore++;
                textXPlayer.text = xPlayerScore.ToString();
                coins.GetComponent<Text>().text = ": " + CoinAndGamesData.PlayerCoins.ToString();
                textWinner.GetComponent<Text>().text = "Player X won!";
            }
            if (whoseTurn == 1)
            {
                CoinAndGamesData.PlayerCoins += 2;
                CoinAndGamesData.GamesWon++;
                CoinAndGamesData.GamesPlayed++;
                oPlayerScore++;
                textOPlayer.text = oPlayerScore.ToString();
                coins.GetComponent<Text>().text = ": " + CoinAndGamesData.PlayerCoins.ToString();
                textWinner.GetComponent<Text>().text = "Player O won!";
            }
        }
        else
        {
            if (whoseTurn == 0)
            {
                CoinAndGamesData.PlayerCoins++;
                CoinAndGamesData.GamesPlayed++;
                xPlayerScore++;
                textXPlayer.text = xPlayerScore.ToString();
                coins.GetComponent<Text>().text = ": " + CoinAndGamesData.PlayerCoins.ToString();
                textWinner.GetComponent<Text>().text = "Player X won!"; 
            }
            if (whoseTurn == 1)
            {
                CoinAndGamesData.PlayerCoins ++;
                CoinAndGamesData.GamesPlayed++;
                oPlayerScore++;
                textOPlayer.text = oPlayerScore.ToString();
                coins.GetComponent<Text>().text = ": " + CoinAndGamesData.PlayerCoins.ToString();
                textWinner.GetComponent<Text>().text = "Player O won!";
            }
        }

        if (CoinAndGamesData.PlayerCoins > CoinAndGamesData.MostCoins) CoinAndGamesData.MostCoins = CoinAndGamesData.PlayerCoins;
        
        achievements.GetComponent<Achievements>().AchievementCheck();
        if (currentSaveFile.GetComponent<CurrentSaveFile>().savefile == 1)SaveSystem.SaveSlot1();
        if (currentSaveFile.GetComponent<CurrentSaveFile>().savefile == 2)SaveSystem.SaveSlot2();
        if (currentSaveFile.GetComponent<CurrentSaveFile>().savefile == 3)SaveSystem.SaveSlot3();
        textWinner.SetActive(true);
        winningLine[indexIn].SetActive(true);

        // MAKING EVERY SPACE NOT INTERACTABLE
        for (int i = 0; i < Spaces.Length; i++)
        {
            Spaces[i].interactable = false;
        }
    }

    void Draw()
    {
        textWinner.GetComponent<Text>().text = "It's a draw!";
        textWinner.SetActive(true);
        draw = true;
    }

    #endregion

    #region gameloop
    public void Rematch()
    {
        GameSetup();
        for(int i = 0; i < winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);
        }
        textWinner.SetActive(false);
    }

    public void Restart()
    {
        xPlayerScore = 0;
        oPlayerScore = 0;
        textXPlayer.text = "0";
        textOPlayer.text = "0";
        Rematch();
    }
    #endregion
}