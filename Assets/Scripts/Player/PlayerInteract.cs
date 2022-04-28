//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    private KeyCode interactKey = KeyCode.Mouse1;
    private GameObject emptyGO; 
    [SerializeField] private GameObject aGO;
    public Thrower thrower;
    private Transform tf;
    [SerializeField] private float drawDistance;
    //[SerializeField] private Text descBox;
    [Header("Must be < 0.5")]
    [SerializeField] private float timeToWait = 0.5f;



    private bool canInteract = true;

    private WaitForSeconds waitToInteract;

    private void Start()
    {
        tf = gameObject.GetComponent<Transform>();        
        waitToInteract = new WaitForSeconds(timeToWait);
        
    }

    private void Update()
    {
        SenceInput();
    }

    private void FixedUpdate()
    {        
        LookForward();
        
    }

    private void SenceInput()
    {
        //Debug.Log("sence");
        if (Input.GetKeyDown(interactKey))
        {
            Debug.Log("interact");

            if (canInteract == true)
            {
                Debug.Log("can");
                InvokeInteraction aII = aGO.GetComponent<InvokeInteraction>();

                if (aII != null)
                {
                    Debug.Log("comp");

                    aII.Execute(this.gameObject);
                    /*thrower.ballOBJ = aGO;
                    thrower.ballOBJ.layer = 7;
                    thrower.ballOBJ.GetComponent<Ball>().ballLayer = 7;
                    thrower.hasBall = true;*/
                    StartCoroutine(WaitToInteract());
                }
            }    
            
        }
    }

    private void LookForward()
    {
        RaycastHit hit;

        if (Physics.Raycast(tf.position, transform.forward, out hit, drawDistance))
        {
            if(hit.transform.GetComponent<InvokeInteraction>() != null)
            {
                aGO = hit.transform.gameObject;                
            }            
        }

        else
        {
            aGO = emptyGO;
        }
    }

    private IEnumerator WaitToInteract()
    {
        canInteract = false;
        yield return waitToInteract;
        canInteract = true;
    }
}
