using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    public void updateObserver(List<GameObject> aListOfBalls, List<GameObject> aListOfPlayers);
    
}
