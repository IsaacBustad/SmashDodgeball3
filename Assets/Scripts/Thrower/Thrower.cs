//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    //private KeyCode throwKey = KeyCode.Mouse0;
    private Transform tf;
    public GameObject ballOBJ;

    public bool hasBall = false;
    public bool startThrow = false;

    [Header("Throw Variables")]
    [SerializeField] private float basePow = 15f;
    [SerializeField] private float powMultBase = 1f;
    [SerializeField] private float powMultMax = 1f;
    //[SerializeField] private float drawDistance = 300f;
    [SerializeField] private Transform sightLine;
    [SerializeField] public int ballLayer;
    [SerializeField] private Transform throwToward;
    private Transform ballHolder;

    private float powMult = 1f;
    private float timeToThrow = 0.1f;
    private WaitForSeconds waitToThrow;
    
    


    private void Awake()
    {
        ballHolder = gameObject.GetComponent<Transform>();
        waitToThrow = new WaitForSeconds(timeToThrow);
    }

private void Update()
    {
        HoldBall();
    }

    

    private void HoldBall()
    {
        if (hasBall == true)
        {
            ballOBJ.transform.position = ballHolder.transform.position;
            ballOBJ.transform.rotation = ballHolder.transform.rotation;
        }        
    }

    public void WindUp()
    {
        powMult += Time.deltaTime;
        Mathf.Clamp(powMult,0f,powMultMax);
    }

    public void CallThrow(CharacterState aCS)
    {
        //aCS.myAnim.SetBool("IsThrow", true);
        if (ballOBJ != null)
        {
            ThrowBall(aCS);
            powMult = powMultBase;
            startThrow = false;
            hasBall = false;
        }
    }

    public void ThrowBall(CharacterState aCS)
    {
        BallDealDamage aBallDam = ballOBJ.GetComponent<BallDealDamage>();
        Rigidbody aBallRb = ballOBJ.GetComponent<Rigidbody>();

        
        aCS.IsThrow();
        
        powMult = Mathf.Clamp(powMult, 0f, powMultMax);
        //ballOBJ.GetComponent<Ball>().damageElement = MultWrapper(ballOBJ.GetComponent<Ball>().damageElement);
        
        aBallDam.myBall.damageElement  = MultWrapper(aBallDam.myBall.damageElement);

        hasBall = false;
        startThrow = false;
        ballOBJ.transform.LookAt(throwToward);

        // prep ball to throw
        
        aBallRb.useGravity = false;
        aBallRb.velocity = Vector3.zero;
        aBallDam.MaxVel = powMult * basePow;
        aBallDam.IsArmed = true;
        
        
        ballOBJ = null;

        StartCoroutine(WaitThrowDur(aCS));
    }

    public void ThrowBall(CharacterState aCS, Transform targ )
    {

        BallDealDamage aBallDam = ballOBJ.GetComponent<BallDealDamage>();
        Rigidbody aBallRb = ballOBJ.GetComponent<Rigidbody>();

        aCS.IsThrow();
        aBallDam.myBall.damageElement = MultWrapper(aBallDam.myBall.damageElement);

        hasBall = false;
        startThrow = false;
        ballOBJ.transform.LookAt(targ);

        aBallRb.useGravity = false;
        aBallRb.velocity = Vector3.zero;
        aBallDam.MaxVel = powMult * basePow;
        aBallDam.IsArmed = true;


        //ballOBJ.GetComponent<Ball>().damageElement = MultWrapper(ballOBJ.GetComponent<Ball>().damageElement);

        ballOBJ = null;
        StartCoroutine(WaitThrowDur(aCS));
    }

    public void ThrowBall(Transform targ)
    {
        BallDealDamage aBallDam = ballOBJ.GetComponent<BallDealDamage>();
        Rigidbody aBallRb = ballOBJ.GetComponent<Rigidbody>();

        //aCS.IsThrow();
        aBallDam.myBall.damageElement = MultWrapper(aBallDam.myBall.damageElement);


        hasBall = false;
        aBallRb.velocity = Vector3.zero;
        startThrow = false;
        ballOBJ.transform.LookAt(targ);

        //ballOBJ.GetComponent<Rigidbody>().AddForce(ballOBJ.transform.forward * powMult, ForceMode.Impulse);

        /*powMult = Mathf.Clamp(powMult, 0f, powMultMax);
        ballOBJ.GetComponent<Ball>().damageElement = MultWrapper(ballOBJ.GetComponent<Ball>().damageElement);

        hasBall = false;
        startThrow = false;
        ballOBJ.transform.LookAt(throwToward);

        // prep ball to throw
        
        aBallRb.useGravity = false;
        aBallRb.velocity = Vector3.zero;
        aBallDam.MaxVel = powMult * basePow;
        aBallDam.IsArmed = true;
        */

    }

    private BallDamageDecorator MultWrapper(BallDamageElement bde)
    {
        return new PlayerBallDecorator(bde, powMult);
    }

    // coroutines
    private IEnumerator WaitThrowDur(CharacterState aCS)
    {
        yield return waitToThrow;
        aCS.IsIdle();
        
    }
}
