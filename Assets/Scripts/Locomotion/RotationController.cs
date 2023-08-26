using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class RotationController : MonoBehaviour
{

    public ActionBasedControllerManager manager;

    public void SetTypeFromIndex(int index)
    {
        if (index == 0)
        {
            manager.smoothTurnEnabled = true;
        }
        else if(index==1)
        {
            manager.smoothTurnEnabled = false;
        }
        
    }
}
