using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class frog : MonoBehaviour
{
    // Start is called before the first frame update


    Vector2 position;
  
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] Rigidbody2D rb;

    float direction;
    float verticalDirection;
    float previousDirection=0;

    void Flip(float currentDirection)
    {
        if (currentDirection < 0 && currentDirection!=previousDirection)
        {
             transform.Rotate(0, 180, 0);
            previousDirection = currentDirection;
        }
        else if (currentDirection > 0 && currentDirection != previousDirection)
        {
            transform.Rotate(0, -180, 0);
            previousDirection = currentDirection;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        direction =Input.GetAxisRaw("Horizontal");
        verticalDirection = Input.GetAxisRaw("Vertical");
        Flip(direction);
     
        if (direction != 0) {
        rb.velocity = Vector2.right *  direction * speed * Time.deltaTime;
        }
        Debug.Log(rb.position.y * jumpHeight);
        Debug.Log(Mathf.Sqrt(jumpHeight));
        if (verticalDirection == 1 && rb.position.y < Mathf.Sqrt(jumpHeight)) {
            
            rb.velocity = Vector2.up * jumpHeight * Time.deltaTime;
            
        }
       
      

    }
}
