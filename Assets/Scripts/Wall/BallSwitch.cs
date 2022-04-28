using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSwitch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball ballGO = other.gameObject.GetComponent<Ball>();

        if (ballGO != null)
        {

        }
    }

    private void SwitchLayer(Ball aBall)
    {
        if (aBall.ballLayer == 9)
        {
            aBall.ballLayer = 10;
        }

        else if (aBall.ballLayer == 10)
        {
            aBall.ballLayer = 9;
        }
        /*if (aBall.IsArmed = false)
         * {
         *  
         * }
         *
         */
    }
}
