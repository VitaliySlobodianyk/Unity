using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootEffect;

    public void Shoot() {
        Instantiate(shootEffect,new Vector3(muzzle.position.x, muzzle.position.y ), muzzle.rotation);
        Instantiate(bullet, new Vector3(muzzle.position.x, muzzle.position.y ), muzzle.rotation);
    }
}
