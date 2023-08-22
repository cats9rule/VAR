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
    public Transform LeftLimit;
    public Transform RightLimit;

    private bool isFirstTimeInOppontentsHalf = true;
    
    private float top, bottom, left, right;

    private float offsetXFromTarget;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startingPosition = rb.position;
        if (LeftLimit.position.x < RightLimit.position.x)
        {
            left = LeftLimit.position.x;
            right = RightLimit.position.x;
        }
        else
        {
            left = RightLimit.position.x;
            right = LeftLimit.position.x;
        }
        if (BottomLimit.position.z < TopLimit.position.z)
        {
            top = TopLimit.position.z;
            bottom = BottomLimit.position.z;
        }
        else
        {
            top = BottomLimit.position.z;
            bottom = TopLimit.position.z;
        }
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
            Debug.Log("puck"+puckRb.position.z);
            Debug.Log("bottom limit"+bottom);
            
            if (puckRb.position.z < bottom)
            {
                if (isFirstTimeInOppontentsHalf)
                {
                    isFirstTimeInOppontentsHalf = false;
                    offsetXFromTarget = Random.Range(-0.275f, 0.275f);
                }
                movementSpeed = maxSpeed * UnityEngine.Random.Range(0.1f, 0.3f);
                targetPosition = new Vector3(Mathf.Clamp(puckRb.position.x + offsetXFromTarget,left,right),
                        rb.position.y,
                        startingPosition.z)
                    ;
            }
            else
            {
                isFirstTimeInOppontentsHalf = true;
                movementSpeed = UnityEngine.Random.Range(maxSpeed*0.4f,maxSpeed);
                targetPosition = new Vector3(Mathf.Clamp(puckRb.position.x,left,right),
                        rb.position.y,
                        Mathf.Clamp(puckRb.position.z ,bottom,top))
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
