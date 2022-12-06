using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
    private void Start()
    {
        transform.DOPunchScale(new Vector3(10, 10, 10), 0.5f, 10, 1);
    }


    void Update()
    {
        bulletTimer += Time.deltaTime;
        if(bulletTimer>(fireRate-0.2f) && bulletTimer < fireRate)
        {
            transform.localScale = new Vector3(30, 30, 30);
            
        }
        if (bulletTimer > fireRate)
        {
            Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            bulletTimer = 0;
            muzzlePs.Play();
            transform.DOPunchScale(new Vector3(5, 5, 5), 0.3f, 8, 1);
        }
        
           
           
       
    }
   
}