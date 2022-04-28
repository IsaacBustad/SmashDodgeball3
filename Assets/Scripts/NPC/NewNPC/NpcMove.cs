using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMove : MonoBehaviour
{
    private CharacterState myACS;
    private bool ons1 = true;

    public Singleton daSingleton = Singleton.Instance;

    private Rigidbody rb;

    private Transform currentTransform;
    private int redBallLayer = 7;
    private int blueBallLayer = 8;
    private int redPlayerLayer = 9;
    private int bluePlayerLayer = 10;
    [SerializeField] private PathObjs myPath;



    void Awake()
    {
        myACS = this.gameObject.GetComponent<CharacterState>();

    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        MoveToPoint();

    }

    public void MoveToPoint()
    {
        myACS.IsRun();


        if (ons1)
        {
            int rando = Random.Range(0, myPath.pathPoints.Count - 1);
            currentTransform = myPath.pathPoints[rando];
            ons1 = false;
        }
        this.transform.LookAt(currentTransform.position);
        float distanceToPoint = (currentTransform.position - this.transform.position).magnitude;

        if (distanceToPoint > 1.0f)
        {

            Vector3 directionToPoint = (currentTransform.position - transform.position).normalized;

            rb.AddForce(directionToPoint * 20, ForceMode.Force);


        }
        else { ons1 = true; }


        //Speed limit based on animation state (myACS)
        if (rb.velocity.magnitude > myACS.GetMoveSpeed())
        {

            Vector3 tempVel = rb.velocity.normalized;

            rb.velocity = myACS.GetMoveSpeed() * tempVel;

        }


    }

}
