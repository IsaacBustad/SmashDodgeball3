//Creator Isaac Bustad
// created 3/3/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : CarnTargElement
{
    public float fullHealth;
    public float health;
    public int targVal;

    public void TakeDammage(float damage)
    {
        carnTarApp.controler.TakeDammage(gameObject, damage);
    }
}

//Mike's Awesome Change