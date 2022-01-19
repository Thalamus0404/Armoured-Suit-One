using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public GameOver gameOver;
    public EnemyCounter victory;
    public bool isPause = false;

    private void Start()
    {
        gameOver = GetComponent<GameOver>();
        victory = GetComponent<EnemyCounter>();
    }

    void Update()
    {
        if (!gameOver.isGameOver && !victory.isVictory)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !isPause)
            { 
                OpenMenu(menu);
                Debug.Log("¿ÀÇÂ");
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPause)
            {
                CloseMenu(menu);
                Debug.Log("Å¬·ÎÁî");
            }
        }
    }

    public void OpenMenu(GameObject menu)
    {
        isPause = true;
        menu.SetActive(true);        
        Time.timeScale = 0f;
    }

    public void CloseMenu(GameObject menu)
    {
        isPause = false;
        menu.SetActive(false);        
        Time.timeScale = 1f;
    }
}