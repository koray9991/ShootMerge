using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public static Gun Instance;
   
    private bool Go;
    public Transform bulletSpawnPoint;
    public GameObject bullet;
     float bulletTimer;
    public float fireRate;
    public ParticleSystem muzzlePs;
    public int gunLevel;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    

   
    void Update()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer > fireRate)
        {
            Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            bulletTimer = 0;
            muzzlePs.Play();
        }
        
           
           
       
    }
   
}