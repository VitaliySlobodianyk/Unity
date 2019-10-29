using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public SoundManager soundManager;

    [SerializeField] float speed;
    [SerializeField] float smoothmentRait;
    Vector2 targetVelocity;
    Vector2 currentVelosity;
    bool faceRight = true;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] GameObject groundCheck;
    [SerializeField] float groundRadius;
    [SerializeField] float jumpForce;
    [Range(1, 2)] [SerializeField] float doubleJumpEnforcement = 1.5f;
    public int initialJumpCount = 2;
    [SerializeField] bool airControl;
   
    int jumpCount;
    bool onAir = false;

    [SerializeField] BoxCollider2D headColl;
    [SerializeField] GameObject cellingCheck;
    [Range(0, 2)] [SerializeField] float crouchMod;
    [SerializeField] float cellRadius;
    PlayerState state;
    Transform playerTransform;
    MovementController controller;

    float walkPlay;
    const float toWalkPlay = 1f; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = GetComponent<PlayerState>();
        playerTransform = GetComponent<Transform>();
        jumpCount = initialJumpCount;
        controller = GetComponent<MovementController>();
        walkPlay = 0f;
    }

    void SetJumpCount() {
        if (Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround) && !onAir)
        {
            jumpCount = initialJumpCount;
        }
        else if (onAir && Physics2D.OverlapCircle(groundCheck.transform.position, groundRadius, whatIsGround))
        {
            onAir = false;
        }
    }
    public void Move(float move, bool jump, bool crouch)
    {
        SetJumpCount();
      
        if (!state.isDead)
        {

            if (move != 0 && walkPlay <= 0)
            {
                soundManager.Play("PlayerWalk");
                walkPlay = toWalkPlay;
            }
            else if (move==0){
                soundManager.Stop("PlayerWalk");
                walkPlay = 0;
            }
            walkPlay -= Time.deltaTime;
            
            animator.SetBool("Crouch", crouch);
            animator.SetBool("Kus", false);
            if (!crouch)
            {
                crouch = Physics2D.OverlapCircle(cellingCheck.transform.position, cellRadius, whatIsGround);
            }

            

            if (jumpCount>0 || airControl)
            {
                if (crouch)
                {
                    headColl.enabled = false;
                    move *= crouchMod;
                }
                else
                {
                    headColl.enabled = true;
                }

                animator.SetFloat("Speed", Mathf.Abs(move));

                if (move < 0 && faceRight)
                    Flip();
                else if (move > 0 && !faceRight)
                    Flip();

                targetVelocity = new Vector2(move * speed * Time.fixedDeltaTime, rb.velocity.y);
                rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref currentVelosity, smoothmentRait);
                if (jump && jumpCount>0 )
                {            
                    rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                    animator.SetBool("StartJump", true);
                    soundManager.Play("Jump");
                    jumpCount-=2;
                    onAir = true;
                    Invoke("EndStartJump", 0.1f);
                }              
            }
            

            if (rb.velocity.y > 0.5)
            {
                animator.SetBool("JumpUp", true);
                animator.SetBool("JumpDown", false);
            }
            else if (rb.velocity.y < -0.5)
            {
                animator.SetBool("JumpDown", true);
                animator.SetBool("JumpUp", false);
            }else
            {
                animator.SetBool("JumpUp", false);
                animator.SetBool("JumpDown", false);
            }
        }
    }
    public void Kus() {
        animator.SetBool("Kus", true);
    }
    public void EndStartJump() {
        animator.SetBool("StartJump", false);
    }

    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform")) {
            playerTransform.parent = collision.gameObject.transform;
        }
    }
    public void PowerUpSpeed(float force) {
        speed *= force;
        jumpForce *= force;
        transform.localScale += new Vector3(1, 1, 0);
        state.godMode = true;
        StartCoroutine(DisableSpeedPowerUp(force, 10f));
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            playerTransform.parent = null;
        }
    }
   

    IEnumerator DisableSpeedPowerUp(float force, float delayTime)
    {      
        yield return new WaitForSeconds(delayTime);
        jumpForce /= force;
        speed /= force;
        controller.crouch = false;
        transform.localScale += new Vector3(-1, -1, 0);
        state.godMode = false;
    }


}
