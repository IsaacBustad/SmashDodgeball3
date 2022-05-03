// Written by Nicole
// 4-24-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkController : Element1
{
    public void ShrinkOn()
    {
        app.view.border.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
        app.view.boundary.transform.localScale -= new Vector3(0.05f, 0.05f, 0.05f);
    }

    public BallSpawner ballSpawner;
    public void Detect(GameObject gameObject)
    {
        if (gameObject.tag == "Ball")
        {
            ballSpawner.RemoveBallList(gameObject);
            Destroy(gameObject);
            
        }
    }
}
