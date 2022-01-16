using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKey : MonoBehaviour
{    
    void Update()
    {
        PressKey();        
    }

    public void PressKey()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }
    }
}
