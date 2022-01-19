using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Change_Mgr : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void GoMainPage()
    {
        SceneManager.LoadScene(1);
        Cursor.visible = true;
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
