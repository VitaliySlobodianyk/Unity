using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{  
    public int bananas;
    public int currentClickModifier;
    public int currentClickPrice;
    public List<float[]> minionas;
    public int minionaPrice;

    public GameData( int bananas, int currentClickModifier, int currentClickPrice, List<float[]> minionas, int minionaPrice) {
        this.bananas = bananas;
        this.currentClickModifier = currentClickModifier;
        this.currentClickPrice = currentClickPrice;
        this.minionas = minionas;
        this.minionaPrice = minionaPrice;
    }
}
