using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLib : ScriptableObject, MoveLib
{
    // for moves
    [SerializeField] private float mF = 2.0f;
    [SerializeField] private float mB = 0.5f;
    [SerializeField] private float mR = 1.0f;
    [SerializeField] private float mL = 1.0f;

    // for turns
    [SerializeField] private float rH = 0.5f;
    [SerializeField] private float rV = 0.5f;
    
    public float MoveBy(string aDir)
    {
        if(aDir.ToLower() == "f")
        {
            return mF;
        }
        else if (aDir.ToLower() == "b")
        {
            return mB;
        }
        else if (aDir.ToLower() == "l")
        {
            return mL;
        }
        else if (aDir.ToLower() == "r")
        {
            return mR;
        }
        else
        {
            return 1.0f;
        }

    }

    public float RotateBy(string aRot)
    {
        if (aRot.ToLower() == "h")
        {
            return rH;
        }

        if (aRot.ToLower() == "v")
        {
            return rV;
        }
        else
        {
            return 1.0f;
        }
    }

}
