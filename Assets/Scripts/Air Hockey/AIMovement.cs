using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIMovement : MonoBehaviour
{

    public float maxSpeed;
    
    Rigidbody rb;

    private Vector3 startingPosition;

    public Rigidbody puckRb;
    
    public Transform TopLimit;
    public Transform BottomLimit;
    public Transform SideLimit;

    private bool isFirstTimeInOppontentsHalf = true;

    private float offsetXFromTarget;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!PuckScript.WasGoal)
        {
            float movementSpeed;
            Vector3 targetPosition;
            if (puckRb.position.z < BottomLimit.position.z)
            {
                if (isFirstTimeInOppontentsHalf)
                {
                    isFirstTimeInOppontentsHalf = false;
                    offsetXFromTarget = Random.Range(-0.275f, 0.275f);
                }
                movementSpeed = maxSpeed * UnityEngine.Random.Range(0.1f, 0.3f);
                targetPosition = new Vector3(Mathf.Clamp(puckRb.position.x + offsetXFromTarget,-SideLimit.position.x,SideLimit.position.x),
                        rb.position.y,
                        startingPosition.z)
                    ;
            }
            else
            {
                isFirstTimeInOppontentsHalf = true;
                movementSpeed = UnityEngine.Random.Range(maxSpeed*0.4f,maxSpeed);
                targetPosition = new Vector3(Mathf.Clamp(puckRb.position.x,-SideLimit.position.x,SideLimit.position.x),
                        rb.position.y,
                        Mathf.Clamp(puckRb.position.z ,BottomLimit.position.z,TopLimit.position.z))
                    ;
            }
            rb.MovePosition(Vector3.MoveTowards(rb.position,targetPosition,movementSpeed*Time.deltaTime));
        }
    }

    public void ResetPosition()
    {
        rb.position = startingPosition;
        rb.velocity = new Vector3();
    }
}
