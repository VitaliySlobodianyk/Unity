using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformAttacker : MonoBehaviour
{

   
    public float attackingDistance = 3f;
    [SerializeField] float distance = 2f;
    [SerializeField] Transform groundDetection;
    [SerializeField] float speed = 1f;

    Vector2 startPosition;
    private Transform player;
    Animator animator;
    EnemyState state;
    bool faceRight = false;
    bool isOnPatrol = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        Idle();
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        state = GetComponent<EnemyState>();
    }



    void FixedUpdate()
    { if (state.GetHp > 0){
            if (Vector2.Distance(transform.position, player.position) > attackingDistance)
            {

                if (isOnPatrol)
                {
                    Invoke("Patrol", 3f);
                }
                else
                {
                    Invoke("Idle", 1f);
                }
            }
            else
            {
                animator.SetBool("Patrol", true);
                transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime);
                if (player.position.x < transform.position.x && !faceRight)
                {
                    Flip();
                }
                else if (player.position.x > transform.position.x && faceRight)
                {
                    Flip();
                }

            }
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
}
