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
    public TextMeshProUGUI bullets;
    public HealthBarController healthController;


    public static bool newGame = true;

    public int gemsGount { get; private set; }

  
    private PlayerState state;

    private void Awake()
    {
        
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
      
            gemsGount = 0;
            state = player.GetComponent<PlayerState>();
            ChangeHealth();
          
            FindObjectOfType<SoundManager>().Play("Main");
            if (!newGame)
            {
                LoadPlayer();
            }    
    }

    public void ChangeRoundsCount(int value)
    {
        bullets.SetText(value.ToString());
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
    }

    public static void LoadGame()
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
               collectable.transform.position.y - 1 < player.transform.position.y) {
                Destroy(collectable);
            }
        }
    } 
}
