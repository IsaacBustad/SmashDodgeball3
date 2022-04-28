using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIdle : IMoveState
{
    public SIdle(CharacterState aCS)
    {
        

    }

    // change states
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
        aCS.MyMoveState = new SDash(aCS);
    }
    public void IsThrow(CharacterState aCS)
    {
        aCS.MyMoveState = new SThrow(aCS);
    }

    public void IsIdle(CharacterState aCS)
    {
        aCS.MyMoveState = new SIdle(aCS);
    }
    public void IsHit(CharacterState aCS)
    {
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
        return "i";
    }
}
