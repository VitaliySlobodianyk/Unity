using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MentuController : MonoBehaviour
{
    [SerializeField] GameObject inGameMenu;
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void UseMenu()
    {
        if (inGameMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            inGameMenu.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            inGameMenu.SetActive(true);
        }
    }
    public void Quit()
    {
        Application.Quit();
        
    }
    public void Restart(int x)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
