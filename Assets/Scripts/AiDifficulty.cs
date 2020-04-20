using UnityEngine;

public class AiDifficulty : MonoBehaviour
{
    private static AiDifficulty playerInstance;
    
    // VARS FOR DIFFICULTIES
    public bool easy = false;
    public bool medium = false;
    public bool hard = false;
    public bool couchPlayer = false;
    
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

    public void EasyDifficulty(){easy = true;}
    public void MediumDifficulty(){medium = true;}
    public void HardDifficulty(){hard = true;}
    public void CouchPlayer(){couchPlayer = true;}
    public void ResetGamestyle(){easy=false;medium=false;hard=false;couchPlayer=false;}
}