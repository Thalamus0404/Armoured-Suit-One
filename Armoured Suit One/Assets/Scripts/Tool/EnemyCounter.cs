using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public int count;
    public Text counter;
    public NPC_Maker npc_Maker;
    public GameObject victoryPanel;

    public bool gameOver = false;

    void Start()
    {
        count = npc_Maker.poolSize;
    }

    private void Update()
    {
        counter.text = count.ToString();
        if (count == 0 && !gameOver)
        {
            //Debug.Log("0ตส");
            StartCoroutine("Victory");
        }
    }

    public IEnumerator Victory()
    {

        gameOver = true;
        Cursor.visible = true;
        yield return new WaitForSeconds(5f);
        victoryPanel.SetActive(true);        
        Time.timeScale = 0;        
    }
}
