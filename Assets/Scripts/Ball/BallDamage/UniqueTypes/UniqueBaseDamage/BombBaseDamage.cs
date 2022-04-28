using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBaseDamage : BallDamageElement
{
    public override float DamageNumber()
    {
        return 100f;
    }

    public override float KnockbackNumber()
    {
        return 100f;
    }
}
