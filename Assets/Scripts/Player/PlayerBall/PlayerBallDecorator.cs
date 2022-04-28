using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallDecorator : BallDamageDecorator
{
    private float myMult;
    public PlayerBallDecorator(BallDamageElement be, float powMult) : base(be)
    {
        myMult = powMult;
    }

    public override float DamageNumber()
    {
        return base.element.DamageNumber() * myMult ;
    }
    public override float KnockbackNumber()
    {
        return base.element.KnockbackNumber() * myMult;
    }
}
