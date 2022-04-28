using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public void LoadIsaac()
    {
        SceneManager.LoadScene("IsaacScene");
    }
    
    public void LoadJosh()
    {
        SceneManager.LoadScene("JoshScene");
    }
    
    public void LoadMike()
    {
        SceneManager.LoadScene("MikeScene");
    }

    public void LoadNicole()
    {
        SceneManager.LoadScene("NicoleScene");
    }

}
