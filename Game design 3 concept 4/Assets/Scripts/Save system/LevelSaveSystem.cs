using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LevelSaveSystem : MonoBehaviour
{
    public static void SaveCompletion(int levelCompletion, string levelName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + levelName + ".pyro";
        if (File.Exists(path))
        {
            File.Delete(path);
        }


        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData data = new LevelData(levelCompletion);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log(path);

        //using (FileStream stream = new FileStream(path, FileMode.Create))
        //{
        //    PlayerData data = new PlayerData(player);
        //    formatter.Serialize(stream, data);
        //}
    }

    public LevelData LoadCompletion(string levelName)
    {
        string path = Application.persistentDataPath + "/" + levelName + ".pyro";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            stream.Position = 0;
            LevelData data = (LevelData)formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);

            return new LevelData(0);
        }

    }
}
