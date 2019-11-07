using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;


    public TextMeshProUGUI counter;
    public Slider healthBar;


    public static bool newGame = true;

    public int gemsGount { get; private set; }

    private HealthBarController healthController;
    private PlayerState state;

    void Start()
    {
      
        gemsGount = 0;
        if (healthBar != null)
        {
            healthController = healthBar.GetComponent<HealthBarController>();
            ChangeHealth();
        }
        if (player != null)
        {
            state = player.GetComponent<PlayerState>();
        }
        if (!newGame)
        {
            LoadPlayer();
        }

        if (SceneName() == "MainMenu") {
            FindObjectOfType<SoundManager>().Play("Menu");
        }
        else {
            FindObjectOfType<SoundManager>().Play("Main");
        }

    }


    public void ChangeGemsCount()
    {
        gemsGount++;
        counter.text = gemsGount.ToString();
    }
    public void SetGemsCount(int num)
    {
        gemsGount = num;
        counter.text = gemsGount.ToString();
    }
    public void ChangeHealth()
    {
        healthController.ChangeHp();
    }

    public static string SceneName()
    {
        return SceneManager.GetActiveScene().name;
    }
    public void Save()
    {
        float[] position = new float[3] { player.transform.position.x, player.transform.position.y, player.transform.position.z };
        SavegameManager.saveGame(new PlayerData(state.Hp, gemsGount, SceneName(), position));
        Debug.Log("Saved");
    }

    public void LoadGame()
    {
        PlayerData data = SavegameManager.ReadGame();
        if (data != null)
        {
            SceneManager.LoadScene(data.levelName);
            newGame = false;
        }
    }
    private void LoadPlayer() {
        PlayerData data = SavegameManager.ReadGame();
        SetGemsCount(data.gemsCount);
        state.Hp = data.health;
        Vector3 position = new Vector3(data.position[0], data.position[1], data.position[2]);
        player.transform.position= position;
        CleanPlayerPath();
        newGame = true;
    }
    private void CleanPlayerPath() {
        GameObject[] collectablesToClean;
        collectablesToClean = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (GameObject collectable in collectablesToClean)
        {           
            if (collectable.transform.position.x < player.transform.position.x  &&
               collectable.transform.position.y - 0.5 < player.transform.position.y) {
                Destroy(collectable);
            }
        }
    } 
}
