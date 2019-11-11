using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerDumb : MonoBehaviour
{
    [SerializeField] float distance=2f;
    [SerializeField] Transform groundDetection;
    [SerializeField] float speed = 1f;

    Vector2 startPosition;
    Animator animator;
    private Transform player;

    bool faceRight = false;
    bool isOnPatrol = false;
    EnemyState state;
    void Start()
    {
        animator = GetComponent<Animator>();
        Idle();
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        state = GetComponent<EnemyState>();
    }
    


    void FixedUpdate()
    {
        if (isOnPatrol && state.GetHp>0)
        {
            Invoke("Patrol", 3f);
        }
        else {
            Invoke("Idle", 1f);
        }
     
    }

    void Idle() {
        isOnPatrol = true;
        animator.SetBool("Patrol", false);
    }
    void Patrol() {
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
