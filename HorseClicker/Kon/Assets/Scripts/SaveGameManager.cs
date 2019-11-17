using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SaveGameManager 
{
    static string path = Application.dataPath + "/game.kon";

    public static void saveGame(GameData player)
    {
        BinaryFormatter formater = new BinaryFormatter();
        FileStream file = new FileStream(path, FileMode.Create);
        formater.Serialize(file, player);
        file.Close();
    }
    public static void CleanSave()
    {
        File.Delete(path);
    }
    public static GameData ReadGame()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            GameData load = formater.Deserialize(file) as GameData;
            file.Close();
            return load;
        }
        return null;

    }
    public static bool CheckSaveEmpty()
    {
        return File.Exists(path);
    }

}
