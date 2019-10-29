using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
   public int health;
   public int gemsCount;

   public string levelName;
   public float[] position;

    public PlayerData(int health, int gemsCount, string levelName, float[] position) {
        this.health = health;
        this.gemsCount = gemsCount;
        this.levelName = levelName;
        if (position.Length == 3)
        {
            this.position = position;
        }
        else {
            throw new System.Exception("Invalid position");
        }   
    }
}
