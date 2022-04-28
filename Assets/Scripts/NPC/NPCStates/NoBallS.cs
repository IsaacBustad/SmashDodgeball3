// Written by Mike Mott
// 3.29.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBallS : MonoBehaviour, INPCState
{
    private NPCharacter NPC;
    private Vector3 directionToBall;
    private float distanceToBall;
    private float lowestDistance;
    private GameObject closestBall;

    private int redBallLayer = 7;
    private int blueBallLayer = 8;
    private int redPlayerLayer = 9;
    private int bluePlayerLayer = 10;

    void Awake()
    {
        NPC = gameObject.GetComponent<NPCharacter>();

    }

    public void GoGetBall()
    {   //Find the closest ball. Move to it, and pick it up.
        

        closestBall = NPC.FindClosestBall();
        
        if (closestBall != null)
        {
            //Debug.Log("me: " + this.name + " closest ballxxxxxxx: " + closestBall.name);
            MoveTo(closestBall.transform.position);
            PickUpBall(closestBall);
        }

    }
    public void GetHit(Collision aCollision)
    {
        // NPC got hit while not holding a ball - you're out!
        // MMM - Take NPC out of the game
        // When an NPC is out, it gets taken out of play and put on a stack
        NPC.daSingleton.OutPlayers.Enqueue(this.NPC.gameObject);
        NPC.State = NPC.OutState;

    }
    public void ThrowBall()
    {
        // No ball, so can't throw
    }
    public void YoureIn()
    {
    }



    public void MoveTo(Vector3 aPoint)
    {
        //Set animation state
        NPC.MyACS.IsRun();
        this.transform.LookAt(aPoint);

        if (gameObject.layer == redPlayerLayer && aPoint.z <= 0)
        {
            aPoint.z = 0;
        }
        else if (gameObject.layer == bluePlayerLayer && aPoint.z >= 0)
        {
            aPoint.z = 0;
        }

        float distanceToPoint = (aPoint - this.transform.position).magnitude;
        if (distanceToPoint > 1.0f)
        {
            Vector3 directionToPoint = (aPoint - this.NPC.transform.position).normalized;
            NPC.Rb.AddForce(directionToPoint * 20, ForceMode.Force);

        }else{this.NPC.Rb.velocity = new Vector3(0, 0, 0);}


        //Speed limit based on animation state (myACS)
        if (this.NPC.Rb.velocity.magnitude > this.NPC.MyACS.GetMoveSpeed())
        {
            Vector3 tempVel = this.NPC.Rb.velocity.normalized;
            this.NPC.Rb.velocity = this.NPC.MyACS.GetMoveSpeed() * tempVel;
        }





    }


    public void PickUpBall(GameObject aBall)
    {

        distanceToBall = (closestBall.transform.position - this.transform.position).magnitude;
        if (!NPC.myThrower.hasBall && distanceToBall < 2.0f)
        {
            Debug.Log("NoBallS, PickUpBall");
            NPC.myThrower.ballOBJ = aBall;
            NPC.myThrower.hasBall = true;
            NPC.State = NPC.HasBallState;
        }

    }

    public override string ToString()
    {
        return "No Ball State";
    }
}

