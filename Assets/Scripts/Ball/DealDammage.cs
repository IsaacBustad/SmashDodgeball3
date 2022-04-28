//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDammage : MonoBehaviour
{
    //serialize for inspector
    [SerializeField] private int damage = 1;

    private void OnCollisionEnter(Collision collision)
    {
        // get health comp from coliding obj
        Health aHealth = collision.gameObject.GetComponent<Health>();
        // only exe with found ref
        if (aHealth != null)
        {
            aHealth.TakeDammage(damage);
        }        
    }
}
