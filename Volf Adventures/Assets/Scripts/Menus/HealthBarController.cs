using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour  
{
    public GameObject fill;
    public Color usualColor;
    public Color dangerColor;

    public float dangerFlashFrequency=0.3f;

    private float timeToFlash;
    private PlayerState player;
    private Image image;
    private Slider slider;
    float calculatedPercentage;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
        image = fill.GetComponent<Image>();
        slider = GetComponent<Slider>();
        timeToFlash = dangerFlashFrequency;
        ChangeHp();
    }

    private void Update()
    {
        if (calculatedPercentage < 30 && timeToFlash <= 0)
        {
            FlashColor();
            timeToFlash = dangerFlashFrequency;
        }
        else if (calculatedPercentage > 30) {
            image.color = usualColor;
        }
       
        timeToFlash -= Time.deltaTime;

    }
   public void ChangeHp() {
         calculatedPercentage = ((float)player.Hp / (float)player.MHp) * 100;
         slider.value = calculatedPercentage;
    }
    void FlashColor() {
        if (image.color == usualColor)
        {
            image.color = dangerColor;          
        }
        else {
            image.color = usualColor;
        }
    }
}
