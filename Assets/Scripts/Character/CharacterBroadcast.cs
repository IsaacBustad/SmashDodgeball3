using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBroadcast : MonoBehaviour, IObserver
{
    private NPCharacter myNPC;
    private Singleton mySingleton = Singleton.Instance;
    public void updateObserver(List<GameObject> aListOfBalls, List<GameObject> aListOfPlayers)
    {
        myNPC.AllBalls = aListOfBalls;
        myNPC.AllPlayers = aListOfPlayers;
    }

    private void Awake()
    {
        myNPC = this.gameObject.GetComponent<NPCharacter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        mySingleton.RegisterObserver(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
