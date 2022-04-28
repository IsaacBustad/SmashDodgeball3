using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ball : MonoBehaviour
{
    public BallDamageElement damageElement;
    public BallDamageDecorator damageDecorator = null;

    //for BallFactory
    public Vector3 location;
    public int ballLayer;


    // Start is called before the first frame update
    void Start()
    {
        damageElement = new BallBaseDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Strategy Pattern
    public abstract void ballEffect();

    // method that reset element back to base
    public void ResetBaseDamage()
    {
        damageElement = new BallBaseDamage();
    }
}
