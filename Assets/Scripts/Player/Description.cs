//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField] private string desc;

    public string Desc
    {
        get { return this.desc; }
    }
}
