// creator Isaac Bustad
// created 4/22/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharHealth : MonoBehaviour
{
    private CharacterState myCS;
    public float healthDamMult = 0.000000000000000000005f;
    private Vector3 vz = new Vector3(0f,0f,0f);
    private float healthRecMult = 0.01f;
    // orientation obj is for getting rot dir info only
    [SerializeField] private Transform orientation;
    [SerializeField] private Thrower myThrower;
    private Transform playerTf;
    private Rigidbody rb;

    [Header("Do not edit")]
    [SerializeField] public float health = 0f;
    public CharElimEffect efGO;

    //read only
    public float Health
    {
        get { return this.health; }
    }

    // constructor
    public void Awake()
    {
        playerTf = gameObject.GetComponent<Transform>();
        myCS = gameObject.GetComponent<CharacterState>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    
    public void TakeDammage(float dam, float knock, Transform collPt)
    {        
        myCS.IsHit();
        rb.velocity = vz;
        health += dam;
        myThrower.hasBall = false;
        KnockBack(knock, collPt);
        efGO.PlayEffect(playerTf);
        //KnockBack(knock, aTf);        
    }

    private void KnockBack(float knock, Transform colTf)
    {
        rb.velocity = vz;
        
        //orientation.LookAt(collDir);
        //playerTf.rotation = Quaternion.Euler(0, orientation.rotation.y, 0); 
        //rb.AddForce(collDir * knock * (health * healthDamMult), ForceMode.Impulse);
        Vector3 direction = (colTf.position - playerTf.position) * (-1f);
        rb.AddForce(new Vector3(direction.x , 1, direction.z).normalized  * (health * knock), ForceMode.Impulse);
        StopAllCoroutines();
        StartCoroutine(WaitToRecover());
        //gameObject.GetComponent<PlayerBlind>().BlindMe();
    }

    // coroutines
    // wait to recover
    private IEnumerator WaitToRecover()
    {
        myCS.IsHit();
        yield return new WaitForSeconds(health * healthRecMult);
        myCS.IsIdle();
    }

}
