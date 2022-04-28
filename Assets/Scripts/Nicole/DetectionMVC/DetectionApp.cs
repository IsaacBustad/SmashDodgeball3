// Written by Soojung
// 4-21-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public DetectionApp app
    {
        get
        {
            return GameObject.FindObjectOfType<DetectionApp>();
        }
    }
}

public class DetectionApp : MonoBehaviour
{
    public DetectionModel model;
    public DetectionView view;
    public DetectionController controller;
}


