// Written by Nicole
// 4-24-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element1 : MonoBehaviour
{
    public ShrinkApp app
    {
        get
        {
            return GameObject.FindObjectOfType<ShrinkApp>();
        }
    }
}


public class ShrinkApp : MonoBehaviour
{
    public ShrinkModel model;
    public ShrinkView view;
    public ShrinkController controller;
}
