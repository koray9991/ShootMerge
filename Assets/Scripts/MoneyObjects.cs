using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyObjects : MonoBehaviour
{
    public Rigidbody rb;
    public float xForce, yForce;
    public float timer;
    public GameObject slot3;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(xForce, yForce, 0);
        slot3 = GameObject.FindGameObjectWithTag("Slot3");
        Destroy(gameObject, 2);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.3f)
        {
            rb.isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position, slot3.transform.position, 0.7f);
        }
    }

}
