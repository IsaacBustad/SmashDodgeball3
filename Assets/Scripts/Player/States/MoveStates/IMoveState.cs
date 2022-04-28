// creator Isaac Bustad
// created 3/15/2022



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveState 
{
    // changeStates
    public void IsWalk(CharacterState aCS);

    public void IsRun(CharacterState aCS);

    public void IsDash(CharacterState aCS);

    public void IsThrow(CharacterState aCS);

    public void IsIdle(CharacterState aCS);

    public void IsHit(CharacterState aCS);

    


    // state related info use as vars
    public float Acceleration();
    public float MaxSpeed();
    public string CurMoveState();
}
