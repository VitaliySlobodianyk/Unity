using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
public class MovementPD31 : MonoBehaviour
{
    //Animator animator;
    Rigidbody2D rb;

    [SerializeField] float speed;
    [SerializeField] float smoothmentRait;
    Vector2 targetVelocity;
    Vector2 currentVelosity;
    bool faceRight = true;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] GameObject groundCheck;
    [SerializeField] float groundRadius;
    [SerializeField] float jumpForce;
    [SerializeField] bool airControl;
    bool canJump;

    [SerializeField] BoxCollider2D headColl;
    [SerializeField] GameObject cellingCheck;
    [Range(0, 1)] [SerializeField] float crouchMod;
    [SerializeField] float cellRadius;
 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       // animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround);
    }

    public void Move(float move, bool jump, bool crouch)
    {
        if(!crouch)
        {
            crouch = Physics2D.OverlapCircle(cellingCheck.transform.position, cellRadius, whatIsGround);
        }
        if (canJump || airControl)
        {
            if (crouch)
            {
                headColl.enabled = false;
                move *= crouchMod;
            }
            else headColl.enabled = true;

            //animator.SetFloat("Speed", Mathf.Abs(move));

            if (move < 0 && faceRight)
                Flip();
            else if (move > 0 && !faceRight)
                Flip();
            targetVelocity = new Vector2(move * speed * Time.fixedDeltaTime, rb.velocity.y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelosity, smoothmentRait);

            if (jump && canJump)
            {
                rb.AddForce(Vector2.up * jumpForce);
            }

        }
        if(!canJump)
        {
            if (rb.velocity.y > 0.5)
            {
                //animator.SetBool("JumpUp", true);
               // animator.SetBool("JumpDown", false);
            }
            else if (rb.velocity.y < -0.5)
            {
               // animator.SetBool("JumpDown", true);
               // animator.SetBool("JumpUp", false);
            }
        }
        else
        {
           // animator.SetBool("JumpUp", false);
           // animator.SetBool("JumpDown", false);
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.transform.position, groundRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(cellingCheck.transform.position, cellRadius);
    }

}
