// creator Isaac Bustad
// created 4/22/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimiter : MonoBehaviour
{
    private CharacterState cs;
    private Rigidbody rb;

    private void Awake()
    {
        cs = GetComponent<CharacterState>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        LimitSpeed();
    }
    private void LimitSpeed()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > cs.GetMoveSpeed())
        {
            Vector3 limitedVel = flatVel.normalized * cs.GetMoveSpeed();
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
