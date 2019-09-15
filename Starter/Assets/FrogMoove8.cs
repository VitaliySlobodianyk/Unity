using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoove8 : MonoBehaviour
{

    Vector2 position;

    [SerializeField] float speed;


    private Rigidbody2D rb;
    private float direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction != 0)
        {
            rb.AddForce(Vector3.right * direction * speed  , ForceMode2D.Force);
            //rb.position += Vector2.right * direction * speed * Time.deltaTime;
            //rb.MovePosition(rb.position + Vector2.right * direction * speed * Time.deltaTime);
           //  rb.AddRelativeForce(, ForceMode2D.Force);
        }

    }
}
