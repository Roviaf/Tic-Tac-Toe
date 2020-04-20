using UnityEngine;

public class CurrentSaveFile : MonoBehaviour
{
    public int savefile;
    private static CurrentSaveFile playerInstance;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (playerInstance == null){playerInstance = this;} 
        else{Object.Destroy(gameObject);}
    }

    public void GettingSaveFileNumber(int value)
    {
        savefile = value;
    }
}