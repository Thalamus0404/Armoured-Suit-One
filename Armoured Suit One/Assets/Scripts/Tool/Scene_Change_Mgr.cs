using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Mgr : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    //public void GoMainPage()
    //{
    //    SceneManager.LoadScene(1);
    //}

    public void Exit()
    {
        Application.Quit();
    }
}
