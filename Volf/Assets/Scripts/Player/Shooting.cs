using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int initialBulletsCount = 3;
    public int bulletsCount {  get;  private set; }
    
    [SerializeField] Transform muzzle;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shootEffect;

    private GameManager manager;
    private void Start()
    {
        bulletsCount = initialBulletsCount;
        manager=FindObjectOfType<GameManager>();
        manager.ChangeRoundsCount(bulletsCount);
    }
    public void Shoot() {
        if (bulletsCount > 0)
        {
            Instantiate(shootEffect, new Vector3(muzzle.position.x, muzzle.position.y), muzzle.rotation);
            Instantiate(bullet, new Vector3(muzzle.position.x, muzzle.position.y), muzzle.rotation);
            bulletsCount--;
            manager.ChangeRoundsCount(bulletsCount);
        }
        else {
           // click sound
        }     
    }
    public void addRounds(int amount) {
        bulletsCount += amount;
        manager.ChangeRoundsCount(bulletsCount);
    }
}
