using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonDisabler : MonoBehaviour
{
    public Button resume;
    
    void Start()
    {
        if (!SavegameManager.CheckSaveEmpty()) {
            resume.interactable = false;
            resume.enabled = false;
        }
    }

    
}
