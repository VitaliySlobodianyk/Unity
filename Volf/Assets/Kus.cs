using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kus : MonoBehaviour
{
    public float damage=30f;
    public TeethAttack kus;
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == "Enemy" )
        {
            EnemyState enemy = collision.GetComponent<EnemyState>();
            enemy.TakeDamage(damage);
        }     
    }
}
