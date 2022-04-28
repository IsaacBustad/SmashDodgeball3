//Creator Isaac Bustad
// created 3/3/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CarnTargElement : MonoBehaviour
{
    public CarnTargApp carnTarApp { get { return GameObject.FindObjectOfType<CarnTargApp>(); } }
}

public class CarnTargApp : MonoBehaviour
{
    // pub vars
    public CarnTargModel model;
    public CarnTargView view;
    public CarnTargControler controler;

}
