using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    public bool noBall = true;
    private CharacterState myACS;
    //private bool ons1 = true;

    public Singleton daSingleton = Singleton.Instance;

    private Rigidbody rb;

    private Transform currentTransform;
    private int redBallLayer = 7;
    private int blueBallLayer = 8;
    private int redPlayerLayer = 9;
    private int bluePlayerLayer = 10;
    [SerializeField] private PathObj myPath;

    private bool hasPoint = false;
    [SerializeField] private float buffDist;
   

    private void Awake()
    {
        myACS = this.gameObject.GetComponent<CharacterState>();
        rb = this.gameObject.GetComponent<Rigidbody>();

    }

   

    // Update is called once per frame
    private void Update()
    {
        if (noBall)
        {

            if (hasPoint == false)
            {
                GetPoint();
            }
            else
            {
                MoveNpcTo();
            }
            //MoveToPoint();
        }
    }

    private void GetPoint()
    {
        int rando = UnityEngine.Random.Range(0, myPath.tfPts.Count - 1);
        currentTransform = myPath.tfPts[rando];
        hasPoint = true;
        Debug.Log(currentTransform);
    }



    /*public void MoveToPoint()
    {
        myACS.IsRun();


        if (ons1)
        {
            int rando = Random.Range(0, myPath.tfPts.Count - 1);
            currentTransform = myPath.tfPts[rando];
            ons1 = false;
        }
        this.transform.LookAt(currentTransform.position);
        float distanceToPoint = (currentTransform.position - this.transform.position).magnitude;

        if (distanceToPoint > 1.0f)
        {

            Vector3 directionToPoint = (currentTransform.position - transform.position).normalized;

            rb.AddForce(directionToPoint * 20, ForceMode.Force);


        }
        else { ons1 = true; }


        //Speed limit based on animation state (myACS)
        if (rb.velocity.magnitude > myACS.GetMoveSpeed())
        {

            Vector3 tempVel = rb.velocity.normalized;

            rb.velocity = myACS.GetMoveSpeed() * tempVel;

        }

    }*/



    // move char to aquired point
    private void MoveNpcTo()
    {
        this.transform.LookAt(currentTransform.position);
        float distanceToPoint = (currentTransform.position - this.transform.position).magnitude;
        // check distance buffer
        if (distanceToPoint > buffDist)
        {

            Vector3 directionToPoint = (currentTransform.position - transform.position).normalized;

            rb.AddForce(directionToPoint * 20, ForceMode.Force);


        }
        else
        {
            hasPoint = false;
        }
    }

}
