using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]Movement movement;
    [SerializeField]Shooting shooting;
    [SerializeField]TeethAttack kus;
  
    float move;
    bool jump;
   public bool crouch=false;
    bool canJump = true;
    void Update()
    {
        if (!MenuManager.onPause) {
            move = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonUp("Jump") && canJump)
            {
                jump = true;
                canJump = false;
                Invoke("JumpOn", 0.1f);
            }
            else {
                jump = false;
            }


            if (Input.GetKeyUp(KeyCode.C)) {
                crouch = !crouch;
            }
            if (Input.GetButtonUp("Fire1") && !crouch)
            {
                shooting.Shoot();
            }
            if (Input.GetButtonUp("Fire1") && crouch)
            {
                movement.Kus();
                FindObjectOfType<SoundManager>().Play("PlayerKus");
                kus.makeKus();
            } 
        }
    }
    private void FixedUpdate()
    {
        if (!MenuManager.onPause) {
            movement.Move(move, jump, crouch);      
        }
    }
    private void JumpOn() {
        canJump = true;
    }
}
