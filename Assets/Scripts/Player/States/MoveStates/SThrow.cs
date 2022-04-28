using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SThrow : IMoveState
{
    public SThrow(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsThrow", true);

    }

    private RunSpeed runSpeed = new RunSpeed();
    public void IsWalk(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsThrow", false);
        aCS.MyMoveState = new SWalk(aCS);
    }

    public void IsRun(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsThrow", false);
        aCS.MyMoveState = new SRun(aCS);
    }

    public void IsDash(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsThrow", false);
        aCS.MyMoveState = new SDash(aCS);
    }

    public void IsThrow(CharacterState aCS)
    {
        //aCS.myAnim.SetBool("IsThrow", false);
        aCS.MyMoveState = new SThrow(aCS);
    }

    public void IsIdle(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsThrow", false);
        aCS.MyMoveState = new SIdle(aCS);
    }
    public void IsHit(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsThrow", false);
        aCS.MyMoveState = new SHit(aCS);
    }


    public MoveSpeed GetMoveSpeeds()
    {
        return this.runSpeed;
    }

    public float Acceleration()
    {
        return 0f;
    }
    public float MaxSpeed()
    {
        return 0f;
    }

    public string CurMoveState()
    {
        return "t";
    }
}
