using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemManagerPD31 : MonoBehaviour
{
    [SerializeField] TMP_Text cherryCounter;
    int cherryAmount;
    public static GemManagerPD31 instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }
    private void Start()
    {
        cherryCounter.text = cherryAmount.ToString();
    }
    public void ChangeGemAmount(int x)
    {
        cherryAmount += x;
        cherryCounter.text = cherryAmount.ToString();
    }
}
