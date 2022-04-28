using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRFloorBallLayer : MonoBehaviour
{
    [SerializeField] private int layerInt;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Ball>().ballLayer = layerInt;
        other.gameObject.layer = layerInt;
    }
}
