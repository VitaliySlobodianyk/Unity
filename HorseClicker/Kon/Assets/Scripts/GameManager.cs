using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public UIManager uI;
    public MinionManager minionManager;
    public SoundManager sound;
    public int BananasCount { get; private set; }
    public int MinionasCount { get; private set;}
    public int MinionaPriceToAdd { get; private set; }

    private int minionaPriceModifier = 2;
    public int BananasPerClick { get; private set; }
    public int ClickPriceToModify { get; private set; }

    private float clickModifier = 1.1f;
    
    private int clickPriceModifier = 3;


    public static bool newGame = true;

    int bananasASecondCur;
    int bananasASecondPrev;
    void Start()
    {
        sound.Play("Main");
        if (newGame)
        {
            bananasASecondCur = bananasASecondPrev = 0;
            BananasCount = 0;
            MinionasCount = 1;
            BananasPerClick = 10;
            MinionaPriceToAdd =ClickPriceToModify = 100;
            minionManager.SpawnMinionaRandomly();
        }
        else {
            LoadGame();
        }
              
        InvokeRepeating("CalculateAvg", 0f, 1f);
        InvokeRepeating("SaveGame", 1f, 10f);
    }
    private void AddToAvgCalculation(int amount) {
        bananasASecondCur += amount;
    }

    public void AddBananas(int amount) {
        BananasCount += amount;
        AddToAvgCalculation(amount);
        uI.UpdateBananasCount(BananasCount);
    }

    public void CalculateAvg() {
        if (bananasASecondPrev != 0)
        {
            bananasASecondCur = (bananasASecondCur + bananasASecondPrev) / 2;           
        }
        uI.UpdateBananasAvg(bananasASecondCur);
        bananasASecondPrev = bananasASecondCur;
        bananasASecondCur = 0;
    }

    public void BuyMiniona() {
        if (BananasCount >= MinionaPriceToAdd) {
            BananasCount -= MinionaPriceToAdd;
            uI.UpdateBananasCount(BananasCount);
            MinionasCount++;         
            MinionaPriceToAdd *= minionaPriceModifier;
            minionManager.SpawnMinionaRandomly();
            uI.UpdateMinionaButtonStats();   
        } 
    }
    public void ModifyClick() {
        if (BananasCount >= ClickPriceToModify)
        {
            BananasCount -= ClickPriceToModify;
            uI.UpdateBananasCount(BananasCount);
            BananasPerClick = (int)(clickModifier * BananasPerClick);
            ClickPriceToModify *= clickPriceModifier;        
            uI.UpdateClickButtonStats();
        }
    }

    private void LoadGame() {
       GameData game = SaveGameManager.ReadGame();   
        PlaceMinionas(game.minionas);
        LoadStats(game);
        newGame = true;
    }
    private void PlaceMinionas(List<float[]> minionasInfo) {
        foreach (float[]arr in minionasInfo){
            minionManager.SpawnMiniona(new Vector2(arr[0], arr[1]));
        }
        minionManager.minionsInfo = minionasInfo;
    }
    private void LoadStats(GameData game) {
        BananasCount = game.bananas;
        Debug.Log(game.bananas);
        BananasPerClick = game.currentClickModifier;
        ClickPriceToModify = game.currentClickPrice;
        MinionasCount = game.minionas.Count;
        MinionaPriceToAdd = game.minionaPrice;
        uI.UpdateBananasCount(BananasCount);
        uI.UpdateClickButtonStats();
        uI.UpdateMinionaButtonStats();
    }

    public void SaveGame() { 
        SaveGameManager.saveGame(new GameData(BananasCount,BananasPerClick,ClickPriceToModify,
            minionManager.minionsInfo,MinionaPriceToAdd));
    }
}
