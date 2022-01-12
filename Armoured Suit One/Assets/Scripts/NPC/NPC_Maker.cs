using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Maker : MonoBehaviour
{
    public GameObject npcPrefab;
    public GameObject[] npcPool;
    public int poolSize = 10;

    public Json_DataBase dataBase;
    public int index;
    public string objectName;
    public string objectType;
    public int hp;
    public int shield;
    public int armor;
    public float speed;

    void Start()
    {
        var npcStat = dataBase.npcStat[index];
        objectName = npcStat.name;
        objectType = npcStat.type;
        hp = npcStat.hp;
        shield = npcStat.shield;
        armor = npcStat.armor;
        speed = npcStat.speed;

        NPC_Mgr npc = npcPrefab.GetComponentInChildren<NPC_Mgr>();
        npc.index = index;
        npc.objectName = objectName;
        npc.objectType = objectType;
        npc.hp = hp;
        npc.shield = shield;
        npc.armor = armor;
        npc.speed = speed;

        npcPool = new GameObject[poolSize];
        for (int i = 0; i < npcPool.Length; i += 2)
        {
            npcPool[i] = Instantiate(npcPrefab) as GameObject;
            npcPool[i].transform.position = new Vector3(transform.position.x + i, transform.position.y, transform.position.z - i);            
            npcPool[i].SetActive(false);
        }
        for (int i = 1; i < npcPool.Length; i += 2)
        {
            npcPool[i] = Instantiate(npcPrefab) as GameObject;
            npcPool[i].transform.position = new Vector3(transform.position.x - i - 1, transform.position.y, transform.position.z - i - 1);
            npcPool[i].SetActive(false);
        }
    }
}