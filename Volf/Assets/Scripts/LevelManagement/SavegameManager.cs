using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class SavegameManager 
{
   static string path = Application.dataPath + "/game.wolf";
   
    public static void saveGame(PlayerData player) {
        BinaryFormatter formater = new BinaryFormatter();
        FileStream file = new FileStream(path, FileMode.Create);
        formater.Serialize(file, player);
        file.Close();
    }
    public static void CleanSave() {
        File.Delete(path); 
    }
    public static PlayerData ReadGame() {
        if (File.Exists(path)) {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);
            PlayerData load = formater.Deserialize(file) as PlayerData;
            file.Close();
            return load;
        }
        return null;
       
    }
    public static bool CheckSaveEmpty() {
        return File.Exists(path);
    }
  

   


}
