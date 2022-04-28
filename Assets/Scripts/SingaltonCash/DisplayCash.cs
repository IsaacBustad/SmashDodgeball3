//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCash : MonoBehaviour
{
    private Text disField;
    
    private Cash CashObj = Cash.Instance;

    private void Start()
    {
        disField = gameObject.GetComponent<Text>();
        CashObj.playerCash -= 1;
        DisCurrCash();
    }
    private void Update()
    {
        DisCurrCash();
    }
    public void DisCurrCash()
    {
        disField.text = CashObj.playerCash.ToString();
    } 
}
