// Written by Soojung
// 4-21-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : Element
{
    void OnCollisionEnter(Collision collision)
    {
        app.controller.Detect(collision.gameObject);

        //Isaac's 
        PlayerOut playerOut = collision.gameObject.GetComponent<PlayerOut>();
        if (playerOut != null)
        {
            playerOut.RingOut();
        }
        NPCGetOut npcOut = collision.gameObject.GetComponent<NPCGetOut>();
        if (npcOut != null)
        {
            npcOut.RingOut();
        }
    }
}
