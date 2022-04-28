// creator Isaac Bustad
// created 3/15/2022



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGroundS 
{
    
    public void IsGrounded(CharacterState aCS);
    public void IsAir(CharacterState aCS);
    public bool GroundCheck();

}
