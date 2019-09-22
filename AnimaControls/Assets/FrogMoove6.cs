using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoove6 : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] float speed; // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
 
    float direction;
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        Debug.Log(direction);
        if (direction != 0) { 
           controller.transform.position+= Vector3.right *direction* speed * Time.deltaTime;
        }
    }
}
