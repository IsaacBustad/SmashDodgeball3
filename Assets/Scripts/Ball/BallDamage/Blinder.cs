using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinder : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        PlayerBlind pB = collision.transform.gameObject.GetComponent<PlayerBlind>();

        if (pB != null)
        {
            pB.BlindMe();
        }
    }
}
