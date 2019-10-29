using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAttack : MonoBehaviour
{
    public int damage = 10;
    public float attackDistance = 3f;
    public GameObject attackCollider;
    Animator parentAnimator;

    float attacked = 0;
    float timeBtwAttacks = 1f;
    private Transform player;
    void Start()
    {
        parentAnimator = GetComponentInParent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackCollider.gameObject.SetActive(false);
    }
    public  void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) < attackDistance && attacked <= 0)
        {
            ShowAttack();
            Invoke("HideAttack", 0.1f);
            attacked = timeBtwAttacks;
        }
        else {
            attacked -= Time.deltaTime;
        }   
    }

   public void MakeAxeActive() {
        attackCollider.gameObject.SetActive(true);
        Invoke("DisableAxe", 0.2f);
    }
    public void DisableAxe() {
        attackCollider.gameObject.SetActive(false);
    }
      
    private void ShowAttack() {
        parentAnimator.SetBool("Attack", true);     
    }
    private void HideAttack() {
        parentAnimator.SetBool("Attack", false);
    }
}
