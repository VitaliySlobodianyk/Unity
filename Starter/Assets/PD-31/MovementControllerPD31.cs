using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerPD31 : MonoBehaviour
{
    [SerializeField]MovementPD31 movement;
    float move;
    bool jump;
    bool crouch;
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        jump = Input.GetButtonUp("Jump");
        crouch = Input.GetKey("c");
    }
    private void FixedUpdate()
    {
        movement.Move(move, jump, crouch);
    }
}
