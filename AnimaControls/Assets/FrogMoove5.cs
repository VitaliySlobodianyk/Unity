using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMoove5 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    float direction;
    void Update()
    {
        direction = Input.GetAxisRaw("Horizontal");

        Debug.Log(direction);
        if (direction > 0)
        {
             transform.Translate(Vector3.right * speed * Time.deltaTime,Space.Self);
        }
        else if (direction < 0) {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        }
    }

}

