// Written by Nicole
// 3-28-2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    // spawn time
    public float timeSpawnMax = 10f;
    public float timeSpawnMin = 3f;

    public float spawnTime; //interval
    public float lastSpawnTime;

    // position
    public Vector3[] locations;

    //Singleton
    List<GameObject> ballList = new List<GameObject>(); //that's in the game
    private Singleton mySingleton = Singleton.Instance;

    //Class Array
    public BallFactory[] ballTypeList;


    void Start()
    {

        spawnTime = Random.Range(timeSpawnMin, timeSpawnMax);
        lastSpawnTime = 0;

    }


    void Update()
    {
        if (Time.time >= lastSpawnTime + spawnTime)
        { //if time to spawn
            lastSpawnTime = Time.time;
            spawnTime = Random.Range(timeSpawnMin, timeSpawnMax);
            int listNum = Random.Range(0, 5); //for balltypelist
            int locationNum = Random.Range(0, locations.Length);
            GameObject newBall = ballTypeList[listNum].SpawnBall(locations[locationNum]);
            newBall.GetComponent<BallDealDamage>().mySpawner = this;
            AddBallList(newBall);
        }

    }

    //Singleton
    public void AddBallList(GameObject ball)
    {
        ballList.Add(ball);
        mySingleton.BallUpdated(ballList);
    }

    public void RemoveBallList(GameObject ball)
    {
        ballList.Remove(ball);
        mySingleton.BallUpdated(ballList);
    }


}