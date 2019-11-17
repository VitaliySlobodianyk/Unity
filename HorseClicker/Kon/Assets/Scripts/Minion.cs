using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
    
   
    public GameObject body;
    public MinionUI ui;
    public float speed = 2;
    public int bananasToSpawn = 1;
    public GameObject banana;
    public bool faceRight=false;
    GameManager gm;
    bool spawnedBananas = false;
    bool pause = false;
    Rigidbody2D rb;
    Vector2 player;
    Vector2 start;
    bool mooveToPlayer = true;
    float timeBtwFlips = 0.2f;
    float lastFlip;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        lastFlip = 0;
        start = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        rb = GetComponent<Rigidbody2D>();      
        if (transform.position.x <= player.x) {         
            body.transform.Rotate(0, 180, 0);
        }
        pause = true;
        Invoke("ResumeWithoutFlip", 1f);
    }

    // Update is called once per frame
    void Update()
    {
         if (Vector2.Distance(start, transform.position) == 0 && spawnedBananas) {
            mooveToPlayer = true;
            spawnedBananas = false;
            Flip();
        }
        if (mooveToPlayer && !pause) {
            transform.position = Vector2.MoveTowards(transform.position, player, speed * Time.deltaTime);
        }
        else if(!mooveToPlayer && !pause) {
            transform.position = Vector2.MoveTowards(transform.position, start, speed * Time.deltaTime);
        }
    }
    void spawnBananas() {
        if (!spawnedBananas) {
            ui.ShowMessage(bananasToSpawn); 
            pause = true;           
            spawnedBananas = true;
            gm.AddBananas(bananasToSpawn);
            Instantiate(banana, transform.position, Quaternion.identity);
            Invoke("Resume", 1f);
        }
    }
    void Resume() {
        pause = false;   
        Flip();   
    }
    void ResumeWithoutFlip() {
        pause = false;
    }
    void Flip()
    {
        if (Time.time - lastFlip > timeBtwFlips)
        {
            faceRight = !faceRight;
            body.transform.Rotate(0, 180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mooveToPlayer = false;
            spawnBananas();

        }
    }
   
}
