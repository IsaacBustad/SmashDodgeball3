//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform camPos;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = camPos.position;
    }
}
