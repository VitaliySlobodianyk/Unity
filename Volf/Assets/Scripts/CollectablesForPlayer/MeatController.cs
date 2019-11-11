using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatController : MonoBehaviour
{
    public int points = 30;
    [SerializeField] GameObject pickEffect;

    float speed = 0.1f;
    public float slidingDistnce = 0.2f;
    private Vector2 startPosition;
   

    float rotateOffset = 0.1f;
    float currentTime;

    
    private void Start()
    {
        currentTime = rotateOffset;
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Vector2.Distance(startPosition, transform.position) > slidingDistnce)
            speed = -speed;
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (currentTime <= 0) {
            transform.Rotate(0, 0, 5);
            currentTime = rotateOffset;
        }

       currentTime -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            PlayerState player = collision.GetComponent<PlayerState>();
            player.Heal(points);
            Instantiate(pickEffect,transform.position, Quaternion.identity);
            Destroy(gameObject);
        } 
    }

}
