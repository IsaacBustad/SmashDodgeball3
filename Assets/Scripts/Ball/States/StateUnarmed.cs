using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateUnarmed : IArmedState
{
    public bool getState(ArmedContext context)
    {
        return false;
    }
}
