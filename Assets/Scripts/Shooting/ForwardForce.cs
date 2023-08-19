using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardForce : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0, -20);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Destroy(gameObject);
    }
}
