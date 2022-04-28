// creator Isaac Bustad
// created 4/22/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWalk : MonoBehaviour
{


    private CharacterState cs;
    private Rigidbody rb;
    //private PlayerMovement m;

    private void Awake()
    {
        cs = GetComponent<CharacterState>();
        rb = GetComponent<Rigidbody>();
        //m = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (cs.CurMoveState() != "h")
        {
            //Debug.Log(myCharState.CurMoveState());

            if (cs.CurMoveState() != "t")
            {
                CheckWalking();
                CheckIdle();
            }
        }
    }

    private void CheckWalking()
    {
        // do not change states if in a moving state
        if (cs.CurMoveState() != "d")
        {
            //Debug.Log("meth");
            if (rb.velocity.magnitude > 0.2)//m.FnB > 0.2f || m.FnB < -0.2f
            {
                //Debug.Log("pass1");
                if (cs.GroundCheck() == true && cs.CurMoveState() != "t")
                {
                    //Debug.Log("comp");
                    cs.IsWalk();
                }

            }
        }
    }

    private void CheckIdle()
    {
        
        if (rb.velocity.magnitude < 0.2)
        {
            if (cs.GroundCheck() == true && cs.CurMoveState() != "t")
            {
                cs.IsIdle();
            }
        }
        
    }
}
