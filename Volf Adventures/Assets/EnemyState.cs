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
    public bool IsDead { get { return curHp <= 0; } }
    Animator animator;
    
   

    void Start()
    {
        animator = GetComponent<Animator>();
        curHp = maxHp;
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
        animator.SetBool("Dead", true);
        Invoke("DeathEffect", 1f);
        Destroy(gameObject,1f);      
    }
    private void DeathEffect() {
        if (dead != null) {
            Instantiate(dead, transform.position, transform.rotation);
        }
        if (deathEffect!=null) {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        if (meat != null) {
            GameObject meatReady = Instantiate(meat, transform.position, Quaternion.identity);
        }
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
