// Written by Nicole
// 4-7-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBallFactory : BallFactory
{
    BombBall bombBall;
    BallSpawner spawner;

    /*public override GameObject SpawnBall()
    {
        //Spawn
        GameObject ball = Instantiate(bombBall.gameObject, bombBall.location , Quaternion.identity); //create and spawn

        spawner.AddBallList(bombBall.gameObject);

        return ball;
    }*/
}
