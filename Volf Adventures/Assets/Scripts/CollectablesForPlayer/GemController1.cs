using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;


public class GemController1 : MonoBehaviour
{
 

    [SerializeField] GameObject pickEffect;


    public float speed = 0.1f;
    public float slidingDistnce = 0.2f;
    private Vector2 startPosition;
  
 
    private void Start()
    {
        startPosition = transform.position;   
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(startPosition, transform.position) > slidingDistnce)
            speed = -speed;

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            FindObjectOfType<GameManager>().ChangeGemsCount();
            Instantiate(pickEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
