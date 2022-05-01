// Written by Soojung
// 4-21-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : Element
{
    public BallSpawner ballSpawner;
    public void Detect(GameObject gameObject)
    {
        if (gameObject.tag == "Ball")
        {
            Destroy(gameObject);
            ballSpawner.RemoveBallList(gameObject);
        }
    }
}
