using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBall : Ball
{
    public int rotationSpeed = 50;
    private BallSpin ballSpin;

    public AudioClip bombStartAudio;
    private bool hasPlayed = false;


    void Start()
    {
        damageElement = new BombBaseDamage();
    }
    void Update()
    {
        //ballEffect();
    }

    // When player grabs ball
    public override void ballEffect()
    {
        // Spin ball
        ballSpin.SpinBall(rotationSpeed);

        if (hasPlayed == false)
        {
            // Spin noise effect
            AudioSource.PlayClipAtPoint(bombStartAudio, gameObject.transform.position, 3);
            hasPlayed = true;
        }
    }
}
