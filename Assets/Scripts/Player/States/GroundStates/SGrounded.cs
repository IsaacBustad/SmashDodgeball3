// creator Isaac Bustad
// created 3/15/2022



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SGrounded : IGroundS
{
    public SGrounded(CharacterState aCS)
    {
        aCS.myAnim.SetBool("IsGrounded", true);
    }

    // return bools as is grounded?
    public void IsGrounded(CharacterState aCS)
    {
        aCS.MyGroundState = new SGrounded(aCS);        
    }
    public void IsAir(CharacterState aCS)
    {
        aCS.MyGroundState = new SAir(aCS);
    }

    public bool GroundCheck()
    {
        return true;
    }
}
