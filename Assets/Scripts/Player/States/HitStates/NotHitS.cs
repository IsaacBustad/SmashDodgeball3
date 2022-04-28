using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotHitS : IHitState
{
    // Start is called before the first frame update
    public void GetHit(CharacterState aCS)
    {
        aCS.MyHitState = new HitS();
    }
    public void Recovery(CharacterState aCS)
    {
        aCS.MyHitState = new NotHitS();
    }
}
