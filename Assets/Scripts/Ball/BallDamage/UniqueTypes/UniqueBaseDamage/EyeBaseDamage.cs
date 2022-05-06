// Written by Josh Xiong
// Decorator pattern: eye base damage

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBaseDamage : BallDamageElement
{
    public override float DamageNumber()
    {
        return 1f;
    }

    public override float KnockbackNumber()
    {
        return 1f;
    }
}
