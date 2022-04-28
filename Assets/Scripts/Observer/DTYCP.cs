//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTYCP : ServeCMD, Subscription
{
    private KeyCode yesKey = KeyCode.Y;
    private KeyCode noKey = KeyCode.N;

    [SerializeField] private float subCost = 1f;
    [SerializeField] private float unSubCost = 1f;

    private Subscriber aSubToAlt;
    private List<Subscriber> subscribers;
    private DTYCPMess messages = new DTYCPMess();
    [SerializeField] private float msgDelay = 10;
    private WaitForSeconds timeBetweenMess;
    private bool canSend = true;

    private bool isServing = false;
    private bool canSub = true;

    [SerializeField] private Text playerMessages;

    private void Awake()
    {
        timeBetweenMess = new WaitForSeconds(msgDelay);
    }

    // Update is called once per frame
    private void Update()
    {
        if (subscribers != null)
        {
            if (canSend == true)
            {
                foreach (Subscriber aSub in subscribers)
                {
                    SendMessage(aSub);
                }
            }
        }
        
        if (Input.GetKeyDown(yesKey))
        {
            if (isServing == true)
            {
                if(canSub == true)
                {
                    AddSubscriber(aSubToAlt);
                    isServing = false;
                    canSend = true;
                    playerMessages.text = "Thank you for joining, you foolish child";
                }
                else
                {
                    RemoveSubscriber(aSubToAlt);
                    isServing = false;
                    canSend = true;
                    playerMessages.text = "Good Riddence, you foolish child";

                }
            }
        }
        if (Input.GetKeyDown(noKey))
        {
            if (isServing == true)
            {
                isServing = false;
                canSend = true;

            }
        }
    }

    public void AddSubscriber(Subscriber aSub)
    {
        subscribers.Add(aSub);
    }

    public void RemoveSubscriber(Subscriber aSub)
    {
        subscribers.Remove(aSub);
    }


    public void SendMessage(Subscriber aSub)
    {
        StartCoroutine(DelayMessage());
        playerMessages.text = messages.GetMessage();
    }

    // time messages automatic
    private IEnumerator DelayMessage()
    {
        canSend = false;
        yield return timeBetweenMess;
        canSend = true;
    }

    // serve player on interact
    public override void Service(GameObject aCli)
    {
        canSend = false;
        StopAllCoroutines();
        Subscriber aSub = aCli.GetComponent<Subscriber>();
        if (aSub != null)
        {
            aSubToAlt = aSub;
            int subMention = 0;
            foreach(Subscriber sub in subscribers)
            {
                subMention += 1;
            }
            if (subMention != 0)
            {
                ServeSub();
            }
            else
            {
                ServeNonSub();
            }
            
            
        }
    }

    private void ServeSub()
    {
        isServing = true;
        canSub = false;
        playerMessages.text = "Would you like to unsubscribe for " + unSubCost.ToString() + " Y/N";
    }

    private void ServeNonSub()
    {
        isServing = true;
        canSub = true;
        playerMessages.text = "Would you like to subscribe for " + subCost.ToString() + " Y/N";
    }

}
