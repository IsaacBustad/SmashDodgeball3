using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : Ball
{
    public int rotationSpeed = 50;

    public AudioClip audio;
    private bool hasPlayed = false;

    private BallSpin ballSpin;

    // Start is called before the first frame update
    void Start()
    {
        damageElement = new SpikeBaseDamage();
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

    private void OnCollisionEnter(Collision collision)
    {
    }
}
