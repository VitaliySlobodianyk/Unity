using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class frog : MonoBehaviour
{
    // Start is called before the first frame update


    Vector2 position;

    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] private LayerMask layerMask;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    float direction;
    bool jump;
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
        boxCollider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
       
        jump = Input.GetKeyDown(KeyCode.Space);
        Flip(direction);
        if ( jump  && isGrounded() ) {                      
                rb.velocity= Vector2.up * jumpHeight;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            rb.velocity = Vector2.right * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            rb.velocity = Vector2.right * (-speed) * Time.deltaTime;
        }
    }
    public void Moove(Vector2 moove) {

    }

    private bool isGrounded()
    {
       RaycastHit2D raycast =  Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,0f,Vector2.down* 0.1f, layerMask);
        return raycast.collider != null;
    }
}
