using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubject
{
    public void RegisterObserver(CharacterBroadcast c);
    public void RemoveObserver(CharacterBroadcast c);
    public void Notify();
}
