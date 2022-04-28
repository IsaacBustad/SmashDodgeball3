//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subscriber : MonoBehaviour
{
    [SerializeField] private Text txtOut;
    private string recMessage = "";
    public void GetMessage(string aName, string aMessage)
    {
        string totMess = aName + ": " + aMessage;
        if(txtOut != null)
        {
            txtOut.text = totMess;
        }
        
    }
}
