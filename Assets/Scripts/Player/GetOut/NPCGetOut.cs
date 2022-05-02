using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGetOut : GetOut
{
    private Singleton singleton = Singleton.Instance;
    private CharacterBroadcast characterBroadcast;

    private void Awake()
    {
        characterBroadcast = GetComponent<CharacterBroadcast>();
    }
    public override void RingOut()
    {
        {
            effect.PlayEffect(this.gameObject.transform);


            // remove from in play list
            // add to que
            singleton.RemoveObserver(characterBroadcast);
            Debug.Log(topObjContatiner.name);
            Destroy(topObjContatiner);
            //topObjContatiner.SetActive(false);
        }
    }
}
