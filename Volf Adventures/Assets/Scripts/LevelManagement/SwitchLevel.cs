using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevel : MonoBehaviour
{
    // Start is called before the first frame update

   public  MenuManager menu;
    public GameManager game;
    public GameObject poof;
    public bool lastLevel = false; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Instantiate(poof, transform.position, Quaternion.identity);
            FindObjectOfType<SoundManager>().Play("Victory");
            Destroy(collision.gameObject);
            Invoke("ShowMenuDelayed", 1.5f);
        }
    }

   void ShowMenuDelayed() {
        menu.ShowWinMenu();
        if (lastLevel)
        {
            SavegameManager.CleanSave();
        }
        else
        {
            game.Save();
        }
    }
}
