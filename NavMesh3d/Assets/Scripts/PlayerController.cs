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
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit pointToMoove;
            
          if(Physics.Raycast(ray,out pointToMoove)){
                agent.SetDestination(pointToMoove.point);
            }
        }
    }
}
