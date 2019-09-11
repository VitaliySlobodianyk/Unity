using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoove4 : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] float fieldWidth;
    private Vector3 _destinyPos;
   
    private float _distanceTolerance = 0.1f;
    

    private void Start()
    {
        rigidbody2D= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

         if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _destinyPos = transform.position - new Vector3(fieldWidth, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _destinyPos = transform.position + new Vector3(fieldWidth, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_destinyPos.x - transform.position.x) > _distanceTolerance)
        {
            if (_destinyPos.x < transform.position.x) rigidbody2D.velocity = -transform.right * speed;
            else rigidbody2D.velocity = transform.right * speed;
        }
        else rigidbody2D.velocity = Vector2.zero;
    }
}
