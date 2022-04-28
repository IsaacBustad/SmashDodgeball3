using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ball", menuName = "ScriptableObjects/CharElimEffect")]
public class CharElimEffect : ScriptableObject
{
    [SerializeField] private GameObject effect;
    


    public void PlayEffect(Transform aTF)
    {
        GameObject newEffect = Instantiate(effect, aTF.position, aTF.rotation);
        Destroy(newEffect, 2f);
    }
}
