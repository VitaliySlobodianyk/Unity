using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager gameManager;

   public TextMeshProUGUI bananasCount;
   public Slider avgBananasSlider;
   public TextMeshProUGUI avgBananasCount;

    public Button buyMinion;
    public TextMeshProUGUI minionPrice;
    public TextMeshProUGUI minionasCount;

    public Button modifyClick;
    public TextMeshProUGUI clickPrice;
    public TextMeshProUGUI bananasPerClick;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ClickButtonTracker", 0f, 1f);
        InvokeRepeating("MinionaButtonTracker", 0f, 1f);
        UpdateClickButtonStats();
        UpdateMinionaButtonStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBananasCount(int value) {
        bananasCount.text = value.ToString();
    }
    public void UpdateBananasAvg(int value) {
        avgBananasCount.text = value.ToString();
        if (value > avgBananasSlider.maxValue)
        {
            avgBananasSlider.value = avgBananasSlider.maxValue;
        }
        else {
            avgBananasSlider.value = value;
        }
       
    }

    private void MinionaButtonTracker() {
        if (gameManager.MinionaPriceToAdd > gameManager.BananasCount)
        {
            buyMinion.interactable = false;
        }
        else {
            buyMinion.interactable = true;
        }
    }
    private void ClickButtonTracker()
    {
        if (gameManager.ClickPriceToModify > gameManager.BananasCount)
        {
            modifyClick.interactable = false;
        }
        else
        {
            modifyClick.interactable = true;
        }
    }

    public  void UpdateClickButtonStats() {
        clickPrice.text = gameManager.ClickPriceToModify.ToString();
        bananasPerClick.text = gameManager.BananasPerClick.ToString(); 
    }
    public void UpdateMinionaButtonStats() {
        minionPrice.text = gameManager.MinionaPriceToAdd.ToString();
        minionasCount.text = gameManager.MinionasCount.ToString();
    }
}
