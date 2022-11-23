using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform[] points;
    public int choosedPoint;
    bool firstWalk;
    public Transform firstWalkPoint;
    public float firstMoveSpeed;
    public bool roaming;
    public bool spawnArmies;
    public GameObject Boss;
    public GameObject army;
    float armyTimer;
    void Start()
    {
        firstWalk = true;
        //armyTimer = 25;
    }

    
    void Update()
    {
        
        if (firstWalk)
        {
            transform.position = Vector3.MoveTowards(transform.position, firstWalkPoint.position, firstMoveSpeed);
        }
        if (Vector3.Distance(transform.position, firstWalkPoint.position) < 0.2f && firstWalk)
        {
            firstWalk = false;
            roaming = true;

        }
        if (roaming)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[choosedPoint].position, firstMoveSpeed);
            if (Vector3.Distance(transform.position, points[choosedPoint].position) < 0.2f)
            {
                choosedPoint = Random.Range(0, points.Length);
            }
        }
        //if (Boss.GetComponent<Enemy>().health < Boss.GetComponent<Enemy>().maxHealth / 2 )
        //{
            if (armyTimer > 10)
            {
                armyTimer = 0;
                Instantiate(army, new Vector3(0, 0, transform.position.z - 2), Quaternion.identity);
                Instantiate(army, new Vector3(-1, 0, transform.position.z - 2), Quaternion.identity);
                Instantiate(army, new Vector3(-2, 0, transform.position.z - 2), Quaternion.identity);
                Instantiate(army, new Vector3(2, 0, transform.position.z - 2), Quaternion.identity);
                Instantiate(army, new Vector3(1, 0, transform.position.z - 2), Quaternion.identity);
            }
            armyTimer += Time.deltaTime;
        //}
        if (Boss.transform.childCount == 0)
        {
            GameManager.instance.winBool = true;
            
        }
    }
}
