using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public GameManager gameManager;
   PlayerUIController ui;
   public GameObject body;
    void Start()
    {
        ui = GetComponent<PlayerUIController>();
    }

    // Update is called once per frame
    public void AddBananas() {
        gameManager.AddBananas(gameManager.BananasPerClick);
        ui.ShowMessage(gameManager.BananasPerClick);
        Rotate();
    }

    public void Rotate() {
        body.transform.Rotate(0, 180, 0);
    }
}
