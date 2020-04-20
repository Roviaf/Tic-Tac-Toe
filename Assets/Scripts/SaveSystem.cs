using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    // SAVE RELATED

    public static void SaveSlot1()
    {
        string path = Application.persistentDataPath + "/saveslot1.save";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data1 = new PlayerData();
        formatter.Serialize(stream, data1);
        stream.Close();
    }

    public static void SaveSlot2()
    {
        string path = Application.persistentDataPath + "/saveslot2.save";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data2 = new PlayerData();
        formatter.Serialize(stream, data2);
        stream.Close();
    }

    public static void SaveSlot3()
    {
        string path = Application.persistentDataPath + "/saveslot3.save";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data3 = new PlayerData();
        formatter.Serialize(stream, data3);
        stream.Close();
    }

    // LOAD RELATED

    public static PlayerData LoadSlot1()
    {
        string path = Application.persistentDataPath + "/saveslot1.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data1 = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data1;
        }
        else
        {
            Debug.Log("Save File not found in " + path);
            return null;
        }
    }

    public static PlayerData LoadSlot2()
    {
        string path = Application.persistentDataPath + "/saveslot2.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data2 = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data2;
        }
        else
        {
            Debug.Log("Save File not found in " + path);
            return null;
        }
    }

    public static PlayerData LoadSlot3()
    {
        string path = Application.persistentDataPath + "/saveslot3.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data3 = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data3;
        }
        else
        {
            Debug.Log("Save File not found in " + path);
            return null;
        }
    }
}