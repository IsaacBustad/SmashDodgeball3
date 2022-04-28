using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : Ball
{
    public int rotationSpeed = 100;
    private BallSpin ballSpin;

    public AudioClip audio;
    private bool hasPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        damageElement = new EyeBaseDamage();
    }
    void Update()
    {
        ballEffect();
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

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "NPC")
        {
            // Blind player for 5 seconds or makes NPC unable to throw for 5 seconds
           
        }
    }
}
