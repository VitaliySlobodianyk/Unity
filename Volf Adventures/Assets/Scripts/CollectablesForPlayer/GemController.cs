using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    GemManagerPD31 gemController;
    [SerializeField] GameObject efect;
    private void Start()
    {
        gemController = GemManagerPD31.instance;
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            Instantiate(efect, transform.position, Quaternion.identity);
            gemController.ChangeGemAmount(1);
            Destroy(gameObject);
        }
          
    }

}
