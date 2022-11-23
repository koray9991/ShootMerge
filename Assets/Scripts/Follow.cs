using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform followedObject;
    public float x, y, z;
    private void Update()
    {
        if (followedObject != null)
        {
            transform.position = new Vector3(followedObject.position.x + x, followedObject.position.y + y, followedObject.position.z + z);
        }
       
    }
}
