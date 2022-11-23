using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed;
    public float damage;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,0, moveSpeed / 10));
    }
}
