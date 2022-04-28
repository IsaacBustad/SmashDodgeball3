using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ball", menuName = "ScriptableObjects/BallDamageEffect")]
public class BallDamageEffect : ScriptableObject
{
    [SerializeField] private GameObject effect;

    public AudioClip hitAudio;
    private bool hasHit = false;


    public void PlayEffect(Transform _transform)
    {
        if (hasHit == false)
        {
            // Spin noise effect
            AudioSource.PlayClipAtPoint(hitAudio, _transform.position, 3);
            hasHit = true;
        }

        GameObject newEffect = Instantiate(effect, _transform.position, _transform.rotation);
        Destroy(newEffect, 2f);
    }
}
