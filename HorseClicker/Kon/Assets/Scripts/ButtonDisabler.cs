using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDisabler : MonoBehaviour
{
    public Button button;
    void Start()
    {
        GameObject.FindObjectOfType<SoundManager>().Play("Main");
        if (!SaveGameManager.CheckSaveEmpty()) {
            button.interactable = false;
        }

    }
}
