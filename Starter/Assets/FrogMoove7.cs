using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogMoove7 : MonoBehaviour
{
    // Start is called before the first frame update


    Vector2 position;

    [SerializeField] float speed;
   

    private Rigidbody2D rb;
    private float direction;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction!=0)
        {
            rb.transform.position += Vector3.right * direction * speed * Time.deltaTime;
        }
       
    }
}
