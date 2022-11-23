using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Translate : MonoBehaviour
{
    public float moveSpeedX, moveSpeedY, moveSpeedZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(moveSpeedX, moveSpeedY, moveSpeedZ));
    }
}
