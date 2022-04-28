// Written by Nicole
// 4-24-2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkModel : Element1, IObserver
{
    public int pplNum;
    public void updateObserver(List<GameObject> aListOfBalls, List<GameObject> aListOfPlayers)
    {
        pplNum = aListOfPlayers.Count;
        if (pplNum <= 4)
        {
            app.controller.ShrinkOn();
        }
    }
}
