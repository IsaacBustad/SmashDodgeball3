using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmedContext
{
    public IArmedState armedState;
    public ArmedContext()
    {
        armedState = new StateUnarmed();

    }

    public void setState(IArmedState state)
    {
        this.armedState = state;
    }

    public bool getState()
    {
        return this.armedState.getState(this);
    }




    /*   public bool Armed()
       {
           return armedState.Armed(this);
       }

       public bool UnArmed()
       {
           return armedState.UnArmed(this);
       }*/

}
