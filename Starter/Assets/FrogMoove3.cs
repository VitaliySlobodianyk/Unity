using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoove3 : MonoBehaviour
{
    [SerializeField] float speed;
    float direction;
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");               
        transform.position+= (Vector3.right* direction *speed * Time.deltaTime);       
    }
}
