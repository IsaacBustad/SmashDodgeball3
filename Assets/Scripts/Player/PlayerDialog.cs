//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialog : MonoBehaviour
{
    [SerializeField] private Text dialogBox;
    [SerializeField] private GameObject dialogBack;

    private void Start()
    {
        dialogBack.SetActive(false);
        
    }
    public void DisDialog()
    {

    }

    
}
