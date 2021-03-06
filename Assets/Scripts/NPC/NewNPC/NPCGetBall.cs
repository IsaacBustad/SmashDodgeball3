// Mike/Ike
//4/28/2022

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGetBall : MonoBehaviour, IObserver //interface ball list get
{
    // params
    
    [SerializeField] private float buffDist = 1f;
    [SerializeField] private GameObject tstObj;


    //salvage params
    private INPCState state;
    private CharacterState myACS;
    private CharacterBroadcast myCharacterBroadcast;

    private List<GameObject> allBalls = new List<GameObject>();
    private List<GameObject> allPlayers = new List<GameObject>();
    private List<GameObject> eligibleBalls = new List<GameObject>();
    //private List<GameObject> eligiblePlayers = new List<GameObject>();
    private GameObject closestBall;
    private GameObject closestEnemy;

    public Singleton daSingleton = Singleton.Instance;

    private GameObject divider;
    private Rigidbody rb;
    private float lowestDistance;

    private float dividerThickness;

    // layerBlock
    private int redBallLayer = 7;
    private int blueBallLayer = 8;
    private int redPlayerLayer = 9;
    private int bluePlayerLayer = 10;


    [SerializeField] private HasBallS hasBallState;
    [SerializeField] private NoBallS noBallState;
    [SerializeField] private OutS outState;
    [SerializeField] public Thrower myThrower;


    // coroutine vars
    [SerializeField] private float timeToThrow = 1;
    private WaitForSeconds waitToThrow;
    private bool canThrow = true;
    private NpcMove npcMove;
    


   


    public void updateObserver(List<GameObject> aListOfBalls, List<GameObject> aListOfPlayers)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        myACS = gameObject.GetComponent<CharacterState>();
        waitToThrow = new WaitForSeconds(timeToThrow);
        npcMove = gameObject.GetComponent<NpcMove>();
    }

    private void Update()
    {
        
        MoveCondition();
        
    }

    private void MoveCondition()
    {
        if (myACS.CurMoveState() == "i" || myACS.CurMoveState() == "w" || myACS.CurMoveState() == "r")
        {
            if (myACS.GroundCheck())
            {
                if (myThrower.hasBall == false)
                {
                    TargetABall();
                }
            }
        }
    }

    private void TargetABall()
    {
        myACS.IsWalk();
        FindClosestBall();
        MovrToBall();
        ThrowBallMike();
    }
    private void ThrowBallMike()
    {
        float distanceToPoint = (closestBall.transform.position - this.transform.position).magnitude;
        if (distanceToPoint < buffDist)
        {
            StartCoroutine(WaitToPickUp());
            myThrower.ballOBJ = closestBall;
            myThrower.ballOBJ.GetComponent<BallDealDamage>().IsArmed = true;
            myThrower.hasBall = true;

            if (canThrow == true)
            {
                StartCoroutine(WaitToTrhow());
            }
        }
    }
    private void MovrToBall()
    {
        if (eligibleBalls.Count != 0 && canThrow==true)
        {

            
            if (myACS.GroundCheck() == true)
            {
                Vector3 lookV3 = new Vector3(closestBall.transform.position.x, this.transform.position.y, closestBall.transform.position.z);
                this.transform.LookAt(lookV3);
                float distanceToPoint = (closestBall.transform.position - this.transform.position).magnitude;
                // check distance buffer
                if (distanceToPoint >= buffDist)
                {

                    Vector3 directionToPoint = (closestBall.transform.position - transform.position).normalized;

                    rb.AddForce(new Vector3(directionToPoint.x, 0, directionToPoint.z) * 100, ForceMode.Force);
                }
                else { ThrowBallMike(); }
/*                else
                {
                    myThrower.ballOBJ = closestBall;
                    myThrower.ballOBJ.GetComponent<BallDealDamage>().IsArmed = true;
                    myThrower.hasBall = true;

                    if (canThrow == false)
                    {
                        StartCoroutine(WaitToTrhow());
                    }

                }*/
            }
        }
        
    }


    private void ThrowBall()
    {
        eligibleBalls.Remove(closestBall);
        FindClosestEnemy();
        Debug.Log(allPlayers.Count);
        //Debug.Log(eligiblePlayers.Count);
        Debug.Log(closestEnemy.name);
        rb.velocity = Vector3.zero;
        myThrower.ThrowBall(myACS, closestEnemy.transform );
    }

    public GameObject FindClosestBall()
    {
        if(allBalls.Count != 0)
        {

        
        //Loop through list of AllBalls and update Eligible Balls

        foreach (var p in daSingleton.AllBalls)
        {
            if ((p.layer == redBallLayer && this.gameObject.layer == redPlayerLayer) || (p.layer == blueBallLayer && this.gameObject.layer == bluePlayerLayer))
            {
                if (!EligibleBalls.Contains(p))
                {
                    EligibleBalls.Add(p);
                }
            }
            else
            {
                if (EligibleBalls.Contains(p))
                { EligibleBalls.Remove(p); }
            }
            if (p.GetComponent<BallDealDamage>().IsArmed)
            {
                EligibleBalls.Remove(p);
            }
        }

            // Find ball with lowest distance
            if (EligibleBalls.Count > 0)
            {
                closestBall = null;
                foreach (var p in EligibleBalls)
                {
                    float distance = (p.transform.position - this.transform.position).magnitude;

                    if (closestBall == null)
                    {
                        lowestDistance = distance;
                        closestBall = p;
                    }
                    else if (distance < lowestDistance)
                    {
                        lowestDistance = distance;
                        closestBall = p;
                    }
                }
            }
        }
        else { closestBall = null; }
        //Debug.Log("AllBalls Count: " + AllBalls.Count + "\n  | Eligible Balls: " + EligibleBalls.Count + "\n  | Closest Ball: " + closestBall.name);

        return closestBall;
    }


    // find targ player
    public void FindClosestEnemy()
    {
        List<GameObject> eligiblePlayers = new List<GameObject>();
        //closestEnemy = null;
        //Loop through list of AllPlayers and update EligiblePlayers
        foreach (var p in AllPlayers)
        {
            Debug.Log("AllPlayers: " + p.name);

            if ((p.layer == 9 && this.gameObject.layer == bluePlayerLayer) || (p.layer == bluePlayerLayer && this.gameObject.layer == redPlayerLayer))
            {
                if (!eligiblePlayers.Contains(p))
                { eligiblePlayers.Add(p); }
            }
            /*else
            {
                if (EligiblePlayers.Contains(p))
                { EligiblePlayers.Remove(p); }
            }*/
        }

        // Find enemy with lowest distance
        foreach (var p in eligiblePlayers)
        {
            float distance = (p.transform.position - this.transform.position).magnitude;

            if (closestEnemy == null)
            {
                lowestDistance = distance;
                closestEnemy = p;

            }
            else if (distance < lowestDistance)
            {
                lowestDistance = distance;
                closestEnemy = p;
            }

        }
        
    }


    // coroutines
    private IEnumerator WaitToTrhow()
    {
        canThrow = false;
        yield return waitToThrow;
        ThrowBall();
        yield return waitToThrow;
        canThrow = true;
    }

    private IEnumerator WaitToPickUp()
    {
        
        yield return waitToThrow;
        
    }







    /////////////// pub gets and sets
    ///


    public List<GameObject> AllBalls
    {
        get { return this.allBalls; }
        set { this.allBalls = value; }
    }
    public List<GameObject> EligibleBalls
    {
        get { return this.eligibleBalls; }
        set { this.eligibleBalls = value; }
    }

    public List<GameObject> AllPlayers
    {
        get { return this.allPlayers; }
        set { this.allPlayers = value; }
    }
    /*public List<GameObject> EligiblePlayers
    {
        get { return this.eligiblePlayers; }
        set { this.eligiblePlayers = value; }
    }*/
    public GameObject ClosestBall
    {
        get { return this.closestBall; }
        set { this.closestBall = value; }
    }
    public GameObject ClosestEnemy
    {
        get { return this.closestEnemy; }
        set { this.closestEnemy = value; }
    }
    public GameObject Divider
    {
        get { return this.divider; }
        set { this.divider = value; }
    }
    public float DividerThickness
    {
        get { return this.dividerThickness; }
        set { this.dividerThickness = value; }
    }
    public Rigidbody Rb
    {
        get { return this.rb; }
        set { this.rb = value; }
    }

    public CharacterState MyACS
    {
        get { return this.myACS; }
        set { this.myACS = value; }
    }
    public INPCState State
    {
        get { return this.state; }
        set { this.state = value; }
    }
    public HasBallS HasBallState
    {
        get { return this.hasBallState; }
        set { this.hasBallState = value; }
    }
    public NoBallS NoBallState
    {
        get { return this.noBallState; }
        set { this.noBallState = value; }
    }
    public OutS OutState
    {
        get { return this.outState; }
        set { this.outState = value; }
    }
}
