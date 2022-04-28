// Written by Soojung
// 4-21-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : Element
{
    BallSpawner ballSpawner;
    public void OnBallGroundHit(GameObject gameObject)
    {
        if (gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            ballSpawner.RemoveBallList(gameObject);
        }
    }
}
