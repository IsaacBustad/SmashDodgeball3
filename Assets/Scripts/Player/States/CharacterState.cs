// creator Isaac Bustad
// created 3/15/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterState : MonoBehaviour
{
    private IHitState myHitState;
    private IMoveState myMoveState;
    private IGroundS myGroundState;
    private CharHealth myCharHealth;
    

    [SerializeField] public Animator myAnim;

    private void Awake()
    {
        myHitState = new NotHitS();
        myMoveState = new SWalk(this);
        myGroundState = new SGrounded(this);
        myCharHealth = gameObject.GetComponent<CharHealth>();
    }

   

    // read onlys
    

    // move state
    public void IsWalk()
    {
        myMoveState.IsWalk(this);
    }

    public void IsRun()
    {
        myMoveState.IsRun(this);
    }

    public void IsDash()
    {
        myMoveState.IsDash(this);
    }

    public void IsThrow()
    {
        myMoveState.IsThrow(this);
    }

    public void IsIdle()
    {
        MyMoveState.IsIdle(this);
    }

    public void IsHit()
    {
        myMoveState.IsHit(this);
    }



    //vars as methods
    public float GetMoveSpeed()
    {
        return myMoveState.MaxSpeed();
    }

    public float GetMoveAccell()
    {
        return myMoveState.Acceleration();
    }
    public string CurMoveState()
    {
        return myMoveState.CurMoveState();
    }


    // Ground state
    public bool GetGroundCheck()
    {
        return myGroundState.GroundCheck();
    }

    public void IsGrounded()
    {
        myGroundState.IsGrounded(this);
    }
    public void IsAir()
    {
        myGroundState.IsAir(this);
    }
    public bool GroundCheck()
    {
        return myGroundState.GroundCheck();
    }

    // access to states
    public IHitState MyHitState
    {
        get { return this.myHitState; }
        set { this.myHitState = value; }
    }

    public IMoveState MyMoveState
    {
        get { return this.myMoveState; }
        set { this.myMoveState = value; }
    }
    
    public  IGroundS MyGroundState
    {
        get { return this.myGroundState; }
        set { this.myGroundState = value; }
    }

    // access method for dammage
    public void TakeDammage(float dam, float knock, Transform collDir)
    {
        myCharHealth.TakeDammage(dam, knock, collDir);
    }


}
