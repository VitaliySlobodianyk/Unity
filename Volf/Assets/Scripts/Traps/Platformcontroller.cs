using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformcontroller : MonoBehaviour
{
    public float slidingDistance=15f;
    private Vector2 startPosition;
    public float speed = 1f;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        if (Vector2.Distance(startPosition, transform.position) > slidingDistance && transform.position.x < startPosition.x)
        {
            makeVelocity(ref speed, "+");
        }
        else if (Vector2.Distance(startPosition, transform.position) > slidingDistance && transform.position.x > startPosition.x)
        {
            makeVelocity(ref speed, "-");
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }

   public static void makeVelocity(ref float num, string sign)
    {
        if (sign == "-")
        {
            num = Mathf.Abs(num) * -1;
        }
        else
        {
            num = Mathf.Abs(num);
        }
    }
}
