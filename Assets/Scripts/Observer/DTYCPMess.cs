//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTYCPMess
{
    private FileToList gate = new FileToList();
    private string[] negComments;
    public string GetMessage()
    {
        if(negComments == null)
        {
            negComments = gate.GetMSGs();
        }
        int newRand = Random.Range(0, negComments.Length);
        Debug.Log(negComments[newRand]);
        return negComments[newRand];
        
    }
}
