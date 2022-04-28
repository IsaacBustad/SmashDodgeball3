//Creator Isaac Bustad
// created 3/3/2022


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash
{
    private static Cash instance = null;
    public int playerCash = 11;

    private Cash()
    {

    }

    public static Cash Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Cash();
            }
            return instance;
        }
    }
}
