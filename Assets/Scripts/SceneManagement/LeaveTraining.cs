using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveTraining : MonoBehaviour
{
    private KeyCode leaveKey = KeyCode.L;
    private void Update()
    {
        if (Input.GetKeyDown(leaveKey))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Start");

        }

        
        
    }

}
