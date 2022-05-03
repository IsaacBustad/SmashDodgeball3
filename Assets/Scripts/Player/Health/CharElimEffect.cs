using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ball", menuName = "ScriptableObjects/CharElimEffect")]
public class CharElimEffect : ScriptableObject
{
    [SerializeField] private GameObject effect;
    [SerializeField] private List<AudioClip> aC;
    


    public void PlayEffect(Transform aTF)
    {
        GameObject newEffect = Instantiate(effect, aTF.position, aTF.rotation);
        int rn = Random.Range(0, aC.Count);
        AudioSource.PlayClipAtPoint(aC[rn], aTF.position );
        Destroy(newEffect, 2f);
    }
}
