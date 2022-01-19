using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Maker : MonoBehaviour
{
    public GameObject npcPrefab;
    public GameObject[] npcPool;
    public int poolSize = 10;

    public GameObject dataBase;
    public Json_NPC_Stat_DataBase stat_DataBase;
    public Json_NPC_Weapon_DataBase weapon_DataBase;

    public int index;
    public int weapon1Index;
    public int weapon2Index;

    public string objectName;
    public string objectType;
    public int hp;
    public int shield;
    public int armor;
    public float speed;
    
    public string weapon1Name;
    public int weapon1ATK;
    public float weapon1Speed;
    public int weapon1Range;

    public string weapon2Name;
    public int weapon2ATK;
    public float weapon2Speed;
    public int weapon2Range;

    void Start()
    {
        dataBase = GameObject.Find("Json_DataBase");
        stat_DataBase = dataBase.GetComponent<Json_NPC_Stat_DataBase>();
        weapon_DataBase = dataBase.GetComponent<Json_NPC_Weapon_DataBase>();
        var npcStat = stat_DataBase.npcStat[index];
        objectName = npcStat.name;
        objectType = npcStat.type;
        hp = npcStat.hp;
        shield = npcStat.shield;
        armor = npcStat.armor;
        speed = npcStat.speed;

        var npcWeapon1 = weapon_DataBase.npcWeapon[weapon1Index];
        weapon1Name = npcWeapon1.objectName;
        weapon1ATK = npcWeapon1.atk;
        weapon1Speed = npcWeapon1.speed;
        weapon1Range = npcWeapon1.range;

        var npcWeapon2 = weapon_DataBase.npcWeapon[weapon2Index];
        weapon2Name = npcWeapon2.objectName;
        weapon2ATK = npcWeapon2.atk;
        weapon2Speed = npcWeapon2.speed;
        weapon2Range = npcWeapon2.range;

        NPC_Mgr npc = npcPrefab.GetComponent<NPC_Mgr>();
        npc.index = index;
        npc.objectName = objectName;
        npc.objectType = objectType;
        npc.hp = hp;
        npc.shield = shield;
        npc.armor = armor;
        npc.speed = speed;

        npc.weapon1Index = weapon1Index;
        npc.weapon1Name = weapon1Name;
        npc.weapon1ATK = weapon1ATK;
        npc.weapon1Speed = weapon1Speed;
        npc.weapon1Range = weapon1Range;

        npc.weapon2Index = weapon2Index;
        npc.weapon2Name = weapon2Name;
        npc.weapon2ATK = weapon2ATK;
        npc.weapon2Speed = weapon2Speed;
        npc.weapon2Range = weapon2Range;

        npcPool = new GameObject[poolSize];
        for (int i = 0; i < npcPool.Length; i += 2)
        {
            npcPool[i] = Instantiate(npcPrefab) as GameObject;
            npcPool[i].transform.position = new Vector3(transform.position.x + 3 * i, transform.position.y + i, transform.position.z - 2 * i);
            npcPool[i].transform.rotation = transform.rotation;
            npcPool[i].name = npcPrefab.tag + objectName;
            npcPool[i].SetActive(true);
        }
        for (int i = 1; i < npcPool.Length; i += 2)
        {
            npcPool[i] = Instantiate(npcPrefab) as GameObject;
            npcPool[i].transform.position = new Vector3(transform.position.x - 3 * (i + 1), transform.position.y + i, transform.position.z - 3 * (i + 1));
            npcPool[i].transform.rotation = transform.rotation;
            npcPool[i].name = npcPrefab.tag + objectName;
            npcPool[i].SetActive(true);
        }
    }
}