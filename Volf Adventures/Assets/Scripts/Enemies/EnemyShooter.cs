using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
  [SerializeField] GameObject stone;
  [SerializeField] Transform muzzle;
    public float shootingTime=.5f;

    public float attackingDistance = 5f;
    public float retreatingDistance = 3f;
    [SerializeField] float distance = 2f;
    [SerializeField] Transform groundDetection;
    [SerializeField] float speed = 1f;

    Vector2 startPosition;
    private Transform player;
    private float timeToShoot;
    Animator animator;
    bool faceRight = false;
    bool isOnPatrol = false;
    bool retreat= false;
    EnemyState state;
    void Start()
    {
        animator = GetComponent<Animator>();
        Idle();
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeToShoot = 0f;
        state = GetComponent<EnemyState>();
    }

    void FixedUpdate()
    {
        if (state.GetHp>0)
        {
            if (Vector2.Distance(transform.position, player.position) > attackingDistance){
            retreat = false;
            if (isOnPatrol)
            {
                Invoke("Patrol", 3f);
            }
            else
            {
                Invoke("Idle", 1f);
            }
           } else{
           
                if (Vector2.Distance(transform.position, player.position) > retreatingDistance && !retreat)
                {
                    animator.SetBool("Patrol", true);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                    if (player.position.x < transform.position.x && !faceRight)
                    {
                        Flip();
                    }
                    else if (player.position.x > transform.position.x && faceRight)
                    {
                        Flip();
                    }
                    Shoot();
                }
                else if (Vector2.Distance(transform.position, player.position) < retreatingDistance || retreat)
                {
                    retreat = true;
                    animator.SetBool("Patrol", true);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                    if (player.position.x < transform.position.x && faceRight)
                    {
                        Flip();
                    }
                    else if (player.position.x > transform.position.x && !faceRight)
                    {
                        Flip();
                    }

                }   
            }
            timeToShoot -= Time.deltaTime;
        }
    }
    void Idle()
    {
        isOnPatrol = true;
        animator.SetBool("Patrol", false);
    }
    void Patrol()
    {
        isOnPatrol = false;
        animator.SetBool("Patrol", true);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundCheck = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        if (!groundCheck.collider)
        {
            Flip();
        }
    }
    
    void Flip()
    {
        faceRight = !faceRight;
        transform.Rotate(0, 180, 0);
    }
    void Shoot() {
        if (timeToShoot <= 0)
        {
            animator.SetBool("Attack", true);
            Instantiate(stone, muzzle.position, muzzle.rotation);
            timeToShoot = shootingTime;
            animator.SetBool("Attack", false);
        }
    }
}


