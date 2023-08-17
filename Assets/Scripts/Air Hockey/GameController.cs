using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public  PuckScript PuckScript;
    public PlayerMovement PlayerMovement;
    public AIMovement AIMovement;
    public ScoreScript ScoreScript;


    public void ResetGame()
    {
        ScoreScript.ResetScore();
        PuckScript.ResetPuckToPlayer();
        AIMovement.ResetPosition();
    }

    public void ResetPuck()
    {
        //AIMovement.ResetPosition();
        PuckScript.ResetPuckToPlayer();
    }
    
}
