using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpin : MonoBehaviour
{
    [SerializeField] private bool xAxis;
    [SerializeField] private bool yAxis;
    [SerializeField] private bool zAxis;

    private float spinSpeed; 

    private BallDealDamage ballDealDamage;


    void Awake()
    {
        ballDealDamage = gameObject.GetComponentInParent(typeof(BallDealDamage)) as BallDealDamage;
    }

    void Update()
    {
        if (ballDealDamage.IsArmed)
        {
            SpinBall(spinSpeed);
        }
    }

    public void SpinBall(float speed)
    {
        if (xAxis)
        {
            transform.Rotate(speed * Time.deltaTime, 0, 0);
        }
        if (yAxis)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        if (zAxis)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
    }
}
