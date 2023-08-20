using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    private Vector3 targetCenter;
    private float targetRadius;
    private int totalPoints;

    public TMP_Text scoreDisplay;

    void Start()
    {
        targetCenter = transform.position;
        targetCenter.z = 0;
        targetRadius = transform.localScale.x / 2;
        totalPoints = 0;
        scoreDisplay.text = $"Score: {totalPoints}";
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;

        Vector3 contactPoint = other.GetContact(0).point;
        contactPoint.z = 0;
        decimal points = Math.Floor(Convert.ToDecimal(Vector3.Distance(contactPoint, targetCenter) / targetRadius * 5 - 5) * -1 + 1);
        points = points < 6 ? points : 5;
        
        Debug.Log($"Points: {points}");

        totalPoints += Convert.ToInt32(points);

        scoreDisplay.text = $"Score: {totalPoints}";
    }
}
