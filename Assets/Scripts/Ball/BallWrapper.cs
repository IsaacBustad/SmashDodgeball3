using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWrapper : BallDamageDecorator
{
    public BallWrapper(BallDamageElement be) : base(be)
    {
    }

    public override float DamageNumber()
    {
        return base.element.DamageNumber();
    }
    public override float KnockbackNumber()
    {
        return base.element.KnockbackNumber();
    }

}
