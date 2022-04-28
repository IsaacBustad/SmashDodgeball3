//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[Header("Key Bindings")]
    private KeyCode jumpKey = KeyCode.Space;
    private KeyCode sprintKey = KeyCode.LeftShift;
    private KeyCode dashKey = KeyCode.B;
    private KeyCode throwKey = KeyCode.Mouse0;


    // playerState
    private CharacterState myCharState;

    [Header("Jumps")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCoolDown;
    [SerializeField] private float airMult;
    [SerializeField] private bool readyToJump = true;
    [SerializeField] private bool startJumpCool = false;
    private WaitForSeconds waitJumpCool;


    [Header("MoveSpeed")]
    [SerializeField] private float playerHeight;
    [SerializeField] private float heightBuffer;
    [SerializeField] private float groundDrag;
    //[SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Dash Settings")]
    [SerializeField] private float dashDur;
    [SerializeField] private float dashCool;
    private WaitForSeconds waitDashDur;
    private WaitForSeconds waitDashCool;
    private bool canDash = true;

    [Header("Animator Crap")]
    [SerializeField] private Animator myAnim;

    [Header("Thrower Crap")]
    [SerializeField] private Thrower myThrower;

    // point to check from transfor for ground chk raycast
    [Header("GroundCheck point")]
    [SerializeField] private Transform grdTfPt;


    // hold input
    private float fNb;
    private float rNl;

    private Transform tf;
    private Vector3 movDir;
    private Rigidbody rb;

    // read onlys

    


    private void Start()
    {
        //set references at obj level
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();
        rb.freezeRotation = true;
        
        //myAnim = gameObject.GetComponent<Animator>();
        //myThrower = gameObject.GetComponent<Thrower>();

        // set dependants vars
        myCharState = gameObject.GetComponent<CharacterState>();



        // set up coroutines
        waitJumpCool = new WaitForSeconds(jumpCoolDown);
        waitDashDur = new WaitForSeconds(dashDur);
        waitDashCool = new WaitForSeconds(dashDur);
    }

    private void Update()
    {
        MovementUpdate();
        
    }

    private void MovementUpdate()
    {
        if (myCharState.CurMoveState() != "h")
        {
            //Debug.Log(myCharState.CurMoveState());            
            GetInput();

            if (myCharState.CurMoveState() != "t")
            {
                CheckIdle();
                Dash();
                Sprint();                
                CheckWalking();
            }
            //CheckWalking();

        }
    }

        
    private void FixedUpdate()
    {
        if (myCharState.CurMoveState() != "h")
        {
            if (myCharState.CurMoveState() != "t")
            {
                MovePlayer();
            }
        }
    }

    // get movement input. Call in update
    private void GetInput()
    {
        fNb = Input.GetAxis("Vertical"); // w and s. forward and back. float from 1 to -1 from input.
        rNl = Input.GetAxis("Horizontal"); // a and d. left and right. float from 1 to -1 from input.
        myAnim.SetFloat("XBlend", rNl); // change walk dir in aniamtor
        myAnim.SetFloat("YBlend", fNb); // change walk dir in aniamtor



        ThrowInput();

        if (Input.GetKey(jumpKey) && readyToJump && myCharState.GetGroundCheck() && myCharState.CurMoveState() != "t") 
        {            
            Jump();

            if(startJumpCool == false)
            {
                StartCoroutine(JumpCooldown());
            }
            
        }
    }

    // if player is idle
    private void CheckIdle()
    {
        if ( fNb < 0.1f && fNb > -0.1f)
        {
            if (rNl < 0.1f && rNl > -0.1f)
            {
                if (myCharState.GroundCheck() == true && myCharState.CurMoveState() != "t" )
                {
                    myCharState.IsIdle();
                }
            }
        }
    }


    // Move player. call in update
    public void MovePlayer()
    {
        // calc move direction
        movDir = tf.forward * fNb + tf.right * rNl; 
        


        if (myCharState.GroundCheck() == true && myCharState.CurMoveState() != "t")
        {
            
            
            rb.AddForce(movDir * 100, ForceMode.Force);
        }

      
        else
        {
            myCharState.IsIdle();
            rb.AddForce(movDir * 100 * airMult, ForceMode.Force);
        }
    }

    private void CheckWalking()
    {
        // do not change states if in a moving state
        if (myCharState.CurMoveState() == "i")//!= "d" && myCharState.CurMoveState() != "r"
        {
            //Debug.Log("meth");
            if (fNb > 0.1f || fNb < -0.1f)
            {
                //Debug.Log("pass1");
                if (myCharState.GroundCheck() == true && myCharState.CurMoveState() != "t")
                {
                    //Debug.Log("comp");
                    myCharState.IsWalk();
                }

            }
            if (rNl > 0.2f || rNl < -0.2f)
            {
                //Debug.Log("pass2");
                if (myCharState.GroundCheck() == true && myCharState.CurMoveState() != "t")
                {
                    //Debug.Log("comp");
                    myCharState.IsWalk();
                }
            }
        }
       
    }

    
    private void Jump()
    {
        myCharState.IsIdle();
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        readyToJump = false;

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }


    // change run and walk
    // change only on ground, put in update
    private void Sprint()
    {
        if (myCharState.CurMoveState() == "i" || myCharState.CurMoveState() == "w")
        {
            if (myCharState.GroundCheck() == true)
            {
                if (Input.GetKeyDown(sprintKey))
                {
                    myCharState.IsRun();
                }
                if (Input.GetKeyUp(sprintKey))
                {
                    myCharState.IsWalk();
                }
            }
        }
        
    }

    // execute dash, put in update
    private void Dash()
    {
        if (myCharState.GetGroundCheck() == true)
        {
            if (myCharState.CurMoveState() != "d")
            {
                if (Input.GetKeyDown(dashKey) && canDash == true)
                {
                    StartCoroutine(DashDur());
                }
            }
        }
    }

    private void ThrowInput()
    {
        
        if (Input.GetKeyDown(throwKey))
        {
                
            myThrower.startThrow = true;
            //myCharState.IsThrow();
        }

        else if (Input.GetKeyUp(throwKey))
        {
            //Debug.Log("up");
            //myAnim.SetBool("IsThrow", true);
            myThrower.CallThrow(myCharState);
                
                
        }

        else if (Input.GetKey(throwKey) && myThrower.startThrow == true)
        {
            //Debug.Log("still");
            myThrower.WindUp();
        }
               
    }



    // start coroutines

    // cool down for jumps
    private IEnumerator JumpCooldown()
    {
        startJumpCool = true;
        yield return waitJumpCool;
        startJumpCool = false;
        ResetJump();
    }

    // dash durration
    private IEnumerator DashDur() 
    {
        myCharState.IsDash();
        canDash = false;
        yield return waitDashDur;
        StartCoroutine(DashCool());
        myCharState.IsRun();
    }


    // dash cool down
    private IEnumerator DashCool()
    {
        yield return waitDashCool;
        canDash = true;
    }

    

}
