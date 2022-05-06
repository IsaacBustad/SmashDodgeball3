// Written by Josh Xiong
// Decorator pattern: Spike base damage

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBaseDamage : BallDamageElement
{
    public override float DamageNumber()
    {
        return 5f;
    }

    public override float KnockbackNumber()
    {
        return 1f;
    }
}
