using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{ public Camera camera;
    public NavMeshAgent agent; 
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
           Vector3 destination = camera.ScreenToWorldPoint(Input.mousePosition);


            agent.SetDestination(destination);
        
        }
    }
}
