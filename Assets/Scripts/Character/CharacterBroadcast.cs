using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBroadcast : MonoBehaviour, IObserver
{
    //[SerializeField] private bool isPlayer = false;
    private NPCGetBall myNPC;
    private Singleton mySingleton = Singleton.Instance;
    public void updateObserver(List<GameObject> aListOfBalls, List<GameObject> aListOfPlayers)
    {
        if (myNPC != null)
        {
            myNPC.AllBalls = aListOfBalls;
            myNPC.AllPlayers = aListOfPlayers;
        }
    }

    private void Awake()
    {
        myNPC = this.gameObject.GetComponent<NPCGetBall>();
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
