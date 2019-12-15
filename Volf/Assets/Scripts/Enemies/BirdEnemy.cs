using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BirdEnemy : MonoBehaviour
{
    public float speed = 4f;
    public Transform target;
    public Transform spot;
    public float nextWaypointDistance=1.3f;
    public float  attackingDistance= 8f;
    Path path;
    int currentWaypoint;
    bool reached;
    bool attacking;

    Seeker seeker;
    Rigidbody2D rb;
    EnemyState state;
    bool faceRight = true;
    
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        state = GetComponent<EnemyState>();
        reached = false;
        InvokeRepeating("UpdatePath", 1f, 0.1f);      
    }

    void UpdatePath() {
        if (attacking)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        }
        else {
            seeker.StartPath(rb.position, spot.position, OnPathComplete);
        }
       
    }

    void OnPathComplete(Path p) {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
        else {
            Debug.LogError(p.error);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
          Moove();
          Rotator();
        if (state.IsDead) {
            rb.gravityScale = 10;
          }
        if (Vector2.Distance(rb.position, target.position) < attackingDistance) {
            attacking = true;
        }
        else{
            attacking = false;
        }
      
    }

    void Moove() {
        if (path == null) {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reached = true;
            return;
        }
        else {
            reached = false;
        }

        Vector2 dir = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;
       
        Vector2 force = speed * dir * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance <= nextWaypointDistance) {
            currentWaypoint++;
        }     
      
    }

    public void Rotator() {
        if (rb.velocity.x < -0.1f && faceRight) {
            transform.Rotate(new Vector3(0, 180, 0));
            faceRight = false;
        } else if (rb.velocity.x > 0.1f && !faceRight) {
            transform.Rotate(new Vector3(0, 180, 0));
            faceRight = true;
        }    
    }
   

}
