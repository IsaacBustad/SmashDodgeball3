using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallDamageDecorator : BallDamageElement
{
    protected BallDamageElement element;

    protected BallDamageDecorator(BallDamageElement element)
    {
        this.element = element;
    }
}
