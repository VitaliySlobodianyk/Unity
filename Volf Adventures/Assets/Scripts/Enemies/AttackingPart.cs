using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingPart : MonoBehaviour
{
    public StickAttack stick;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Player")
        {
            PlayerState player = collision.GetComponent<PlayerState>();
            player.TakeDamage(stick.damage);
        }
    }
}
