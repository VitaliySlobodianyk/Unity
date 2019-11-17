using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    // Start is called before the first frame update

    public string main = "MainMenu";
    public string game = "Game";
    public GameObject pauseMenu;
 
    public static bool onPause { get; set; }
   
    void Start()
    {
        if (SceneName() != main)
        {
            onPause = false;
            if (instance == null)
            {
                instance = this;
            }
            Resume();
        }

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (onPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Pause()
    {
        onPause = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        instance.Invoke("Resumer", 0.5f);
    }
    private void Resumer()
    {
        onPause = false;
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        if (onPause)
        {
            Resume();
        }
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void NewGame() {
        SaveGameManager.CleanSave();
        Game();
    }
    public void LoadGame() {
        if (SaveGameManager.CheckSaveEmpty())
        {
            GameManager.newGame = false;        
        }
        Game();
    }
    
    public void Game()
    {   
        SceneManager.LoadScene(game);
        Time.timeScale = 1f;
    }
   
    public static string SceneName() {
        return SceneManager.GetActiveScene().name;
    }
}
