using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControllerVertical : MonoBehaviour
{
    // Start is called before the first frame update
 
    public float slidingDistance = 15f;
    private Vector2 startPosition;
    public float speed = 1f;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (Vector2.Distance(startPosition, transform.position) > slidingDistance && transform.position.y < startPosition.y)
        {
            Platformcontroller.makeVelocity( ref speed, "+");
        }
        else if(Vector2.Distance(startPosition, transform.position) > slidingDistance && transform.position.y > startPosition.y) {
            Platformcontroller.makeVelocity(ref speed, "-");
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
      

    } 
}
