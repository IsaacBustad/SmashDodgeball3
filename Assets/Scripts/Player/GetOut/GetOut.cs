using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOut : MonoBehaviour
{
    //singalton reff
    [SerializeField] protected GameObject topObjContatiner;
    [SerializeField] protected CharElimEffect effect;
    // clip

    public virtual void RingOut()
    {
        effect.PlayEffect(this.gameObject.transform);
        
        
        // remove from in play list
        topObjContatiner.SetActive(false);
    }
}
