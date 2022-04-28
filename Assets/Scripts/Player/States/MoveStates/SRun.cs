// Creator Isaac Busatd
// Created 3/14/2021


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SRun : IMoveState
{
    public SRun(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", true);
    }

    // change States
    public void IsWalk(CharacterState aCS)
    {
        aCS.MyMoveState = new SWalk(aCS);
    }

    public void IsRun(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", false);
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
        return 120f;
    }
    public float MaxSpeed()
    {
        return 12;
    }
    public string CurMoveState()
    {
        return "r";
    }
}
