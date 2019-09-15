using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To run this script you  have  to  remove  RigidBody component from  your  
//Character and  apply  Charater Controller component
public class FrogMoove2 : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] float speed;
    Vector3 horizontalMove;
    // Start is called before the first frame update
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(Vector3.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime);
    }

}
