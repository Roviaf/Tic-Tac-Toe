using System.IO;
using UnityEngine;

public class MainMenuSaving : MonoBehaviour 
{
    public static bool LoadSlot1()
    {
        string path = Application.persistentDataPath + "/saveslot1.save";
        if (File.Exists(path))return true;
        else{return false;}
    }
    public static bool LoadSlot2()
    {
        string path = Application.persistentDataPath + "/saveslot2.save";
        if (File.Exists(path)) return true;
        else { return false; }
    }
    public static bool LoadSlot3()
    {
        string path = Application.persistentDataPath + "/saveslot3.save";
        if (File.Exists(path)) return true;
        else { return false; }
    }
}