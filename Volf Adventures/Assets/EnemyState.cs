using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{

    public float maxHp=40f;
    public GameObject dead;
    public GameObject deathEffect;
    public GameObject meat;
    private float curHp;
    public float GetHp { get { return curHp; } }

    Animator animator;
    
   

    void Start()
    {
        animator = GetComponent<Animator>();
        curHp = maxHp;
        FindObjectOfType<SoundManager>().Play("EnemyWalk");
    }

    public void TakeDamage(float amount) {
        FindObjectOfType<SoundManager>().Play("EnemyHit");
        curHp -= amount;
        if (curHp <= 0)
        {
            Death();
        }
        else {         
            animator.SetBool("Damaged", true);
            Invoke("Damaged", 1f);
        }
    }
    public void Death() {
        FindObjectOfType<SoundManager>().Stop("EnemyWalk");
        animator.SetBool("Dead", true);
        Invoke("DeathEffect", 1f);
        Destroy(gameObject,1f);
        
    }
    private void DeathEffect() {
        Instantiate(dead, transform.position, transform.rotation);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        GameObject meatReady = Instantiate(meat, transform.position, Quaternion.identity);
    }
   
    public void Damaged() {
        animator.SetBool("Damaged", false);
    }
    public void Attack()
    {
        StickAttack attack = gameObject.GetComponentInChildren<StickAttack>();
        attack.MakeAxeActive();
    }


}
