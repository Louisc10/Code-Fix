using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevelStatus(LevelData levelData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, levelData);
        stream.Close();
    }

    public static LevelData LoadData()
    {
        string path = Application.persistentDataPath + "/level.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;

            stream.Close();


            return data;
        }
        else
        {
            Debug.LogWarning("Save file not found in " + path);
            return new LevelData(new bool[10]);
        }
    }
}
