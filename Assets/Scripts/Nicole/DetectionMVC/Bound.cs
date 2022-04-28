// Written by Soojung
// 4-21-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : Element
{
    void OnCollisionEnter(Collision collision)
    {
        app.controller.OnBallGroundHit(collision.gameObject);
    }
}
