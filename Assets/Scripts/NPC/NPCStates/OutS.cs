// Written by Mike Mott
// 3.29.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutS : MonoBehaviour, INPCState
{
    private NPCharacter NPC;


    void Awake()
    {
        NPC = gameObject.GetComponent<NPCharacter>();
    }
    public void GoGetBall()
    {
        // Out - Can't go get ball
    }
    public void GetHit(Collision aCollision)
    {
        // Out - Getting hit is meaningless
    }
    public void ThrowBall()
    {
        // Out - Can't throw a ball
    }
    public void YoureIn()
    {
        this.NPC.State = this.NPC.NoBallState;
    }
    public void MoveTo(Vector3 targetPosition)
    {
        // Out - can't move
    }

    public override string ToString()
    {
        return "Out State";
    }

}

