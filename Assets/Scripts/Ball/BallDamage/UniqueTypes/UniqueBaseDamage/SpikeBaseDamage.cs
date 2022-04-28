using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBaseDamage : BallDamageElement
{
    public override float DamageNumber()
    {
        return 1f;
    }

    public override float KnockbackNumber()
    {
        return 0.5f;
    }
}
