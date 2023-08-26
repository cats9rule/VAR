using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody rb;
    public Transform resetPositionPlayer, resetPositionAI, positionPlayer, positionAI, tableCenter;
    
    public Transform TopLimit;
    public Transform SideLimit;
    public float MaxSpeed;

    public AudioManager audioManager;
    
    private float playerRadius;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        WasGoal = false;
        playerRadius = 0.1f* (transform.lossyScale.z/transform.localScale.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!WasGoal)
        {
            if (other.name == "AIGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.AiScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(resetPositionPlayer.position));
            }
            else if (other.name == "PlayerGoal")
            {
                ScoreScriptInstance.Increment(ScoreScript.Score.PlayerScore);
                WasGoal = true;
                audioManager.PlayGoal();
                StartCoroutine(ResetPuck(resetPositionAI.position));
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        audioManager.PlayPuckCollsion();
    }

    private IEnumerator ResetPuck(Vector3 resetPosition)
    {
        yield return new WaitForSecondsRealtime(1);
        WasGoal = false;
        rb.velocity = new Vector3();
        rb.position = resetPosition;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
        
        if(Mathf.Abs(transform.localPosition.x)>SideLimit.localPosition.x)
            StartCoroutine(ResetPuck(resetPositionPlayer.position));
        if(Math.Abs(transform.localPosition.z)>TopLimit.localPosition.z)
            StartCoroutine(ResetPuck(resetPositionPlayer.position));
        CheckStuckPuck();
    }
    public void ResetPuckToPlayer()
    {
        WasGoal = false;
        rb.velocity = new Vector3();
        rb.position = resetPositionPlayer.position;
    }
    private void CheckStuckPuck()
    {
        Vector3 puck = new Vector3(rb.position.x, 0, rb.position.z);
        Vector3 player1 = new Vector3(positionPlayer.position.x, 0, positionPlayer.position.z);
        Vector3 player2 = new Vector3(positionAI.position.x, 0, positionAI.position.z);

        float distanceP1 = Vector3.Distance(puck, player1);
        float distanceP2 = Vector3.Distance(puck, player2);

        if (distanceP1 <= playerRadius
            || distanceP2 <= playerRadius)
        {
            MoveStuckPuck(transform, tableCenter);
        }
    }

    private void MoveStuckPuck(Transform puck, Transform table)
    {
        Vector3 target = new Vector3(puck.position.x, puck.position.y, puck.position.z);
        float d = playerRadius;
        
        if (puck.position.x > table.position.x) target.x -= d;
        else target.x += d;
        
        if (puck.position.z > table.position.z) target.z -= d;
        else target.z += d;

        rb.position = target;
    }
}
