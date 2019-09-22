using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopController : MonoBehaviour
{
    [SerializeField] CharacterController2D movement;
    float move;
    bool jump;
    bool crouch = false;
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonDown("Jump");


        if (Input.GetKeyDown("c")) {
            crouch = !crouch;
        }
        
    }
    private void FixedUpdate()
    {
        Debug.Log(crouch);
        movement.Move(move ,crouch, jump);
    }
}
