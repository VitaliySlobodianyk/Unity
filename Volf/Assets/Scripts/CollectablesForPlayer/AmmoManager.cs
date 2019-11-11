using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{

    [SerializeField] GameObject pickEffect;

    public int roundsToAdd= 2;
    public float speed = 0.1f;
    public float slidingDistnce = 0.2f;
    private Vector2 startPosition;
    private bool picked= false;

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
        if (collision.tag == "Player" && !picked)
        {
            picked = true;       
            Instantiate(pickEffect, transform.position, Quaternion.identity);
            collision.gameObject.GetComponent<Shooting>().addRounds(roundsToAdd);
            Destroy(gameObject);
        }
    }
}
