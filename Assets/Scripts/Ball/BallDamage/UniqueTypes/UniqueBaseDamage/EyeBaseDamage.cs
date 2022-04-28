using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBaseDamage : BallDamageElement
{
    public override float DamageNumber()
    {
        return 0.3f;
    }

    public override float KnockbackNumber()
    {
        return 0.3f;
    }
}
