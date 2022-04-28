//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSeller : ServeCMD
{
    [SerializeField] GameObject ballForSale;
    
    [SerializeField] private int cost;
    private Cash CashObj = Cash.Instance;

    public override void Service(GameObject aCli)
    {
        Thrower aThrower = aCli.GetComponent<PlayerInteract>().thrower;

        if (aThrower != null)
        {
            if(CashObj.playerCash >= cost)
            {
                CashObj.playerCash -= cost;
                aThrower.ballOBJ = ballForSale;
            }
                
        }
    }
}
