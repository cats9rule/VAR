using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private Vector3 targetCenter;
    private float targetRadius;

    void Start()
    {
        Debug.Log("Started script");
        targetCenter = transform.position;
        targetCenter.z = 0;
        targetRadius = transform.localScale.x / 2;
    }

    private void OnCollisionEnter(Collision other)
    {
        Vector3 contactPoint = other.GetContact(0).point;
        Debug.Log($"Target hit at point ({contactPoint.x}, {contactPoint.y}, {contactPoint.z})");
        contactPoint.z = 0;
        Debug.Log(Vector3.Distance(contactPoint, targetCenter));

        decimal points = Math.Floor(Convert.ToDecimal(Vector3.Distance(contactPoint, targetCenter) / targetRadius * 5 - 5) * -1 + 1);
        points = points < 6 ? points : 5;
        
        Debug.Log($"Points: {points}");

    }
}
