using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{


  [Range(1,2)] [SerializeField] public float powerUpEffect=1.5f;
    [SerializeField] GameObject pickEffect;

    float speed = 0.1f;
    public float slidingDistnce = 0.2f;
    private Vector2 startPosition;
 
    private void Start()
    {
        
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(startPosition, transform.position) > slidingDistnce)
            speed = -speed;
        transform.Translate(Vector2.up * speed * Time.deltaTime);    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Movement player = collision.GetComponent<Movement>();
            PlayerState state = collision.GetComponent<PlayerState>();
            MovementController controller = collision.GetComponent<MovementController>();
            controller.crouch = true;
            player.PowerUpSpeed(powerUpEffect);
            Instantiate(pickEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}


