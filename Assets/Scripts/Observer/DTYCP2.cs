//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DTYCP2 : ServeCMD
{
    [Header("Set or Adjust")]
    [SerializeField] private int subCost = 1;
    [SerializeField] private int unSubCost = 15;
    [SerializeField] private Description aDes;
    [SerializeField] private float msgDelay = 10;
    

    [Header("Do Not Tuoch")]
    [SerializeField] private List<Subscriber> subscribers;
    private DTYCPMess messages = new DTYCPMess();
    private string currMessage;
    
    private WaitForSeconds timeBetweenMess;
    private bool canSend = true;

    [SerializeField] private Text playerMessages;
    [SerializeField] private Cash CashObj = Cash.Instance;

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
                SendAllSubsMessage();
            }
        }

        
        
        
    }

    private void SendAllSubsMessage()
    {
        StartCoroutine(DelayMessage());
        currMessage = messages.GetMessage();
        foreach (Subscriber aSub in subscribers)
        {
            SendMessage(aSub);
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
        
        aSub.GetMessage("DTYCP", currMessage);
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
        Subscriber aPosSub =  aCli.GetComponent<Subscriber>();
        if (aPosSub != null)
        {

            int subMentions = 0;
            foreach(Subscriber sub in subscribers)
            {
                if (sub == aPosSub)
                {
                    subMentions += 1;
                } 
            }
           

            if (subMentions != 0)
            {
                Debug.Log("revs");
                if(CashObj.playerCash >= unSubCost)
                {
                    CashObj.playerCash -= unSubCost;
                    RemoveSubscriber(aPosSub);
                }                
            }
            else
            {
                Debug.Log("adds");
                if(CashObj.playerCash >= subCost)
                {
                    CashObj.playerCash -= subCost;
                    AddSubscriber(aPosSub);
                }                
            }
        }
    }
}
