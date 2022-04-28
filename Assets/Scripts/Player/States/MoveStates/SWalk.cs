// creator Isaac Bustad
// created 3/15/2022



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWalk : IMoveState
{
    // construct State
    

    public SWalk(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", true);
    }

    // methods to change state
    public void IsWalk(CharacterState aCS)
    {
        aCS.MyMoveState = new SWalk(aCS);        
    }

    public void IsRun(CharacterState aCS)
    {
        aCS.MyMoveState = new SRun(aCS);
    }

    public void IsDash(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", false);
        aCS.MyMoveState = new SDash(aCS);
    }

    public void IsThrow(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", false);
        aCS.MyMoveState = new SThrow(aCS);
    }

    public void IsIdle(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", false);
        aCS.MyMoveState = new SIdle(aCS);
    }

    public void IsHit(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", false);
        aCS.MyMoveState = new SHit(aCS);
    }

    //vars as methods
    public float Acceleration()
    {
        return 40f;
    }

    public float MaxSpeed()
    {
        return 4f;
    }

    public string CurMoveState()
    {
        return "w";
    }

}
