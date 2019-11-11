using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject hit;
    [SerializeField] GameObject bloodyHit;
    [SerializeField] float damage = 50f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right *speed, ForceMode2D.Impulse);
        Destroy(gameObject,4f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player") {
         
            if (collision.tag == "Enemy")
            {
                Instantiate(bloodyHit, transform.position, transform.rotation);
                EnemyState enemy = collision.GetComponent<EnemyState>();
                enemy.TakeDamage(damage);
            }
            else {
                Instantiate(hit, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }


}
