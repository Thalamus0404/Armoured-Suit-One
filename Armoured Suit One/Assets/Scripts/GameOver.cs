using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public int hp;
    public Player_Mgr player;
    public GameObject gameOverPanel;

    public bool gameOver = false;

    void Start()
    {
        hp = player.flightHp;
    }

    private void Update()
    {
        hp = player.flightHp;
        if (hp <= 0 && !gameOver)
        {
            //Debug.Log("0ตส");
            StartCoroutine("GameSet");
        }
    }

    public IEnumerator GameSet()
    {
        gameOver = true;
        Cursor.visible = true;
        yield return new WaitForEndOfFrame();
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
