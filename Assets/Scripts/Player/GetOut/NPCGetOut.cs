using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGetOut : GetOut
{
    public override void RingOut()
    {
        {
            effect.PlayEffect(this.gameObject.transform);


            // remove from in play list
            // add to que
            topObjContatiner.SetActive(false);
        }
    }
}
