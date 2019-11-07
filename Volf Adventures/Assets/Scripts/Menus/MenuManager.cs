using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    // Start is called before the first frame update

    public string nextScene;
    public string firstLevel="Level1";
    public GameObject pauseMenu;
    public  GameObject deathMenu;
    public GameObject winMenu;

    public static bool onPause {  get; set; }
    private bool death;
    private bool win;
    private Time time;

    delegate void ShowMethod(bool show); 
    void Start()
    {
        onPause = false;
        if (instance == null)
        {
            instance = this;
        }
        
        Resume();
    }
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPause)
            {
                Resume();
            }
            else {
                Pause();
            }
              
        }
    }

    public void Pause() {
        onPause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; 
    }
    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        instance.Invoke("Resumer", 0.5f);
    }
    private void Resumer() {
        onPause = false;
    }
    public void ShowDeathMenu()
    {
        Invoke("Show", 1.5f);
    }
    public void HideDeathMenu() {
        deathMenu.SetActive(false);
    }

    public void ShowWinMenu()
    {
        Time.timeScale = 0f;
        winMenu.SetActive(true);
    }
    public void HideWinMenu()
    {
        Time.timeScale = 1f;
        winMenu.SetActive(false);
    }
    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu() {
        if (onPause) {
            Resume();
        }
         SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }


    public void NextLevel() {

        Time.timeScale = 1f;
        SceneManager.LoadScene(nextScene);
    }

    public void NewGame() {

        SavegameManager.CleanSave();
        SceneManager.LoadScene(firstLevel);
        Time.timeScale = 1f; 
        
    }  
    private void Show() {
        deathMenu.SetActive(true);
    }
   


}
