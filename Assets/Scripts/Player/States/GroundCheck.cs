// creator Isaac Bustad
// created 4/20/22

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    
    [Header("GroundCheck point")]
    [SerializeField] private Transform grdTfPt;
    [SerializeField] private float playerHeight;
    [SerializeField] private float heightBuffer;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundDrag = 5;
    [SerializeField] private float airDrag = 0;


    private CharacterState cs;
    private Rigidbody rb;
    private bool isGrounded = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cs = GetComponent<CharacterState>();
    }


    private void FixedUpdate()
    {
        PerGrndChk();
    }
    private void PerGrndChk()
    {
        if (cs.CurMoveState() != "h")
        {
            //Debug.Log(myCharState.CurMoveState());

            isGrounded = Physics.Raycast(grdTfPt.position, Vector3.down,
                                     playerHeight * 0.5f + heightBuffer,
                                     whatIsGround);


            if (isGrounded == true)
            {
                cs.IsGrounded();
                rb.drag = groundDrag;
            }
            else

            {
                cs.IsAir();
                rb.drag = airDrag;
            }
        }
    }
}
