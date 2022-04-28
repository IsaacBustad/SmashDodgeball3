//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeInteraction : MonoBehaviour
{
    public ServeCMD aHost;

    public void Execute(GameObject aCli)
    {
        aHost.Service(aCli);
    }
}
