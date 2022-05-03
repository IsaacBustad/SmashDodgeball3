// creator Isaac Bustad
// created 4/18/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// test comit
public class BallDealDamage : MonoBehaviour
{
    private bool isArmed = false;
    private Rigidbody rb;
    private Transform tf;
    public Ball myBall;
    private float mySpeedMult = 1f;
    private float maxVel = 1;
    
    public BallSpawner mySpawner;

    [SerializeField] private BallDamageEffect myDamageEffect;
    

    public float MaxVel
    {
        set { maxVel = value; }
    }
    public float MySpeedMult
    {
        set { mySpeedMult = value; }
    }

    public bool IsArmed
    {   
        get { return isArmed; }
        set { isArmed = true; /*myBall.ballEffect*/}
    }
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tf = gameObject.GetComponent<Transform>();        
    }

    // updates for physics Sys
    private void FixedUpdate()
    {
        MoveTheBall();
    }

    // sence collison
    private void OnCollisionEnter(Collision collision)
    {
        if (isArmed == true)
        {
            DoDammage(collision);
        }
        
       
    }

    // moave ball when armed
    private void MoveTheBall()
    {
        if (isArmed == true)
        {
            rb.AddForce(gameObject.transform.forward * 100, ForceMode.Force);
            LimitBallVell();
        }
        
    }

    // limit velocity
    private void LimitBallVell()
    {
        if (rb.velocity.magnitude > maxVel)
        {
            Vector3 limitedVel = rb.velocity.normalized * maxVel;
            rb.velocity = limitedVel;
        }
    }

    private void DoDammage(Collision collision)
    {
        Debug.Log("found");
        CharHealth charHealth = collision.transform.gameObject.GetComponent<CharHealth>();
        Debug.Log(collision.transform.gameObject.name);

        if (charHealth != null)
        {
            Debug.Log("Health");
            if (EnemyTeam(collision) == true)
            {
                Debug.Log("dammage");
                charHealth.TakeDammage(myBall.damageElement.DamageNumber(), myBall.damageElement.KnockbackNumber(), tf);

                
                Destroy(this.gameObject, 1f);
                if (mySpawner != null) { mySpawner.RemoveBallList(this.gameObject); }
                DesEffect();
            }
        }
        DissarmBall();
    }

    private void DissarmBall()
    {
        isArmed = false;
        myBall.ResetBaseDamage();
        rb.useGravity = true;
    }

    private bool EnemyTeam(Collision collision)
    {
        Debug.Log("Called");
        if (this.gameObject.layer == 7 && collision.gameObject.layer == 10) { return true; } 
        else if (this.gameObject.layer == 8 && collision.gameObject.layer == 9) { return true; } 
        else { Debug.Log("False"); return false; }
    }

    private void DesEffect()
    {
        myDamageEffect.PlayEffect(tf);
    }
}
