using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunParallax : MonoBehaviour
{
    public GameObject player;
    public float xOffset=0;
    public float yOffset=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player!=null)
         transform.position = new Vector2(player.transform.position.x + xOffset, player.transform.position.y + yOffset) ;
    }
}
