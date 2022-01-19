using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public int count;
    public Text counter;
    public NPC_Maker[] npc_Maker;
    public GameObject victoryPanel;

    public bool isVictory = false;

    void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("EnemyMaker").Length; i++)
        {            
            count += npc_Maker[i].poolSize;
        }
    }

    private void Update()
    {
        counter.text = count.ToString();
        if (count <= 0 && !isVictory)
        {
            //Debug.Log("0ตส");
            StartCoroutine("Victory");
        }
    }

    public IEnumerator Victory()
    {

        isVictory = true;
        Cursor.visible = true;
        yield return new WaitForSeconds(5f);
        victoryPanel.SetActive(true);        
        Time.timeScale = 0;        
    }
}
