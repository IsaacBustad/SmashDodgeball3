using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitState
{
    // change states
    public void GetHit(CharacterState aCS);
    public void Recovery(CharacterState aCS);
}
