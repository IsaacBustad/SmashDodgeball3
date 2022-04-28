using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ball is super fast! Fire particle
public class WheelBall : Ball
{
    public int rotationSpeed = 500;

    public AudioClip audio;
    private bool hasPlayed = false;

    private BallSpin ballSpin;


    void Start()
    {
        damageElement = new WheelBaseDamage();
    }

    void Update()
    {
        //ballEffect();
    }

    // Strategy pattern
    public override void ballEffect()
    {
        // Spin ball
        ballSpin.SpinBall(rotationSpeed);

        if (hasPlayed == false)
         {
            // Spin noise effect
            AudioSource.PlayClipAtPoint(audio, gameObject.transform.position, 3);
            hasPlayed = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
