//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarnTargControler : ServeCMD
{
    // removed app to inherit from Servicecmd to allow use of invoke through interact
    [Header("MVC Through Strat")]
    [SerializeField] private CarnTargModel model;
    [SerializeField] private CarnTargView view;

    [Header("Displays")]
    [SerializeField] private GameObject instructBack;
    [SerializeField] private Text instructTxt;
    [SerializeField] private GameObject timeBack;
    [SerializeField] private Text timeTxt;


    [Header("Game Vars")]
    [SerializeField] private float initialForce = 100;
    [SerializeField] private int targVal = 2;
    [SerializeField] private int roundMult = 0;
    [SerializeField] private float timeLim = 2;
    [SerializeField] private string instructs = "";
    [SerializeField] private string endTxt = "";
    [SerializeField] private float hideInstrustDelay = 3f;



    // game vars not to change or be seen
    private bool gameStarted = false;
    private Cash CashObj = Cash.Instance;
    private int roundCash = 0;
    private int score = 0;

    // countdown
    private WaitForSeconds delayInstructHide;
    private float dur = 0;
    private Subscriber aPlayer;

    private void Awake()
    {
        delayInstructHide = new WaitForSeconds(hideInstrustDelay);
    }


    // Start is called before the first frame update
    void Start()
    {
        ClearDisplay();
        TargGameReset();
    }

    //Start display functions
    private void ClearDisplay()
    {
        instructBack.SetActive(false);
        instructTxt.text = "";
        timeBack.SetActive(false);
        timeTxt.text = "";
    }

    private void Instruct()
    {
        instructBack.SetActive(true);
        instructTxt.text = instructs;
        StartCoroutine(DelayInstructHide());
    }

    private void CloseInstructions()
    {
        instructBack.SetActive(false);
        instructTxt.text = "";
    }

    private void LastWords()
    {
        instructBack.SetActive(true);
        instructTxt.text = "Thank you for playing Drones in a Cube" + "\n" + 
                            "Your score was: " + score.ToString();
        StartCoroutine(DelayClearDisplay()); 
    }




    // game running functions and update
    private void Update()
    {
        KeepTime();
    }

    private void KeepTime()
    {
        if (gameStarted == true)
        {            
            dur += Time.deltaTime;
            float displayTime = dur / 60;
            timeTxt.text = "Time: " + displayTime.ToString("F2") + "\n" + "Score: " + score.ToString();
            if (displayTime >= timeLim)
            {
                EndGame();
                Debug.Log("end");
            }
        }
    }

    private void EndGame()
    {
        CashObj.playerCash += roundCash * roundMult;
        HideAllTargs();
        LastWords();
        gameStarted = false;
    }

    public override void Service(GameObject aCli)
    {
        aPlayer = aCli.GetComponent<Subscriber>();
        GameStart();
    }

    private void GameStart()
    {
        timeBack.SetActive(true);
        Instruct();
        dur = 0;
        gameStarted = true;
        roundCash = 0;
        score = 0;
        TargGameReset();
    }

    public void TargGameReset()
    {
        
        for (int idx = 0; idx < view.targets.Length - 1; idx++)
        {
            view.targets[idx].SetActive(true);
            Health targHealth = view.targets[idx].GetComponent<Health>();
            targHealth.health = targHealth.fullHealth;


            ResetTargPos(view.targets[idx].transform,
                            model.startPosses[idx].transform);

            InitialTargMovement(view.targets[idx].GetComponent<Rigidbody>());
        }
    }

    private void ResetSingleTarg(GameObject aGO)
    {
        aGO.SetActive(true);
        int randInt = Random.Range(0, view.targets.Length);
        CarnDrone carnDrone = aGO.GetComponent<CarnDrone>();
        Health aHealth = aGO.GetComponent<Health>();
        aHealth.health = aHealth.fullHealth;
        carnDrone.tf = view.targets[randInt].transform;
        carnDrone.rb.velocity *= 0f ;
        carnDrone.rb.AddForce(carnDrone.rb.transform.forward * initialForce, ForceMode.Impulse);
        

    }

    private void ResetTargPos(Transform tf, Transform startPoint)
    {
        tf.position = startPoint.position;
        tf.rotation = startPoint.rotation;
    }
    private void InitialTargMovement(Rigidbody rb)
    {
        rb.AddForce(rb.transform.forward * initialForce, ForceMode.Impulse);
    }

    public void TakeDammage(GameObject aGO, float dammage)
    {
        
        Health ahealth = aGO.GetComponent<Health>();
        if(ahealth.health > 0)
        {
            ahealth.health -= dammage;
        }
        else
        {
            roundCash += ahealth.targVal;
            score += 1;
            aGO.SetActive(false);
            ResetSingleTarg(aGO);
            
        }
    }

    public void HideAllTargs()
    {
        for (int idx = 0; idx < view.targets.Length; idx++)
        {
            view.targets[idx].SetActive(true);
        }
    }

    // coroutines

    private IEnumerator DelayInstructHide()
    {
        yield return delayInstructHide;
        CloseInstructions();
    }

    private IEnumerator DelayClearDisplay()
    {
        yield return delayInstructHide;
        ClearDisplay();
    }
    
}
