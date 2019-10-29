using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.tag == "Player")
        {
            PlayerState player = collision.GetComponent<PlayerState>();
            player.Death();
            
        }
        else {
            Destroy(collision.gameObject);
        }
    }
}
