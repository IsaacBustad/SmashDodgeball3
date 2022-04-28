//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnDrone : MonoBehaviour
{
    // private vars
    //[SerializeField] private float initialForce = 10;   // needed for situational spawner
    //[SerializeField] private float health;
    //[SerializeField] private Transform startPoint;      // needed for situational spawner
    public Transform tf;
    public Rigidbody rb;

    // get and set for spawner
   


    // on awake before start
    void Awake() 
    {
        tf = gameObject.transform;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    

    
}
