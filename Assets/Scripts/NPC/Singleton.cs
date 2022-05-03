using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Singleton : ISubject
{
    private static Singleton instance = null;
    private List<GameObject> allBalls = new List<GameObject>();
    private List<GameObject> allPlayers = new List<GameObject>();
    private List<CharacterBroadcast> observers = new List<CharacterBroadcast>();

    public Queue<GameObject> OutPlayers = new Queue<GameObject>();


    public ShrinkModel shrinkModel;
    private bool elimsStart = false;
    private Singleton()
    {

    }
    public static Singleton Instance
    {
        get
        {
            if (Singleton.instance == null)
            {
                Singleton.instance = new Singleton();
                Singleton.instance.observers = new List<CharacterBroadcast>();
                return Singleton.instance;
            }
            else
            {
                return Singleton.instance;
            }
        }
    }


    public void RegisterObserver(CharacterBroadcast c)
    {
        this.observers.Add(c);
        this.AllPlayers.Add(c.gameObject);
       
        Notify();
    }


    public void RemoveObserver(CharacterBroadcast o)
    {
        this.observers.Remove(o);
        this.AllPlayers.Add(o.gameObject);
        this.elimsStart = true;
        this.Notify();

        CheckForTeamDefeat();
    }

    private void CheckForTeamDefeat()
    {
        List<GameObject> listRed = new List<GameObject>();
        List<GameObject> listBlu = new List<GameObject>();

        foreach(var i in AllPlayers)
        {
            if(i.layer == 9)
            {
                listRed.Add(i);
            }
            
            else if(i.layer == 10)
            {
                listBlu.Add(i);
            }
        }

        if (listRed.Count <= 0)
        {
            GameObject.FindObjectOfType<WinLose>().LoadLose();
        }
        
        if (listBlu.Count <= 0)
        {
            GameObject.FindObjectOfType<WinLose>().LoadWin();
        }
    }

    public void BallUpdated(List<GameObject> newBalls)
    {
        this.AllBalls = newBalls;
        Debug.Log("NewBalls: " + newBalls.Count);
        Notify(); 
    }


    public void Notify()
    {
        foreach (var o in observers)
        {
            o.updateObserver(AllBalls, AllPlayers);

        }

        if(shrinkModel != null)
        {
            shrinkModel.updateObserver(AllBalls, AllPlayers);
        }
    }


    public override string ToString()
    {
        return "Singleton is Alive!!!";
    }


    public List<GameObject> AllBalls
    {
        get { return this.allBalls; }
        set { this.allBalls = value; }
    }
    public List<GameObject> AllPlayers
    {
        get { return this.allPlayers; }
        set { this.allPlayers = value; }
    }
}
