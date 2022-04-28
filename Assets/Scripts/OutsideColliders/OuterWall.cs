using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Ball aBall = collision.gameObject.GetComponent<Ball>();
        if (aBall != null)
        {
            // destroy ball
        }
        
        
    }
}
