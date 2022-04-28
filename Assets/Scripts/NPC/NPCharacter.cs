// Written by Mike Mott
// 3.29.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//  This is the context for the state machine

public class NPCharacter : MonoBehaviour
{

    private INPCState state;
    private CharacterState myACS;
    private CharacterBroadcast myCharacterBroadcast;

    private List<GameObject> allBalls = new List<GameObject>();
    private List<GameObject> allPlayers = new List<GameObject>();
    private List<GameObject> eligibleBalls = new List<GameObject>();
    private List<GameObject> eligiblePlayers = new List<GameObject>();
    private GameObject closestBall;
    private GameObject closestEnemy;

    public Singleton daSingleton = Singleton.Instance;

    private GameObject divider;
    private Rigidbody rb;
    private float lowestDistance;

    private float dividerThickness;

    private int redBallLayer = 7;
    private int blueBallLayer = 8;
    private int redPlayerLayer = 9;
    private int bluePlayerLayer = 10;

    
    [SerializeField] private HasBallS hasBallState;
    [SerializeField] private NoBallS noBallState;
    [SerializeField] private OutS outState;
    [SerializeField] public Thrower myThrower;


    void Awake()
    {

        
        myACS = this.gameObject.GetComponent<CharacterState>();
        myCharacterBroadcast = this.gameObject.GetComponent<CharacterBroadcast>();
        Rb = this.gameObject.GetComponent<Rigidbody>();
        Divider = GameObject.FindGameObjectWithTag("Divider");

        HasBallState = gameObject.GetComponent<HasBallS>();
        NoBallState = gameObject.GetComponent<NoBallS>();
        OutState = gameObject.GetComponent<OutS>();

        this.state = NoBallState;

        

        //***************************************************************************

        Ball[] Ballss = GameObject.FindObjectsOfType<Ball>();
        List<Ball> ListOfBalls = Ballss.ToList();

        foreach (Ball p in ListOfBalls)
        {
            if ((GameObject.FindObjectOfType<Ball>().gameObject.layer == redBallLayer && this.gameObject.layer == redPlayerLayer) || (GameObject.FindObjectOfType<Ball>().gameObject.layer == blueBallLayer && this.gameObject.layer == bluePlayerLayer))
            {
                daSingleton.AllBalls.Add(GameObject.FindObjectOfType<Ball>().gameObject);
               
            }
            
        }

        







        //***************************************************************************

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("AllBalls: " + AllBalls.Count);
        if (AllBalls.Count > 0)
        {
            GoGetBall();
        }

        ThrowBall();

        Debug.Log(this.name + " move state: " + MyACS.CurMoveState());
        Debug.Log(this.name + " NPC state: " + this.state.ToString());
    }

    public void GoGetBall()
    {
        state.GoGetBall();
    }
    public void GetHit(Collision aCollision)
    {
        state.GetHit(aCollision);
    }
    public void ThrowBall()
    {
        state.ThrowBall();
    }
    public void YoureIn()
    {
        state.YoureIn();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Ball collisionObject = collision.gameObject.GetComponent<Ball>();
        if (collisionObject != null)
        {
            GetHit(collision);
        }

    }


    //************************************************************************************************************************************
    // State-Independent methods
    //
    //

    public GameObject FindClosestBall()
    {

        //Loop through list of AllBalls and update Eligible Balls

        foreach (var p in daSingleton.AllBalls) 
        {
            if ((p.layer == redBallLayer && this.gameObject.layer == redPlayerLayer) || (p.layer == blueBallLayer && this.gameObject.layer == bluePlayerLayer))
            {         
                if (!EligibleBalls.Contains(p))
                { EligibleBalls.Add(p);
                }
            }
            else
            {
                if (EligibleBalls.Contains(p))
                { EligibleBalls.Remove(p); }
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
            
        } else { closestBall = null; }
        Debug.Log("AllBalls Count: " + AllBalls.Count() + "\n  | Eligible Balls: " + EligibleBalls.Count() + "\n  | Closest Ball: " + closestBall.name);

        return closestBall;
    }

    public GameObject FindClosestEnemy()
    {

        //closestEnemy = null;
        //Loop through list of AllPlayers and update EligiblePlayers
        foreach (var p in AllPlayers)
        {
            Debug.Log("AllPlayers: " + p.name);

            if ((p.layer == 9 && this.gameObject.layer == bluePlayerLayer) || (p.layer == bluePlayerLayer && this.gameObject.layer == redPlayerLayer))
            {
                if (!EligiblePlayers.Contains(p))
                { EligiblePlayers.Add(p); }
            }
            else
            {
                if (EligiblePlayers.Contains(p))
                { EligiblePlayers.Remove(p); }
            }
        }

        // Find enemy with lowest distance
        foreach (var p in EligiblePlayers)
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
        return closestEnemy;
    }

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
    public List<GameObject> EligiblePlayers
    {
        get { return this.eligiblePlayers; }
        set { this.eligiblePlayers = value; }
    }
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
