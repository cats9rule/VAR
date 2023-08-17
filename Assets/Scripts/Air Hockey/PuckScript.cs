using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{
    public ScoreScript ScoreScriptInstance;
    public static bool WasGoal { get; private set; }
    private Rigidbody rb;
    public Transform resetPositionPlayer, resetPositionAI;
    
    public Transform TopLimit;
    public Transform SideLimit;
    public float MaxSpeed;

    public AudioManager audioManager;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        WasGoal = false;
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
        if(Mathf.Abs(rb.position.x)>SideLimit.position.x)
            StartCoroutine(ResetPuck(resetPositionPlayer.position));
        if(Math.Abs(rb.position.z)>TopLimit.position.z)
            StartCoroutine(ResetPuck(resetPositionPlayer.position));
    }
    public void ResetPuckToPlayer()
    {
        WasGoal = false;
        rb.velocity = new Vector3();
        rb.position = resetPositionPlayer.position;
    }
}
