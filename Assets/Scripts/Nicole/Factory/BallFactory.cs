// Written by Nicole
// 4-7-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ball", menuName = "ScriptableObjects/BallFactory", order = 1)]
public class BallFactory : ScriptableObject
{
    [SerializeField] private GameObject ballType;
    public GameObject SpawnBall(Vector3 location)
    {
        GameObject newBall = Instantiate(ballType, location, Quaternion.identity);
        newBall.tag = "Ball";
        return newBall;
    }
}
