//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Subscription 
{
    public void AddSubscriber(Subscriber aSub);

    public void RemoveSubscriber(Subscriber aSub);

    public void SendMessage(Subscriber aSub);
    
}
