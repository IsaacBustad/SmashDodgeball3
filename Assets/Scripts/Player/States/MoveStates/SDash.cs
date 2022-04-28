// creator Isaac Bustad
// created 3/15/2022



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDash : IMoveState
{
    public SDash(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsWalk", false);
        aCS.myAnim.SetBool("IsDash", true);
        aCS.myAnim.SetBool("IsThrow", false);

    }

    public void IsWalk(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsDash", false);
        aCS.MyMoveState = new SWalk(aCS);
    }

    public void IsRun(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsDash", false);
        aCS.MyMoveState = new SRun(aCS);
    }

    public void IsDash(CharacterState aCS)
    {
        aCS.MyMoveState = new SDash(aCS);
    }
    public void IsThrow(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsDash", false);
        aCS.MyMoveState = new SThrow(aCS);
    }

    public void IsIdle(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsDash", false);
        aCS.MyMoveState = new SIdle(aCS);
    }

    public void IsHit(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsDash", false);
        aCS.MyMoveState = new SHit(aCS);
    }


    // Vars as functions
    public float Acceleration()
    {
        return 120f;
    }
    public float MaxSpeed()
    {
        return 36f;
    }

    public string CurMoveState()
    {
        return "d";
    }
}
