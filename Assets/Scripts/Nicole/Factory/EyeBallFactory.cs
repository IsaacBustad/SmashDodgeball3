using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallFactory : BallFactory
{
    EyeBall eyeBall;
    BallSpawner spawner;

    /*public override Ball SpawnBall()
    {
        //Spawn
        Instantiate(eyeBall.gameObject, eyeBall.location, Quaternion.identity); //create and spawn

        spawner.AddBallList(eyeBall.gameObject);

        return new EyeBall();
    }*/
}
