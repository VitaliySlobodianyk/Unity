using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
    void Update () 
	{
		transform.Rotate (new Vector3 (0f, 0f, 3f));
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerState player = collision.GetComponent<PlayerState>();
            player.Death();

        }
    }

}
