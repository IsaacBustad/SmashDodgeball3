using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text DamageMeterText;
    public CharHealth charHealth;

    private static bool UIExists;

    void Start()
    {
        if (!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        DamageMeterText.text = charHealth.Health.ToString() + "%\nPlayer" ;
    }
}
