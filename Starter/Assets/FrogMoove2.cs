using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoove2 : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] float speed;
    Vector3 horizontalMove;
    // Start is called before the first frame update
    private void Start()
    {
        controller = new CharacterController();
        horizontalMove = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove.x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove);
    }
}
