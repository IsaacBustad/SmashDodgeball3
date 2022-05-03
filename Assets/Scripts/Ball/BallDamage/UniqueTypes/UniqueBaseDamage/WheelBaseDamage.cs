using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBaseDamage : BallDamageElement
{
    public override float DamageNumber()
    {
        return 2f;
    }

    public override float KnockbackNumber()
    {
        return 5f;
    }
}
