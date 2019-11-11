using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeethAttack : MonoBehaviour
{
   [HideInInspector]
   public GameObject mouth;

    public void Start()
    {
        mouth.SetActive(false);   
    }
  
   async public void makeKus() {
        mouth.SetActive(true);
        Invoke("disableCus", 0.5f);
    }
  
    async void disableCus() {
        mouth.SetActive(false);
    }  
}
