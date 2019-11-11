using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    void Start()
    {        
            FindObjectOfType<SoundManager>().Play("Menu");    
    }

    public void LoadGame() {
        GameManager.LoadGame();
    }
}
