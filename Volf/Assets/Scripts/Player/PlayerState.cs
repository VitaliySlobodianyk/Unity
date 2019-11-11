using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public GameObject body;
    public MenuManager menu;
    public GameManager gameManager;
    public SoundManager soundManager;
    public bool isDead { get; private set; }
    public int Hp { get { return hp; } set { this.hp = value; } }
    public int MHp { get { return mhp; } }
    
    public bool godMode = false;    
    public int bulletsCount { get; private set;}

    Animator animator;
    Rigidbody2D rb;
    int hp, mhp = 100;
    void Start()
    {
        bulletsCount = 0;
        hp = mhp;
        animator = GetComponent<Animator>();
        gameManager.ChangeHealth();
        rb = GetComponent<Rigidbody2D>();   
    }

    public void Heal(int amount)
    {
        hp += amount;
        if (hp > mhp)
        {
            hp = mhp;
        }
        gameManager.ChangeHealth();
    }

    public void TakeDamage(int damage)
    {
       
        if (!godMode)
        {
            soundManager.Play("PlayerDamage");
            hp -= damage;
            GameManager.newGame = true;
            if (hp <= 0)
            {
                Death();
            }
        }
        gameManager.ChangeHealth();
    }
    public void Death()
    {
        if (!godMode)
        {
            soundManager.Stop("Main");
            soundManager.Play("WolfDie");
            isDead = true;
            animator.SetBool("IsDead", true);          
            Invoke("spanBody", .5f);
            menu.ShowDeathMenu();         
              isDead = false;                  
        }
        gameManager.ChangeHealth();

    } 
    void spanBody()
    {
        Instantiate(body, transform.position, transform.rotation);
        Destroy(gameObject);
    }

  public void addBullets(int amount) {
        bulletsCount += amount;
    }
  public void shoot() {
        bulletsCount--;
    }

}
