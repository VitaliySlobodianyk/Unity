using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFollower : MonoBehaviour
{
    public GameObject target;
   
  
    void Update()
    {
        transform.position = target.transform.position;
    }
}
