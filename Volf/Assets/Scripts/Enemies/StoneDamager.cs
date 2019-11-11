using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDamager : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Rigidbody2D rb;
    [SerializeField] int damage = 50;
    private bool damaged = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
        Destroy(gameObject, 4f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObj = collision.gameObject;
        if (collisionObj.tag=="Player" && !damaged) {           
            PlayerState player = collisionObj.GetComponent<PlayerState>();
            player.TakeDamage(damage);
        }
        if (collisionObj.tag != "Enemy") {
            damaged = true;
        }
       
    }
}
