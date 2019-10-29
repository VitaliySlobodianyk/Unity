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
    int hp, mhp = 100, xp;

    public int Hp { get { return hp; } set { this.hp = value; } }
    public int MHp { get { return mhp; } }
    Animator animator;
    public bool godMode = false;

    Rigidbody2D rb;
    void Start()
    {
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

}
