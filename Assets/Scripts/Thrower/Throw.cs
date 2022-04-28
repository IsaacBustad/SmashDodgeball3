//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw
{
    public void ThrowBall(GameObject aGO, Transform aThrowPoint, float throwPow)
    {
        GameObject throwable = GameObject.Instantiate(aGO,aThrowPoint.position,aThrowPoint.rotation);
        Rigidbody throwRB =  throwable.GetComponent<Rigidbody>();
        throwRB.AddForce(throwable.transform.forward * throwPow, ForceMode.Impulse);
        GameObject.Destroy(throwable, 5);

    }
}
