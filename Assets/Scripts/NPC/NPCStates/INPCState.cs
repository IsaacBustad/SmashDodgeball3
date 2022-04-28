// Written by Mike Mott
// 3.29.2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INPCState
{
    public void GoGetBall();
    public void GetHit(Collision aCollision);
    public void ThrowBall();

    public void MoveTo(Vector3 aPoint);
    public void YoureIn();



}
