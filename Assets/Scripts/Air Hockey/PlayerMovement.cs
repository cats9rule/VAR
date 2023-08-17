using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2;
    
    Rigidbody rb;
    private Vector3 movement;
    public Transform TopLimit;
    public Transform BottomLimit;
    public Transform SideLimit;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = new Vector3(z,0,-x);
        movement = Vector3.ClampMagnitude(movement, 1);*/
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -SideLimit.position.x, SideLimit.position.x),
            transform.position.y,
            Mathf.Clamp(transform.position.z, BottomLimit.position.z, TopLimit.position.z));
        //transform.Translate(movement*speed*Time.deltaTime);
    }

    private void FixedUpdate()
    {
        /*Vector3 clampedPosistion = new Vector3(Mathf.Clamp(rb.position.x + (movement.x * speed * Time.deltaTime),-SideLimit.position.x,SideLimit.position.x),
                rb.position.y,
                Mathf.Clamp(rb.position.z + (movement.z * speed * Time.deltaTime),BottomLimit.position.z,TopLimit.position.z))
                ;
        rb.MovePosition(clampedPosistion);*/
        //rb.MovePosition(rb.position + (movement*speed*Time.deltaTime));
    }
}
