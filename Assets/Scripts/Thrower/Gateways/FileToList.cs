//Creator Isaac Bustad
// created 3/3/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileToList
{
    private string path = "Assets//TxtFiles//testGate.txt";

    public string[] GetMSGs()
    {
        string[] allMSGs = File.ReadAllLines(path);
        return allMSGs;
    }
    
}
