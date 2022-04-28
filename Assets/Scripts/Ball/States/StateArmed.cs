using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateArmed : IArmedState
{
    public bool getState(ArmedContext context)
    {
        return true;
    }
}
